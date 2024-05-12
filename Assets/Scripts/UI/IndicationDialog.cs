using UnityEngine;
using UnityEngine.UI;

public class IndicationDialog : MonoBehaviour
{
    [SerializeField] private Sprite keyboardSprite;
    [SerializeField] private Sprite gamepadSprite;

    [SerializeField] private Image sprite;

    void Start()
    {
        if (GameManager.lastDevice == null)
            sprite.sprite = keyboardSprite;
        else
            sprite.sprite = GameManager.lastDevice.name == "" || GameManager.lastDevice.name == "Keyboard" ? keyboardSprite : gamepadSprite;
    }

    void FixedUpdate()
    {
        if (GameManager.lastDevice == null)
            sprite.sprite = keyboardSprite;
        else
            sprite.sprite = GameManager.lastDevice.name == "" || GameManager.lastDevice.name == "Keyboard" ? keyboardSprite : gamepadSprite;
    }
}
