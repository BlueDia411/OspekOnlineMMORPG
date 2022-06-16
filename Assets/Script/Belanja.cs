using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Belanja : MonoBehaviour
{
    [SerializeField] public GameObject customButton;

    void OnTriggerEnter(Collider other)
    {
       
        
            customButton.SetActive(true);
           

        
    }
     void OnTriggerExit(Collider other)
    {
     
        
            customButton.SetActive(false);
        
    }
}
