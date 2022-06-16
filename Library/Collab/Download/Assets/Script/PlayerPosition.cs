using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;

public class PlayerPosition : MonoBehaviour
{
    public GameObject player;
    public Text nickname;
    public Text Level;
    public Text Semester;

    public float x, y, z;
    //string xPos, yPos, zPos;
    string json;

    readonly string getURL = "https://materigame.herokuapp.com/public/position/show/1";
    readonly string postUrl = "https://materigame.herokuapp.com/public/position/update/1";
    private void Awake()
    {
        Load();
    }

    void Start()
    {

    }


    void Update()
    {
        Save();
    }

    void Load()
    {
        StartCoroutine(LoadCourutine());
    }

    void Save()
    {
        //Vector3 playerPos = player.transform.position;
        //Debug.Log(playerPos);

        //SaveObject saveObject = new SaveObject {
        //    playerPos = playerPos
        //};
        //json = JsonUtility.ToJson(saveObject);
        //Debug.Log(json);

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        StartCoroutine(UpdatePosition(x, y, z));
    }

    IEnumerator LoadCourutine()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURL);
        yield return www.SendWebRequest();
        //Debug.Log(www.downloadHandler.text);
        JSONNode charInfo = JSON.Parse(www.downloadHandler.text);
        string name = charInfo["name"];
        float korX = charInfo["x"];
        float korY = charInfo["y"];
        float korZ = charInfo["z"];



        nickname.text = name;
        Vector3 LoadPosition = new Vector3(korX, korY, korZ);
        transform.position = LoadPosition;

    }

    IEnumerator UpdatePosition(float x, float y, float z)
    {
        WWWForm form = new WWWForm();
        form.AddField("x", x.ToString());
        form.AddField("y", y.ToString());
        form.AddField("z", z.ToString());
        UnityWebRequest www = UnityWebRequest.Post(postUrl, form);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Upload complete!");
        }
    }
}
