using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interaksi_Puzzle : MonoBehaviour
{
    [SerializeField] public GameObject customButton;

    void OnTriggerEnter(Collider other)
    {
       
        
            customButton.SetActive(true);
            Debug.Log("Do something here");

        
    }
     void OnTriggerExit(Collider other)
    {
     
        
            customButton.SetActive(false);
        
    }
}
