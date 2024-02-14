using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Item[] _items;

    public static Color32 activeColor = new Color32(219, 151, 15, 255);
    public static Color32 inactiveColor = new Color32(0, 0, 255, 255);

    void Start()
    {
        foreach(Item i in _items) i.Quantity = 0;
    }
}
