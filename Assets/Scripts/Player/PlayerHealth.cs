using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public static PlayerHealth Instance;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject lessLife;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    void Start()
    {
        health = maxHealth;
    }
    public void GetLife(int amount)
    {
        health += amount;
        UpdateLife();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        lessLife.SetActive(true);
        UpdateLife();
    }

    private void UpdateLife()
    {
        if (health <= 0)
        {
            PlayerMovement.instance.enabled = false;
            for (int i = 0; i < transform.childCount; i++)
                if(transform.GetChild(i).tag == "LegPlayer") transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;

            transform.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.SetActive(false);

            deathPanel.SetActive(true);
        }
        HealthDisplay.instance.ChangeHealth();
    }
}
