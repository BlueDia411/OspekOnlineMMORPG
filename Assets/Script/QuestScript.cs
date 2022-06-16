using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public GameObject smallPanel;
    public GameObject bigPanel;
    public GameObject btnSelesai;
    public GameObject btnRincian;
    public GameObject panelTerimaKasih;
    public CharLevelUp charlevelUp;

    void Start()
    {
        // charlevelUp = GetComponent<CharLevelUp>();
        charlevelUp = FindObjectOfType<CharLevelUp>();
    }

    void Update()
    {
        if(charlevelUp.stat == true)
        {
            btnSelesai.SetActive(true);
            btnRincian.SetActive(false);
        }
    }

    public void KlikQuest()
    {
        smallPanel.SetActive(true);
    }

    public void Rincian()
    {
        smallPanel.SetActive(false);
        bigPanel.SetActive(true);
    }

    public void Close()
    {
        bigPanel.SetActive(false);
        panelTerimaKasih.SetActive(false);
    }

    public void TerimaKasih()
    {
        panelTerimaKasih.SetActive(true);
        smallPanel.SetActive(false);
    }
}
