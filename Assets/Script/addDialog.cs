using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;
public class addDialog : MonoBehaviour
{
    public InputField dialogIF;
    readonly string URL = "https://materigame.herokuapp.com/public/dialog/tambah";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tambah() {
        StartCoroutine(tambahDialog());
    }

    IEnumerator tambahDialog() {
        WWWForm form = new WWWForm();
        form.AddField("dialog", dialogIF.text);
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Tambah Berhasil!");
            }
        }
    }
}
