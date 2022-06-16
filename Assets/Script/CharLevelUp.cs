using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class CharLevelUp : MonoBehaviour
{
    public int exp;
    public Text expText;
    public int uang;
    public Text uangText;
    public Text nickname;
    public GameObject levelUpBtn;
    public Image semester2;
    public GameObject panelLevelUp;
    public GameObject buttonClose;
    public GameObject btnTambahDarah;
    public bool stat;

    void Start()
    {
        StartCoroutine(LoadPlayerInfo());
        //exp = PlayerPrefs.GetInt("exp");
        uang = uang;
        //expText.text = exp.ToString();
        stat = false;
    }

    void Update()
    {
        
        // exp = quizManager.xp;
        expText.text = exp.ToString();
        uangText.text = uang.ToString();
        if(exp < 3500 && uang <11000)
        {
            levelUpBtn.SetActive(false);
            semester2.enabled = false;
           
        }
        if(exp >= 3500 && uang >= 11000)
        {
            levelUpBtn.SetActive(true);
           
        }
    }



    public void levelUp()
    {
        semester2.enabled = true;
        StartCoroutine("Selamat");
        uang -= 5000;
        stat = true;
        Debug.Log("stat true");
    }

    public void closePanel()
    {
        panelLevelUp.SetActive(false);
        levelUpBtn.SetActive(false);
    }

    public void setExp(int expp)
    {
        exp = exp + expp;
        StartCoroutine(UpdatePlayerExp(exp));
        //PlayerPrefs.SetInt("exp", exp);
        expText.text = exp.ToString();
        Debug.Log("set exp");
    }

    public void setUang(int uangg)
    {
        uang = uang + uangg;
        //PlayerPrefs.SetInt("uang", uang);
        StartCoroutine(UpdatePlayerMoney(uang));
        uangText.text = uang.ToString();
        Debug.Log("set uang");
    }

    public void ClickResetExp()
    {
        btnTambahDarah.SetActive(false);
        setExp(0);
        setUang(0);
        Debug.Log("berhasil reset exp");

    }

    IEnumerator Selamat()
     {
         levelUpBtn.SetActive(false);
        panelLevelUp.SetActive(true);
        yield return new WaitForSeconds(3);
        panelLevelUp.SetActive(false);
        
     }

    IEnumerator LoadPlayerInfo()
    {
        UnityWebRequest www = UnityWebRequest.Get(DBManager.getPlayerURLs);
        yield return www.SendWebRequest();
        JSONNode charInfo = JSON.Parse(www.downloadHandler.text);
        string name = charInfo["name"];
        int expDB = charInfo["exp"];
        int moneyDB = charInfo["money"];
        exp = expDB;
        uang = moneyDB;
        nickname.text = name;
    }

    IEnumerator UpdatePlayerMoney(int uang)
    {
        WWWForm form = new WWWForm();
        form.AddField("money", uang);
        //form.AddField("exp", exp);
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

    IEnumerator UpdatePlayerExp(int exp)
    {
        WWWForm form = new WWWForm();
        //form.AddField("money", uang);
        form.AddField("exp", exp);
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
