using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPanel : MonoBehaviour
{
    public void OnAbortButton()
    {
        gameObject.SetActive(false);
    }

    public void OnJumpGame()
    {
        string url = "https://www.jeuxmariogratuits.fr/jeux-mario-apocalypse.php";
        Application.OpenURL(url);
    }
}
