using UnityEngine;
using UnityEngine.InputSystem;

public class currentSceneManager : MonoBehaviour
{
    public Vector3 spawnPoint = Vector3.zero;

    public static currentSceneManager instance;
    [SerializeField] private AudioClip clip;

    private PlayerInput input;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;

        input = new PlayerInput();
        input.Gameplay.Enable();
    }

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Update()
    {
        if (input.Gameplay.Respawn.triggered)
        {
            if (Vector3.Distance(PlayerMovement.instance.transform.position, spawnPoint) >= 10f && spawnPoint != Vector3.zero && PlayerHealth.Instance.health > 0)
            {
                PlayerMovement.instance.transform.position = spawnPoint;
                AudioManager.Instance.PlayClip(clip);
            }
        }
    }
}
