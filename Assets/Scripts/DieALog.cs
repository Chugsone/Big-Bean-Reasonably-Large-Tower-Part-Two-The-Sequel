using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.InputSystem;

[Serializable] public struct DialoguePiece
{
    public string name;
    [TextArea] public string dialogue;

}
public class DieALog : MonoBehaviour
{
    
    public List<DialoguePiece> dialogue;
    public float textSpeed;

    public TMPro.TMP_Text dialogueName;
    public TMPro.TMP_Text dialogueText;
    public GameObject me;
    private int dialogueIndex;
    private bool isDialogueRunning;

    public void StartDialogue()
    {
        me.SetActive(true);
        dialogueIndex = 0;
        Debug.Log("I am working. Hip hip hooray");

        StartCoroutine(WriteDialoguePiece(dialogue[0]));
    }

    public void StopDialogue()
    {
        me.SetActive(false);
    }

    public void NextDialogueOrStop(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0 || isDialogueRunning)
            return;

        ++dialogueIndex;

        if (dialogueIndex >= dialogue.Count)
        {
            StopDialogue();
            return;
        }
        StartCoroutine(WriteDialoguePiece(dialogue[dialogueIndex]));
    }


    public IEnumerator WriteDialoguePiece(DialoguePiece dialogue)
    {
        dialogueName.SetText(dialogue.name);
        dialogueText.text = "";

        isDialogueRunning = true;

        for (int i = 0; i < dialogue.dialogue.Length; ++i)
        {

            dialogueText.text += dialogue.dialogue[i];
            yield return new WaitForSeconds(textSpeed);
        }

        isDialogueRunning = false;
    }
}