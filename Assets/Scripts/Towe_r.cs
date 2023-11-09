using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Towe_r : MonoBehaviour
{
    public Project_ile bullet;
    public Transform[] firePoints;
    public float shotPerSeconds;
    private float nextShotTime;
    public int level;
    public int maxLevel;
    public int upgradeCost;
    public Animator anim;
    public GameObject lvEffect;
    public Text upgradeCostText;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        upgradeCostText.text = upgradeCost.ToString();
    }
    public void AddLevel()
    {
        if (upgradeCost <= Game_Manager.instance.currentGold && level < maxLevel)
        {
            level++;
            Game_Manager.instance.ReduceGold(upgradeCost);
            anim.SetTrigger("Upgrade");
            shotPerSeconds++;
            Instantiate(lvEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(11);
        }
    }

    public void Shoot()
    {
        if (nextShotTime <= Time.time)
        {
            foreach (Transform firePoint in firePoints)
            {
                Project_ile _bulet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            }
            nextShotTime = Time.time + (1 / shotPerSeconds);
        }
    }
}
