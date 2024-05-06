using UnityEngine;
using UnityEngine.EventSystems;

public class currentSceneManager : MonoBehaviour
{
    public Vector3 spawnPoint = Vector3.zero;

    public static currentSceneManager instance;
    [SerializeField] private AudioClip clip;
    [SerializeField] private PauseMenu pauseMenu;

    public bool speedrunMode;
    public float startTime;

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
        if (GameManager.input.Gameplay.Respawn.triggered)
        {
            if (Vector3.Distance(PlayerMovement.instance.transform.position, spawnPoint) >= 10f && spawnPoint != Vector3.zero && PlayerHealth.Instance.health > 0)
            {
                PlayerMovement.instance.transform.position = spawnPoint;
                AudioManager.Instance.PlayClip(clip);
            }
        }
        if (GameManager.input.Gameplay.Pause.triggered && pauseMenu != null)
        {
            EventSystem.current.SetSelectedGameObject(pauseMenu.transform.GetChild(0).gameObject);
            pauseMenu.Pause();
            Time.timeScale = 0;
        }
    }
}
