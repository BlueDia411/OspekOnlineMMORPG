using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateriDosen1 : MonoBehaviour
{
     public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject panel;

    public void Close()
    {
        panel.SetActive(false);
    }

    public void next1()
    {
        text2.SetActive(true);
        text1.SetActive(false);
    }

    public void next2()
    {
        text3.SetActive(true);
        text2.SetActive(false);
    }
    public void next3()
    {
        text4.SetActive(true);
        text3.SetActive(false);
    }

    public void Prev2()
    {
        text1.SetActive(true);
        text2.SetActive(false);
    }
    public void Prev3()
    {
        text2.SetActive(true);
        text3.SetActive(false);
    }
    public void Prev4()
    {
        text3.SetActive(true);
        text4.SetActive(false);
    }
}
