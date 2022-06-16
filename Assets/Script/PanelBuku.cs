using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBuku : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelAlgoritma;
    public GameObject panelWebDasar;
    public GameObject panelKomputer;
    public GameObject panelDpp;
    public GameObject panelDosen1;
    public GameObject ppk;
    public GameObject web;
    public GameObject infra;
    public GameObject prosedur;
    public GameObject dosen;
    
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject[] array;

    public void bukuClick()
    {
        panel.SetActive(true);
    }

    public void PPK()
    {
        ppk.SetActive(true);
        web.SetActive(false);
        infra.SetActive(false);
        prosedur.SetActive(false);
        dosen.SetActive(false);
    }

    public void Web()
    {
        ppk.SetActive(false);
        web.SetActive(true);
        infra.SetActive(false);
        prosedur.SetActive(false);
        dosen.SetActive(false);
    }

    public void Infra()
    {
        ppk.SetActive(false);
        web.SetActive(false);
        infra.SetActive(true);
        prosedur.SetActive(false);
        dosen.SetActive(false);
    }

    public void Prosedur()
    {
        ppk.SetActive(false);
        web.SetActive(false);
        infra.SetActive(false);
        prosedur.SetActive(true);
        dosen.SetActive(false);
    }

    public void Dosen()
    {
        ppk.SetActive(false);
        web.SetActive(false);
        infra.SetActive(false);
        prosedur.SetActive(false);
        dosen.SetActive(true);
    }





    public void algoritma()
    {
        panelAlgoritma.SetActive(true);
    }
    public void WebDasar()
    {
        panelWebDasar.SetActive(true);
    }
    public void Komputer()
    {
        panelKomputer.SetActive(true);
    }
    public void DPP()
    {
        panelDpp.SetActive(true);
    }
    public void Dosen1()
    {
        panelDosen1.SetActive(true);
    }
    public void tutupPanelBuku()
    {
        panel.SetActive(false);
    }
    public void tutupAlgoritma()
    {
        panelAlgoritma.SetActive(false);
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
    public void next4()
    {
        text5.SetActive(true);
        text4.SetActive(false);
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
    public void Prev5()
    {
        text4.SetActive(true);
        text5.SetActive(false);
    }

}
