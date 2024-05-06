using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Item[] _items;

    public static Color32 activeColor = new Color32(219, 151, 15, 255);
    public static Color32 inactiveColor = new Color32(0, 0, 255, 255);

    [SerializeField] private GameObject timerPanel;
    [SerializeField] private Text timerText;

    public static PlayerInput input;
    public static InputDevice lastDevice;

    private float timeElapsed;

    private void Awake()
    {
        input = new PlayerInput();
        input.Gameplay.Enable();
    }

    void Start()
    {
        foreach (Item i in _items) i.Quantity = 0;

        input.Gameplay.Get().actionTriggered +=
            ctx => ChangeDevice(ctx);

        if (currentSceneManager.instance.speedrunMode && timerPanel != null)
            timerPanel.SetActive(true);
        
        timeElapsed = 0;
        StartCoroutine(UpdateTimer());
    }

    private void ChangeDevice(InputAction.CallbackContext ctx)
    {
        lastDevice = ctx.control?.device;
    }

    private IEnumerator UpdateTimer()
    {
        while (currentSceneManager.instance.speedrunMode)
        {
            timeElapsed += Time.deltaTime;
            timerText.text = TimeSpan.FromSeconds(timeElapsed).ToString("mm':'ss':'ff");
            yield return null;
        }
    }

    public void activate()
    {
        currentSceneManager.instance.speedrunMode = true;
        currentSceneManager.instance.startTime = Time.fixedTime;
    }

    public void desactivate()
    {
        currentSceneManager.instance.speedrunMode = false;
        currentSceneManager.instance.startTime = 0;
    }
}
