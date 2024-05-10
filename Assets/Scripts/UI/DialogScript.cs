using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DialogScript : MonoBehaviour
{
    private bool isInRange;
    private bool dialogLaunched;

    [SerializeField] private bool automaticLaunching;

    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogTextContent;
    [SerializeField] private TextMeshProUGUI dialogTextName;

    [SerializeField] private string dialogName;
    [SerializeField] private string dialogContent;

    [SerializeField] private UnityEvent endOfDialog;

    [SerializeField] private GameObject indication;

    [SerializeField] private AudioClip dialog;

    [SerializeField] private Animator animator;

    private void Update()
    {
        if ((GameManager.input.Gameplay.Interact.triggered || automaticLaunching) && isInRange && !dialogLaunched)
        {
            dialogLaunched = true;
            LaunchDialog();
        }
        else if (GameManager.input.Gameplay.Interact.triggered && dialogLaunched) StopDialog();
    }

    private void ManageAnimation(bool activation)
    {
        if (indication != null) indication.SetActive(activation);
        if (animator != null) animator.SetBool("talking", activation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.tag != "Untagged")
        {
            ManageAnimation(true);
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.tag != "Untagged")
        {
            ManageAnimation(false);
            isInRange = false;
        }
    }

    private void LaunchDialog()
    {
        PlayerMovement.instance.StopPlayer(true);
        SwitchingState(true);
        AudioManager.Instance.PlayDialog(dialog);
        dialogTextContent.text = "";
        dialogTextName.text = dialogName;
        char[] letters = dialogContent.ToCharArray();
        StartCoroutine(WriteDialog(letters));
    }

    // Permet d'activer ou non le dialogue
    private void SwitchingState(bool state)
    {
        dialogPanel.SetActive(state);
        ManageAnimation(!state);
        currentSceneManager.instance.canTeleport = !state;
    }

    private IEnumerator WriteDialog(char[] letters)
    {
        while (letters.Length > 0)
        {
            yield return new WaitForSeconds(0.02f);
            dialogTextContent.text += letters[0];
            letters = letters.Skip(1).ToArray();
        }
    }

    private void StopDialog()
    {
        SwitchingState(false);
        PlayerMovement.instance.enabled = true;
        StopAllCoroutines();
        AudioManager.Instance.StopDialog();

        dialogTextContent.text = "";
        dialogLaunched = false;
        endOfDialog.Invoke();
    }
}
