using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passField;
    public Button submitButton;
    public TMP_Text confirm;
    public string namescene;

    readonly string URL = "https://materigame.herokuapp.com/public/position/login";
    public void CallLogin() {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer() {
        WWWForm form = new WWWForm();
        form.AddField("email", emailField.text);
        form.AddField("password", passField.text);
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            JSONNode charInfo = JSON.Parse(www.downloadHandler.text);
            string id = charInfo["id"];
            if (www.result != UnityWebRequest.Result.Success)
            {
                confirm.text = www.error + " Email Atau Password salah";
            }
            else
            {
                
                DBManager.getPlayerURLs = "https://materigame.herokuapp.com/public/position/show/" + id + "";
                DBManager.postPlayerURLs = "https://materigame.herokuapp.com/public/position/update/" + id + "";
                SceneManager.LoadScene(namescene);

            }
        }
    }

}
