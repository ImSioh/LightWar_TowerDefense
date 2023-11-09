using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCoolDown : MonoBehaviour
{
    [SerializeField]
    private Image[] imageCooldown;
    [SerializeField]
    private TMP_Text[] textCooldown;


    //variable for looking after the cooldown
    private bool isCoolDown = false;
    private float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            textCooldown[i].gameObject.SetActive(false);
            imageCooldown[i].fillAmount = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseSpell();
        }

        if (isCoolDown)
        {
            ApplyCooldown();
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0.0f)
        {
            for (int i = 0; i < 3; i++)
            {
                textCooldown[i].gameObject.SetActive(false);
                imageCooldown[i].fillAmount = 0.0f;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                textCooldown[i].text = Mathf.RoundToInt(cooldownTimer).ToString();
                imageCooldown[i].fillAmount = cooldownTimer / cooldownTime;
            }

        }

    }

    public void UseSpell()
    {
        if (isCoolDown)
        {
          //  return false;
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                isCoolDown = true;
                textCooldown[i].gameObject.SetActive(true);
                cooldownTimer = cooldownTime;
            }

        //    return true;
        }
    }

}
