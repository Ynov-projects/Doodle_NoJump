using UnityEngine;

public class Indication : MonoBehaviour
{
    [SerializeField] private Sprite keyboardSprite;
    [SerializeField] private Sprite gamepadSprite;

    [SerializeField] private SpriteRenderer sprite;

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
