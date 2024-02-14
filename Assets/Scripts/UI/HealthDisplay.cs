using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public PlayerHealth playerHealth;

    public static HealthDisplay instance;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeHealth();
    }

    public void ChangeHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < playerHealth.health ? fullHeart : emptyHeart;
            hearts[i].enabled = i < playerHealth.maxHealth;
        }
    }
}
