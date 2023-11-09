using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseTower : MonoBehaviour
{
    public GameObject towerSelectionMenu; // Menu hiển thị danh sách tháp
    public List<GameObject> towerPrefabs; // Danh sách các prefab tháp
    private Vector2 buttonPosition; // Vị trí của button đã nhấn
    private bool indexClick = true;
    public List<Button> buttons;
    private Button lastPressedButton = null;

    private void Start()
    {
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => ShowImageAtButtonPosition(btn));
        }
        towerSelectionMenu.SetActive(false);  // Ẩn image khi khởi động
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && towerSelectionMenu.activeSelf)
        {
            // Kiểm tra xem chuột có đang trỏ vào UI không
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // Nếu không, ẩn imageObject
                towerSelectionMenu.SetActive(false);
                indexClick = true;
            }
        }
    }
    private void ShowImageAtButtonPosition(Button clickedButton)
    {
        if (indexClick)
        {
            buttonPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerSelectionMenu.transform.position = clickedButton.transform.position;
            towerSelectionMenu.SetActive(true);
            indexClick = false;
            lastPressedButton = clickedButton;
        }
        else
        {
            towerSelectionMenu.SetActive(false);
            indexClick = true;
        }
    }

	// Gọi phương thức này khi chọn một tháp từ danh sách
	public void OnTowerSelected(int index)
	{
		if (index >= 0 && index < towerPrefabs.Count)
		{
			// Kiểm tra xem buttonPosition đã được khởi tạo hay chưa
			if (buttonPosition != null)
			{
				// Xây dựng tháp ở tọa độ buttonPosition
				GameObject tower = Instantiate(towerPrefabs[index], buttonPosition, Quaternion.identity);

				// Đảm bảo tháp xuất hiện trên cùng
				SpriteRenderer sr = tower.GetComponent<SpriteRenderer>();
				sr.sortingOrder = 1000; // Đặt một giá trị cao để đảm bảo tháp hiển thị trên cùng

				towerSelectionMenu.SetActive(false);
				indexClick = true;
				if (lastPressedButton != null)
				{
					lastPressedButton.gameObject.SetActive(false);  // Ẩn button cuối cùng được nhấn
					lastPressedButton = null;  // Xóa tham chiếu để tránh lỗi
				}
			}
			else
			{
				// Nếu buttonPosition chưa được khởi tạo, hiển thị một thông báo lỗi
				Debug.LogError("buttonPosition is null!");
			}
		}
	}

}
