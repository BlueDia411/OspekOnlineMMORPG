using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;

public class getQuizFromDatabase : MonoBehaviour
{
    public string Pertanyaan;
    public string JawabanBenar;
    public string JawabanSalah1;
    public string JawabanSalah2;
    public Text pertanyaan;
    public Text Benar;
    public Text Salah1;
    public Text Salah2;
    // Start is called before the first frame update
    void Start()
    {
        DBManager.showPertanyaan = "https://materigame.herokuapp.com/public/quiz/show/"+Pertanyaan;
        DBManager.showJawabanBenar = "https://materigame.herokuapp.com/public/jawaban/show/" + JawabanBenar;
        DBManager.showJawabanSalah1 = "https://materigame.herokuapp.com/public/jawaban/show/" + JawabanSalah1;
        DBManager.showJawabanSalah2 = "https://materigame.herokuapp.com/public/jawaban/show/" + JawabanSalah2;
        StartCoroutine(PertanyaanQuiz());
        StartCoroutine(jawabanQuizBenar());
        StartCoroutine(jawabanQuizSalah1());
        StartCoroutine(jawabanQuizSalah2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PertanyaanQuiz() {
        UnityWebRequest www = UnityWebRequest.Get(DBManager.showPertanyaan);
        yield return www.SendWebRequest();
        JSONNode pertanyaanInfo = JSON.Parse(www.downloadHandler.text);
        string pertanyaanQuiz = pertanyaanInfo["pertanyaan"];
        pertanyaan.text = pertanyaanQuiz;
        
    }

    IEnumerator jawabanQuizBenar() {
        UnityWebRequest www = UnityWebRequest.Get(DBManager.showJawabanBenar);
        yield return www.SendWebRequest();
        JSONNode pertanyaanInfo = JSON.Parse(www.downloadHandler.text);
        string jawaban = pertanyaanInfo["jawaban"];
        Benar.text = jawaban;
    }

    IEnumerator jawabanQuizSalah1()
    {
        UnityWebRequest www = UnityWebRequest.Get(DBManager.showJawabanSalah1);
        yield return www.SendWebRequest();
        JSONNode pertanyaanInfo = JSON.Parse(www.downloadHandler.text);
        string jawaban = pertanyaanInfo["jawaban"];
        Salah1.text = jawaban;
    }
    IEnumerator jawabanQuizSalah2()
    {
        UnityWebRequest www = UnityWebRequest.Get(DBManager.showJawabanSalah2);
        yield return www.SendWebRequest();
        JSONNode pertanyaanInfo = JSON.Parse(www.downloadHandler.text);
        string jawaban = pertanyaanInfo["jawaban"];
        Salah2.text = jawaban;
    }
}
