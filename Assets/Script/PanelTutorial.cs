using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTutorial : MonoBehaviour
{
    //  public GameObject panel;
    // public GameObject panelAlgoritma;
    
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public int stat;
    int value;
 
    void Start()
    {
        text1.SetActive(true);

        if(stat == 1)
        {
            value = PlayerPrefs.GetInt("text1panel");
        } else if(stat == 0)
        {
            PlayerPrefs.SetInt("text1panel", 0);
        }
        
    }

    void Update()
    {
        if(value == 1)
        {
            text1.SetActive(false);
        }
        // else if(value == 0)
        // {
        //     text1.SetActive(true);
        // }
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
        PlayerPrefs.SetInt("text1panel", stat);
    }

    public void next3()
    {
        text4.SetActive(true);
        text3.SetActive(false);
    }
    public void next4()
    {
        text5.SetActive(true);
        text4.SetActive(false);
    }
    public void next5()
    {
        text6.SetActive(true);
        text5.SetActive(false);
    }

    public void next6()
    {
        text6.SetActive(false);
        
    }
    
   

}
