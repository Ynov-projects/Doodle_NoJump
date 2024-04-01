using System.Collections;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    [SerializeField] private GameObject fruit;
    [SerializeField] private float timeForSpawn;

    public void Spawn()
    {
        if (fruit != null)
        {
            StartCoroutine(makeHimSpawn());
        }
    }

    private IEnumerator makeHimSpawn()
    {
        yield return new WaitForSeconds(timeForSpawn);
        fruit.SetActive(true);

        if (fruit.GetComponentInChildren<ParticleSystem>() != null)
            fruit.GetComponentInChildren<ParticleSystem>().Play();
    }
}
