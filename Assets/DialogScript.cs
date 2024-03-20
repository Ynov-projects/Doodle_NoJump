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

    [SerializeField] private Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange && !dialogLaunched) LaunchDialog();
        if (Input.GetKeyDown(KeyCode.E) && dialogLaunched) StopDialog();
    }

    private void ManageAnimation(bool activation)
    {
        indication.SetActive(activation);
        animator.SetBool("talking", activation);
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
        ManageAnimation(false);

        dialogPanel.SetActive(true);
        dialogTextContent.text = "";

        dialogTextName.text = dialogName;
        char[] letters = dialogContent.ToCharArray();
        StartCoroutine(WriteDialog(letters));
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
        ManageAnimation(true);
     
        StopAllCoroutines();

        dialogPanel.SetActive(false);
        dialogTextContent.text = "";

        dialogLaunched = false;
        endOfDialog.Invoke();
    }
}
