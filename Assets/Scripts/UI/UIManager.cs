using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private GameObject[] panels;

    [SerializeField] private GameObject[] image;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            for (int j = 0; j < panels[i].transform.childCount; j++)
                Destroy(panels[i].transform.GetChild(j).gameObject);

            for (int j = 0; j < items[i].Quantity; j++)
            {
                GameObject _image = Instantiate(image[i], panels[i].transform);
                _image.GetComponent<Image>().sprite = items[i].icon;
                _image.transform.localPosition = new Vector3(-120 * j, 0, 0);
            }
        }
    }
}
