using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour


{

    public Dialogue dialogue;
    string text;

    public Text uiText;
    bool isWriting=true;
    public float timer;
    private float timePerChar =0.01f;
    private int charactorIndex;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isWriting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer += timePerChar;
                charactorIndex++;
                uiText.text = text.Substring(0, charactorIndex);
                if (charactorIndex >= text.Length)
                {

                    isWriting = false;
                    
                    return;

                }
            }
        }
    }

  public void StartDialogue(int weightdiff) {

        if (weightdiff > 0) { text = dialogue.sentences[0]; }
        else if (weightdiff < 0) { text = dialogue.sentences[1]; }
        else if (weightdiff == 0) { text = dialogue.sentences[2]; }

        CurrentStringSetter();

    }
    public void CurrentStringSetter()
    {
        
        
        uiText.text.Remove(0);
        charactorIndex = 0;

        isWriting = true;
    }

}
