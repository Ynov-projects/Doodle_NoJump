using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string object_name;
    public Sprite icon;

    public int Quantity;
}
