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

    public Timer timer1;
    public bool autoContinue;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkFile.text);
        dialogue = textBox.transform.GetChild(0).GetComponent<Text>();
        if (story.canContinue)
        {
            AdvanceDialogue();
        }

        autoContinue = true;
        timer1 = gameObject.AddComponent<Timer>();
        timer1.time = 3.0f;
        timer1.onTimerFinished += OnTimerDone;
        timer1.StartTimer();
    }

    private void FinishDialogue()
    {
        this.gameObject.SetActive(false);
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

    private void OnTimerDone()
    {
        if (story.canContinue)
        {
            AdvanceDialogue();
            timer1.StartTimer();
        }
        else
        {
            FinishDialogue();
        }
    }
}
