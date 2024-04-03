using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyMaxLifeItem : MonoBehaviour
{
    [SerializeField] private GameObject lifeItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) lifeItem.GetComponent<Collider2D>().enabled = PlayerHealth.Instance.health < PlayerHealth.Instance.maxHealth;
    }
}
