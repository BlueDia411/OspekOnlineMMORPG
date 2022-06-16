using LitJson;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;

public class DialogueManagerPenjualBatagor : MonoBehaviour
{
    public Text textDisplay;
    public GameObject[] buttons;
    public RawImage rawImage;

    private JsonData dialogue2;
    private JsonData currentDialog;
    private int index;
    private string speaker;

    public bool inDialogue;
    private bool loadedDialog;
    public bool introDialog;


    public Button buttonSpace;
    
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

                JsonData line = currentDialog[index];
                foreach (JsonData key in line.Keys)
                    speaker = key.ToString();

                if (speaker == "END")
                {
                    inDialogue = false;
                    index = 0;
                    textDisplay.text = "";
                    loadedDialog = false;
                    introDialog = false;
                    buttonSpace.onClick.RemoveAllListeners();
                    deactiveRawImage();
                    return;
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
                else
                {
                    activeRawImage();
                    textDisplay.text = speaker + " : " + line[0].ToString();
                    index++;
                }

            }
        }


    }

    private void deactiveButton()
    {
        
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
            button.GetComponentInChildren<Text>().text = "";
            button.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
    private void activeButton(GameObject button, JsonData choise)
    {
        deactiveRawImage();
        button.SetActive(true);
        button.GetComponentInChildren<Text>().text = choise[0][0].ToString();
        button.GetComponent<Button>().onClick.AddListener(
                delegate {
                    buttonOnclick(choise);
                });
    }

    private void buttonOnclick(JsonData choise)
    {
        currentDialog = choise[0];
        index = 1;
        printLine();
        deactiveButton();
    }
    private void deactiveRawImage()
    {
        rawImage.gameObject.SetActive(false);
    }
    private void activeRawImage()
    {
        rawImage.gameObject.SetActive(true);
    }



    // Start is called before the first frame update
    void Start()
    {
        deactiveButton();
        deactiveRawImage();
    }

    //// Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);

        if (distance <= 7 && introDialog == false)
        {
            buttonSpace.gameObject.SetActive(true);
            introDialog = true;
            buttonSpace.onClick.AddListener(
                    delegate ()
                    {
                        printLine();
                    }

                  );

         


        }
        else if (distance > 7)
        {
            buttonSpace.gameObject.SetActive(false);
            inDialogue = false;
            index = 0;
            textDisplay.text = "";
            loadedDialog = false;
            introDialog = false;
            buttonSpace.onClick.RemoveAllListeners();
            deactiveRawImage();
            deactiveButton();
        }






    }
}
