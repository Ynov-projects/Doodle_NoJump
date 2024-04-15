using UnityEngine;

public class currentSceneManager : MonoBehaviour
{
    public Vector3 spawnPoint = Vector3.zero;

    public static currentSceneManager instance;
    [SerializeField] private AudioClip clip;
    [SerializeField] private PauseMenu pauseMenu;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && Vector3.Distance(PlayerMovement.instance.transform.position, spawnPoint) >= 10f && spawnPoint != Vector3.zero && PlayerHealth.Instance.health > 0)
        {
            PlayerMovement.instance.transform.position = spawnPoint;
            AudioManager.Instance.PlayClip(clip);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu != null)
        {
            pauseMenu.Pause();
            Time.timeScale = 0;
        }
    }
}
