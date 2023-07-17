using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using System;


public class Dialogue : MonoBehaviour
{
    public TextAsset inkFile;
    public GameObject textBox;

    static Story story;
    Text dialogue;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkFile.text);
        dialogue = textBox.transform.GetChild(0).GetComponent<Text>();
        if (story.canContinue)
        {
            AdvanceDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (story.canContinue)
            {
                AdvanceDialogue();
            }
            else
            {
                FinishDialogue();
            }
        }
    }

    private void FinishDialogue()
    {
        Debug.Log("all done with dialogue!");
    }

    private void AdvanceDialogue()
    {
        string currentSentence = story.Continue();
        StopAllCoroutines();
        StartCoroutine(TypeSentences(currentSentence));
    }

    IEnumerator TypeSentences(string sentence)
    {
        dialogue.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return null;
        }
        yield return null;
    }
}
