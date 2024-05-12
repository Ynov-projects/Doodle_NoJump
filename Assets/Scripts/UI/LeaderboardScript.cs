using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScript : MonoBehaviour
{
    [SerializeField] private GameObject UIElement0;
    [SerializeField] private GameObject UIElement;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) PlayerPrefs.DeleteAll();
    }

    void Start()
    {
        // Ici, on ajoute les clefs de base s'il n'y en a pas
        if (!PlayerPrefs.HasKey("topScore0"))
            for (int i = 0; i < 10; i++)
            {
                int score = 1200000 + (60000 * i);
                PlayerPrefs.DeleteKey("topScore" + i);
                PlayerPrefs.DeleteKey("topPseudo" + i);
                PlayerPrefs.SetInt("topScore" + i, score);

                string pseudotest = "The banned Ethan";
                switch (i)
                {
                    case 0: pseudotest = "Brown Bowser"; break;
                    case 1: pseudotest = "Green Luigi"; break;
                    case 2: pseudotest = "Red Mario"; break;
                    case 3: pseudotest = "Yellow Wario"; break;
                    case 4: pseudotest = "Purple Waluigi"; break;
                    case 5: pseudotest = "White Toad"; break;
                    case 6: pseudotest = "Pink Peach"; break;
                    case 7: pseudotest = "Orange Daisy"; break;
                    case 8: pseudotest = "Multicolor Yoshi"; break;
                }

                PlayerPrefs.SetString("topPseudo" + i, pseudotest);
                PlayerPrefs.Save();
            }
        
        // On set up le visuel
        for (int i = 0; i < 10; i++)
        {
            int milliScore = PlayerPrefs.GetInt("topScore" + i);
            string pseudo = PlayerPrefs.GetString("topPseudo" + i);

            string score = TimeSpan.FromMilliseconds(milliScore).ToString("mm':'ss':'ff");

            GameObject instance;
            if (i == 0)
                instance = UIElement0;
            else
            {
                instance = Instantiate(UIElement, transform);
                instance.transform.localPosition = new Vector3(0, 275 + (-50 * i), 0);
            }

            Text textPseudo = instance.transform.GetChild(0).ConvertTo<Text>();
            textPseudo.text = pseudo;

            Text textScore = instance.transform.GetChild(1).ConvertTo<Text>();
            textScore.text = score;
        }
    }
}
