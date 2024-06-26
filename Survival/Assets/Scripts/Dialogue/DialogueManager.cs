using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject GameCanvas;
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
        GameCanvas.SetActive(false);
        backgroundBox.LeanScale(Vector3.one, 0.7f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length) 
        {
            DisplayMessage();
        } else
        {
            Debug.Log("Conversation eneded!");
            backgroundBox.LeanScale(Vector3.zero, 0.7f).setEaseInOutExpo();
            isActive = false;
            GameCanvas.SetActive(true);
        }
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);

    }

    public void CloseDialogue()
    {
        backgroundBox.LeanScale(Vector3.zero, 0.7f).setEaseInOutExpo();
        GameCanvas.SetActive(true);
    }

    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) &&isActive == true)
        {
            NextMessage();
        }
    }
}
