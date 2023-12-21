using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    private int nbShields = 0;

    public static PlayerHealth Instance;
    [SerializeField] private GameObject deathPanel;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    void Start()
    {
        health = maxHealth;
    }

    public int getNbShield()
    {
        return nbShields;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }

    public void GetLife(int amount)
    {
        health += amount;
        UpdateLife();
    }

    public void GetShield(int amount)
    {
        nbShields += amount;
        HealthDisplay.instance.ChangeShield();
    }

    public void TakeDamage(int amount)
    {
        int stayingShields = nbShields - amount < 0 ? 0 : nbShields - amount;
        amount = amount - nbShields < 0 ? 0 : amount - nbShields;
        nbShields = stayingShields;

        health -= amount;
        UpdateLife();
    }

    private void UpdateLife()
    {
        if (health <= 0)
        {
            PlayerMovement.instance.enabled = false;
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            transform.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.SetActive(false);

            deathPanel.SetActive(true);
        }
        HealthDisplay.instance.ChangeHealth();
    }
}
