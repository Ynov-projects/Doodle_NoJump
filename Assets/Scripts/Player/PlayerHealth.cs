using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public static PlayerHealth Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(amount);
        health -= amount;
        if (health <= 0)
        {
            PlayerMovement.instance.enabled = false;
            for(int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            transform.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.SetActive(false);

        }
        HealthDisplay.instance.ChangeHealth();
    }
}
