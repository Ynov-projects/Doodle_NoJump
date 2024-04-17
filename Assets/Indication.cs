using UnityEngine;

public class Indication : MonoBehaviour
{
    [SerializeField] private Sprite keyboardSprite;
    [SerializeField] private Sprite gamepadSprite;

    [SerializeField] private SpriteRenderer sprite;

    void Start()
    {
        sprite.sprite = GameManager.lastDevice.name == "" || GameManager.lastDevice.name == "Keyboard" ? keyboardSprite : gamepadSprite;
    }

    void FixedUpdate()
    {
        sprite.sprite = GameManager.lastDevice.name == "" || GameManager.lastDevice.name == "Keyboard" ? keyboardSprite : gamepadSprite;
    }
}
