using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;

public class addQuiz : MonoBehaviour
{
    public InputField idIF;
    public InputField pertanyaanIF;
    public InputField waktuIF;
    public Text showAlltxt;
    public Dropdown jenisMatkul;
    public GameObject tambahMenu;
    public GameObject ubahMenu;

    //URLs
    readonly string URL = "https://materigame.herokuapp.com/public/quiz/cari";
    readonly string showAll = "https://materigame.herokuapp.com/public/quiz/show";
    readonly string URLtambah = "https://materigame.herokuapp.com/public/quiz/tambah";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(show());
    }

    public void cari() {
        StartCoroutine(cariID());
    }

    public void ubah() {
        StartCoroutine(updatePertanyaan(pertanyaanIF.text));
    }

    public void tambah()
    {
        StartCoroutine(tambahPertanyaan());
    }

    public void showTambah()
    {
        tambahMenu.SetActive(true);
        ubahMenu.SetActive(false);
    }

    public void showUbah()
    {
        tambahMenu.SetActive(false);
        ubahMenu.SetActive(true);
    }


    //
    IEnumerator cariID() {
        WWWForm form = new WWWForm();
        form.AddField("id", idIF.text);
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) {
            yield return www.SendWebRequest();
            JSONNode quizInfo = JSON.Parse(www.downloadHandler.text);
            string id = quizInfo["id"];
            DBManager.updateQuiz = "https://materigame.herokuapp.com/public/quiz/update/" + id + "";
            string quiz = quizInfo["pertanyaan"];
            pertanyaanIF.text = quiz.ToString();
        }
    }

    IEnumerator updatePertanyaan(string pertanyaan)
    {
        WWWForm form = new WWWForm();
        form.AddField("pertanyaan", pertanyaan);
        UnityWebRequest www = UnityWebRequest.Post(DBManager.updateQuiz, form);
        yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Ubah Berhasil!");
            }
    }

    IEnumerator tambahPertanyaan()
    {
        WWWForm form = new WWWForm();
        form.AddField("pertanyaan", pertanyaanIF.text);
        form.AddField("waktu", waktuIF.text);
        form.AddField("jenis_materi", jenisMatkul.options[jenisMatkul.value].text);
        using (UnityWebRequest www = UnityWebRequest.Post(URLtambah, form))
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



    IEnumerator show() {
        UnityWebRequest www = UnityWebRequest.Get(showAll);
        yield return www.SendWebRequest();
        showAlltxt.text = www.downloadHandler.text;
    }
}
