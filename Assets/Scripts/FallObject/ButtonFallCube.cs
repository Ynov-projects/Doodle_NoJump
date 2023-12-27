using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject fallCube; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            
            if (fallCube != null)
            {
                fallCube.SetActive(true);
            }
        }
    }
}
