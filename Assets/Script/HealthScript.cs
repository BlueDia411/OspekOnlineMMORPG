using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class HealthScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int healthh;
    public GameObject batagor;

    private void Awake()
    {
        StartCoroutine(LoadPlayerInfo());
    }

    private void Start()
    {
        // health = PlayerPrefs.GetInt("mainHealth");
        // slider.value = health;
        SetMaxHealth(100);
        //healthh = healthh;
        Debug.Log(healthh);
        SetHealth(healthh);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {
        slider.value = health;
        PlayerPrefs.SetInt("mainHealth", health);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void ClickResetHealth()
    {
        SetHealth(100);
        Debug.Log("berhasil reset health");
        batagor.SetActive(false);
    }

    IEnumerator LoadPlayerInfo()
    {
        UnityWebRequest www = UnityWebRequest.Get(DBManager.getPlayerURLs);
        yield return www.SendWebRequest();
        JSONNode charInfo = JSON.Parse(www.downloadHandler.text);
        int healthDB = charInfo["health"];
        healthh = healthDB;
    }
}
