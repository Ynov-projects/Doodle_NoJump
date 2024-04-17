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

    public void OnTalkInput(InputAction.CallbackContext context)
    {
        if ((context.performed || automaticLaunching) && isInRange && !dialogLaunched)
        {
            dialogLaunched = true;
            LaunchDialog();
        }
        else if (context.performed && dialogLaunched) StopDialog();
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
            Debug.Log(collision.gameObject.name);
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
        SwitchingState(true);
        AudioManager.Instance.PlayDialog(dialog);
        if(!automaticLaunching) PlayerMovement.instance.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
        PlayerMovement.instance.enabled = !state;
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
        StopAllCoroutines();
        AudioManager.Instance.StopDialog();

        dialogTextContent.text = "";
        dialogLaunched = false;
        endOfDialog.Invoke();
    }
}
