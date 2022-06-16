using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExit : MonoBehaviour
{
    public GameObject CanvasBeli;
   
   
    bool isPressed;
    

    void Start()
    {
        isPressed = false;

    }

    // void Update()
    // {
    //     if (isPressed ){
            
    //         CanvasBeli.SetActive(false);
           
            
           
    //     }
    //     // else {
            
    //     //     isPressed = false;
         
         
    //     // }
    // }

    public void OnPointerDown()
    {
        // isPressed = true;
        CanvasBeli.SetActive(false);
        
    }

    public void OnPointerUp()
    {
        isPressed = false;
        
    }
}
