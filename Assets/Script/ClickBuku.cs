using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBuku : MonoBehaviour
{
    public GameObject customButton;
    public GameObject panelBuku;
    public GameObject buku;
    public GameObject bukuAlgoritma;

    void OnTriggerStay(Collider other)
    {
        customButton.SetActive(true);      
    }

    public void AmbilBuku()
    {
        Destroy(buku);
        customButton.SetActive(false);  
        // bukuAlgoritma.SetActive(true);
    }
}
