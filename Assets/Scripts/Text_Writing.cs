using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Text_Writing : MonoBehaviour
{
    [TextArea]
    public string text_to_write;

    // Update is called once per frame
    void Update()
    {
        if (this.enabled == true) {
            Text textUI = GetComponent<Text>();
            if(textUI.text == "")
            {
                StopAllCoroutines();
                StartCoroutine(typeDialog(textUI));
            }
        }
    }

    IEnumerator typeDialog(Text textUI)
    {
        textUI.text = "";
        foreach (string text_splited in text_to_write.Split('|'))
        {
            textUI.text += '\n';
            foreach (char charac in text_splited)
            {
                textUI.text += charac;
                yield return new WaitForSeconds(0.025f);
            }
            yield return new WaitForSeconds(2.5f);
        }
    }
}
