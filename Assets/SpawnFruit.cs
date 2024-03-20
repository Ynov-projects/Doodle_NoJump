using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    [SerializeField] private GameObject fruit;

    public void Spawn()
    {
        try
        {
            fruit.SetActive(true);
        }
        catch (System.Exception e)
        {
            Debug.Log("Il n'y a pas de fruit dans la scène");
        }
    }
}
