using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailougeManager : MonoBehaviour
{
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    public void StartDailouge(Dailouge dailouge)
    {
  Debug.Log ("Starting Converstaion with" +  dailouge.name);
        sentences.Clear();

        foreach (string sentence in dailouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
    DisplayNextSentence ();
    }

    public void DisplayNextSentence()
    {
        if 

            (sentences.Count == 0)
        {
            EndDaoilouge();
            return;
        }

        string sentence = sentences.Dequeue ();
        Debug.Log(sentence);
    }

    void EndDaoilouge()
    {
        Debug.Log("End of conversation");
    }
}
