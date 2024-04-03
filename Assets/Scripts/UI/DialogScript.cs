using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogScript : MonoBehaviour
{
    private bool isInRange;
    private bool dialogLaunched;

    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogTextContent;
    [SerializeField] private TextMeshProUGUI dialogTextName;

    [SerializeField] private string dialogName;
    [SerializeField] private string dialogContent;

    [SerializeField] private UnityEvent endOfDialog;

    [SerializeField] private GameObject indication;

    [SerializeField] private AudioClip dialog;

    [SerializeField] private Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange && !dialogLaunched) LaunchDialog();
        if (Input.GetKeyDown(KeyCode.E) && dialogLaunched) StopDialog();
    }

    private void ManageAnimation(bool activation)
    {
        if(indication != null) indication.SetActive(activation);
        if (animator != null)  animator.SetBool("talking", activation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ManageAnimation(true);
        isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ManageAnimation(false);
        isInRange = false;
    }

    private void LaunchDialog()
    {
        SwitchingState(true);
        AudioManager.Instance.PlayDialog(dialog);
        PlayerMovement.instance.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
            dialogLaunched = true;
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
