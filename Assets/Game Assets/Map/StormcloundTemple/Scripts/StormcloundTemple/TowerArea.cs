using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArea : MonoBehaviour
{
	public enum TowerType
	{
		BowTower,
		MagicTower,
		TurretTower,
		SoldierTower
	}

	public TowerType type = TowerType.BowTower;

	public void OnMouseDown()
	{
		if (GetComponent<Collider2D>().isTrigger)
		{
			// Hiển thị các sự lựa chọn kiểu súng
			GameObject[] options = new GameObject[4];
			for (int i = 0; i < options.Length; i++)
			{
				options[i] = new GameObject();
				options[i].transform.SetParent(transform);
				options[i].transform.localPosition = new Vector2(0, i * 100);
		//		options[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Gun" + (i + 1));
			}

			// Xử lý sự kiện chọn kiểu súng
			for (int i = 0; i < options.Length; i++)
			{
		//		options[i].GetComponent<Image>().onClick.AddListener(OnSelect);
			}
		}
	}

	public void OnSelect()
	{
		// Lấy kiểu súng đã chọn
	//	int index = (int)GetComponent<Image>().name.Replace("Gun", "");
	//	type = (TowerType)index;

		// Xóa các sự lựa chọn kiểu súng
		for (int i = 0; i < transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}
}
