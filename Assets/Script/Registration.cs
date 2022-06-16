using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public Text condition;

    public Button submitButton;
    readonly string URL = "https://materigame.herokuapp.com/public/position/create";

    public void CallRegister() {
        StartCoroutine(Register());
    }

    IEnumerator Register() {
        WWWForm form = new WWWForm();
        form.AddField("email", emailField.text);
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("x", 2);
        form.AddField("y", 0.3888845.ToString());
        form.AddField("z", 2);
        form.AddField("money", 1);
        form.AddField("health", 100);
        form.AddField("level", 1);
        form.AddField("exp", 1);
        form.AddField("semester", 1);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                condition.text = www.error + " Email Telah digunakan";
            }
            else
            {
                condition.text = "Registrasi Berhasil";
            }
        }   
    }



}
