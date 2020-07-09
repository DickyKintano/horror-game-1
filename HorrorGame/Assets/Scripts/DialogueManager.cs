using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public GameObject dialogueUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private bool dialogueActive = false;
    

    // Start is called before the first frame update
    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (dialogueActive && Input.GetButtonDown("NextDialogue"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue, bool active)
    {
        dialogueActive = active;

        nameText.text = dialogue.name;

        sentences.Clear();

        dialogueUI.SetActive(true);

        Time.timeScale = 0;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
        } else
        {
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;

        }
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
        Time.timeScale = 1;
        dialogueActive = false;
        Debug.Log("end dialogue");
    }
}
