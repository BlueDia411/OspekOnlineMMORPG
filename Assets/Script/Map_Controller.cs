using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mapTampil;
    bool isPressed;

    void Start()
    {
        isPressed = false;
        mapTampil.SetActive(false);
    }

    // Update is called once per frame
    public void OnPointerDown()
    {
        isPressed = true;
        mapTampil.SetActive(true);
        
    }

    public void OnPointerUp()
    {
        isPressed = false;
        mapTampil.SetActive(false);
        
    }
}
