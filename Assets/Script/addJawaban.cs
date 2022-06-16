using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;


public class addJawaban : MonoBehaviour
{
    public InputField idIF;
    public InputField jawabanIF;
    public InputField correctIF;
    public Text showAlltxt;
    public Text showPertanyaan;
    public Dropdown correct;
    public GameObject tambahMenu;
    public GameObject ubahMenu;

    //URLs
    readonly string URL = "https://materigame.herokuapp.com/public/jawaban/cari";
    readonly string showAll = "https://materigame.herokuapp.com/public/jawaban/show";
    readonly string URLtambah = "https://materigame.herokuapp.com/public/jawaban/tambah";
    readonly string URLquiz = "https://materigame.herokuapp.com/public/quiz/cari";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(show());
    }

    //button
    public void cari()
    {
        StartCoroutine(cariID());
    }

    public void cariPertanyaan() {
        StartCoroutine(cariIDpertanyaan());
    }

    public void ubah()
    {
        StartCoroutine(updateJawaban());
    }

    public void tambah()
    {
        StartCoroutine(tambahJawaban());
    }

    //show
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


    //enumerator
    IEnumerator cariID()
    {
        WWWForm form = new WWWForm();
        form.AddField("id_jawaban", idIF.text);
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            JSONNode jawabanInfo = JSON.Parse(www.downloadHandler.text);
            string id = jawabanInfo["id_jawaban"];
            DBManager.updateJawaban = "https://materigame.herokuapp.com/public/jawaban/update/" + id + "";
            string jawaban = jawabanInfo["jawaban"];
            jawabanIF.text = jawaban.ToString();
            string correct = jawabanInfo["correct"];
            correctIF.text = correct;
            

            string id_quiz = jawabanInfo["id_quiz"];
            DBManager.showQuizdiJawaban = "https://materigame.herokuapp.com/public/quiz/show/" + id + "";
            UnityWebRequest quiz = UnityWebRequest.Get(DBManager.showQuizdiJawaban);
            yield return quiz.SendWebRequest();
            JSONNode quizInfo = JSON.Parse(quiz.downloadHandler.text);
            string pertanyaan = quizInfo["pertanyaan"];
            showPertanyaan.text = pertanyaan;

        }

    }

    IEnumerator updateJawaban()
    {
        WWWForm form = new WWWForm();
        form.AddField("jawaban", jawabanIF.text);
        UnityWebRequest www = UnityWebRequest.Post(DBManager.updateJawaban, form);
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

    IEnumerator tambahJawaban()
    {
        WWWForm form = new WWWForm();
        form.AddField("jawaban", jawabanIF.text);
        form.AddField("correct", correct.options[correct.value].text);
        form.AddField("id_quiz", idIF.text);
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

    IEnumerator cariIDpertanyaan()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", idIF.text);
        Debug.Log(idIF.text);
        using (UnityWebRequest www = UnityWebRequest.Post(URLquiz, form))
        {
            yield return www.SendWebRequest();
            JSONNode quizInfo = JSON.Parse(www.downloadHandler.text);
            string quiz = quizInfo["pertanyaan"];
            showPertanyaan.text = quiz.ToString();
        }
    }

    IEnumerator show()
    {
        UnityWebRequest www = UnityWebRequest.Get(showAll);
        yield return www.SendWebRequest();
        showAlltxt.text = www.downloadHandler.text;

    }
}
