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
    public Text PlayerExp;
    public Text playerMoney;

    public float x, y, z;
    public int money, exp, semester, health;
    string json;


    private void Awake()
    {
        Load();
    }

    void Start()
    {
        InvokeRepeating("Save", 5f, 5f);
    }



    void Update()
    {
        float ry = transform.rotation.y;
    }

    void Load()
    {
        StartCoroutine(LoadCourutine());
    }

    void Save()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        StartCoroutine(UpdatePosition(x, y, z));
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
        float money = charInfo["money"];


        PlayerExp.text = exp.ToString();
        playerMoney.text = money.ToString();
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
        form.AddField("money", playerMoney.text);
        form.AddField("exp", PlayerExp.text);
        //form.AddField("health", health);
        //form.AddField("semster", semester);
        UnityWebRequest www = UnityWebRequest.Post(DBManager.postPlayerURLs, form);
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
