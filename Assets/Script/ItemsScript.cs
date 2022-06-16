using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsScript : MonoBehaviour
{
    public GameObject penambahHealth;
    public CharLevelUp charLevelUp;
    public GameObject panelUangTidakCukup;
    public GameObject panelInventory;
    public GameObject berhasilBeli;
  
    
    public void beliPenambahHealth()
    {
        if(charLevelUp.uang >= 5000)
        {
            penambahHealth.SetActive(true);
            StartCoroutine("panelBerhasilBeli");
            
            charLevelUp.uang -= 5000;
        }if(charLevelUp.uang <5000)
        {
            StartCoroutine("UangTidakCukup");
            penambahHealth.SetActive(false);
        }
        
    }

    IEnumerator UangTidakCukup()
     {
        panelUangTidakCukup.SetActive(true);
        yield return new WaitForSeconds(2);
        panelUangTidakCukup.SetActive(false);
     }
    IEnumerator panelBerhasilBeli()
     {
        berhasilBeli.SetActive(true);
        yield return new WaitForSeconds(2);
        berhasilBeli.SetActive(false);
     }

     public void Exit()
     {
         panelInventory.SetActive(false);
     }

     public void Open()
     {
         panelInventory.SetActive(true);
     }

    
}
