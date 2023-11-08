using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_context : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Level_1");
        }
    }
}
