using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using TMPro;

public class GM : MonoBehaviour
{
    public TMP_Text nickname;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Load()
    {
        StartCoroutine(LoadCourutine());
    }

    IEnumerator LoadCourutine()
    {
        UnityWebRequest www = UnityWebRequest.Get(DBManager.getPlayerURLs);
        yield return www.SendWebRequest();
        JSONNode charInfo = JSON.Parse(www.downloadHandler.text);
        string name = charInfo["name"];
        float korX = charInfo["x"];
        float korY = charInfo["y"];
        float korZ = charInfo["z"];
        float exp = charInfo["exp"];

        nickname.text = name;
    }
}
