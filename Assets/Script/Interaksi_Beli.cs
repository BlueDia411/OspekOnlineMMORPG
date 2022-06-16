using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaksi_Beli : MonoBehaviour
{
  
    public GameObject CanvasBeli;
   
   
    bool isPressed;
    

    void Start()
    {
        isPressed = false;
        
        

    }

    void Update()
    {
        // if (isPressed ){
            
        //     CanvasBeli.SetActive(true);
           
            

        // }
        // // else {
            
        // //     CanvasBeli.SetActive(false);
         
            

        // // }
    }

    public void OnPointerDown()
    {
        isPressed = true;
        CanvasBeli.SetActive(true);
        
    }

    public void OnPointerUp()
    {
        isPressed = false;
        
    }

    
}
