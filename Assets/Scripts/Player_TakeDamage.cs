using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TakeDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy_Health>() != null)
        {
            Game_Manager.instance.PlayerGetDamage();
            Enemy_Health _enemyHealth = other.gameObject.GetComponent<Enemy_Health>();
            _enemyHealth.Destroy();

        }
    }
}
