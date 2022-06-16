using LitJson;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;

public class DialogueManager : MonoBehaviour
{
    public Text textDisplay;
    public GameObject rawImage;
    public GameObject[] buttons;
    public GameObject spaceButton;

    private JsonData dialogue2;
    private JsonData currentDialog;
    private int index;
    private string speaker;
    public bool inDialogue;
    private bool loadedDialog;
    private bool introDialog;

    //Anim 
    private Animator animator;

    private float distance;

    public void Api() => StartCoroutine(getApi());
    IEnumerator getApi()
    {
        deactiveButton();
        index = 0;
       string uri = "https://my-json-server.typicode.com/denyAndriana0107/Dialogues/dialogues/";
        if (!inDialogue)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();
                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    dialogue2 = JsonMapper.ToObject(request.downloadHandler.text);
                    currentDialog = dialogue2;
                    inDialogue = true;
                    loadedDialog = true;
                    
                }  
            }
        }
    }
    public void printLine()
    {
        if (loadedDialog == false)
        {
                Api();  
            
        }
        else
        {

            if (inDialogue)
            {
                rawImage.SetActive(true);
                JsonData line = currentDialog[index];
                foreach (JsonData key in line.Keys)
                    speaker = key.ToString();


                 if(speaker == "Mahasiswa" || speaker == "Dosen")
                {
                    textDisplay.text = speaker + " : " + line[0].ToString();
                    index++;
                }
                else if (speaker == "?")
                {
                    JsonData options = line[0];
                    textDisplay.text = "";
                    for (int optionNumber = 0; optionNumber < options.Count; optionNumber++)
                    {
                        activeButton(buttons[optionNumber], options[optionNumber]);
                    }
                }
                else if (speaker == "END")
                {
                    inDialogue = false;
                    textDisplay.text = "";
                    currentDialog = null;
                    loadedDialog = false;
                    introDialog = false;
                    inDialogue = false;
                    rawImage.SetActive(false);
                    return;
                }
               
                
            }
            
        }

       
    }

    private void deactiveButton()
    {  
        foreach(GameObject button in buttons)
        {
            button.SetActive(false);
            button.GetComponentInChildren<Text>().text = "";
            button.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
    private void activeButton(GameObject button,JsonData choise) {
        rawImage.SetActive(false);
        button.SetActive(true);
        button.GetComponentInChildren<Text>().text = choise[0][0].ToString();
        button.GetComponent<Button>().onClick.AddListener(
                delegate { buttonOnclick(choise);
            });
    }

    private void buttonOnclick(JsonData choise)
    {
        currentDialog = choise[0];
        index = 1;
        printLine();
        deactiveButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        rawImage.SetActive(false);
        deactiveButton();
        animator = GetComponent<Animator>();
    }

    //// Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
      
        if (distance <= 5)
        {
            textDisplay.text = "Tekan Space untuk berdialog";
            spaceButton.SetActive(true);
            
            spaceButton.GetComponent<Button>().onClick.AddListener(

                    delegate
                    {
                        printLine();
                      
                    }
              
                  
              );

        }
        else if(distance>5)
        {
            spaceButton.SetActive(false);
            rawImage.SetActive(false);
            introDialog = false;
            textDisplay.text = "";
            inDialogue = false;
        }




        
    }
}
