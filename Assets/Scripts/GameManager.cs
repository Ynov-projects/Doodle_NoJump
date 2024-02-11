using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Item[] _items;

    void Start()
    {
        foreach(Item i in _items) i.Quantity = 0;
    }
}
