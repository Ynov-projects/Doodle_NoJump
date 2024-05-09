using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject timerPanel;
    [SerializeField] private Text timerText;

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject pnlPseudo;

    [SerializeField] private GameManager gameManager;

    private float timeElapsed;

    private int newBestScore;

    public float getTimeElapsed() { return timeElapsed * 1000; }

    private void Start()
    {
        if (PlayerPrefs.GetInt("speedRun") == 1)
            timerPanel.SetActive(true);
        
        timeElapsed = 0;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (PlayerPrefs.GetInt("speedRun") == 1)
        {
            timeElapsed += Time.deltaTime;
            timerText.text = TimeSpan.FromSeconds(timeElapsed).ToString("mm':'ss':'ff");
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && PlayerPrefs.GetInt("speedRun") == 1)
        {
            newBestScore = (int) getTimeElapsed();
            PlayerMovement.instance.rb.velocity = Vector3.zero;
            PlayerMovement.instance.enabled = false;
            gameManager.StopAllCoroutines();
            pnlPseudo.SetActive(true);
        }
    }

    public void EnterScore()
    {
        int oldBestScore = 0;
        string oldBestScorer = "";

        for (int i = 0; i < 10; i++)
        {
            int topScore = PlayerPrefs.GetInt("topScore" + i);
            string topPseudo = PlayerPrefs.GetString("topPseudo" + i);

            if (newBestScore == -1)
            {
                PlayerPrefs.DeleteKey("topScore" + i);
                PlayerPrefs.DeleteKey("topPseudo" + i);
                PlayerPrefs.SetInt("topScore" + i, oldBestScore);
                PlayerPrefs.SetString("topPseudo" + i, oldBestScorer);

                oldBestScore = topScore;
                oldBestScorer = topPseudo;
            }
            else if (newBestScore < PlayerPrefs.GetInt("topScore" + i))
            {
                oldBestScore = topScore;
                oldBestScorer = topPseudo;

                PlayerPrefs.DeleteKey("topScore" + i);
                PlayerPrefs.DeleteKey("topPseudo" + i);
                PlayerPrefs.SetInt("topScore" + i, newBestScore);
                PlayerPrefs.SetString("topPseudo" + i, inputField.text == "" ? "noName" : inputField.text.ToUpper());
                newBestScore = -1;
            }

            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("Leaderboard");
    }
}