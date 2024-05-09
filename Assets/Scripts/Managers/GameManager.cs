using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Item[] _items;

    public static Color32 activeColor = new Color32(219, 151, 15, 255);
    public static Color32 inactiveColor = new Color32(0, 0, 255, 255);

    public static PlayerInput input;
    public static InputDevice lastDevice;


    private void Awake()
    {
        input = new PlayerInput();
        input.Gameplay.Enable();
    }


    void Start()
    {
        PlayerPrefs.DeleteKey("speedRun");
        PlayerPrefs.SetInt("speedRun", 0);
        PlayerPrefs.Save();

        foreach (Item i in _items) i.Quantity = 0;

        input.Gameplay.Get().actionTriggered +=
            ctx => ChangeDevice(ctx);
    }

    private void ChangeDevice(InputAction.CallbackContext ctx)
    {
        lastDevice = ctx.control?.device;
    }

    public void activate()
    {
        PlayerPrefs.DeleteKey("speedRun");
        PlayerPrefs.SetInt("speedRun", 1);
        PlayerPrefs.Save();
    }

    public void desactivate()
    {
        PlayerPrefs.DeleteKey("speedRun");
        PlayerPrefs.SetInt("speedRun", 0);
        PlayerPrefs.Save();
    }
}
