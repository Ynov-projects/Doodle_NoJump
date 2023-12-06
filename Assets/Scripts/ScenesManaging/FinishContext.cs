using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishContext : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Level_1");
        }
    }
}
