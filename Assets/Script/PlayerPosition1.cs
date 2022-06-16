using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition1 : MonoBehaviour
{
    public GameObject player;
    public GameObject playerr;

    float rx;
    float ry;
    float rz;

    // Start is called before the first frame update
    void Start()
    {
       LoadPosition();
       LoadRotation();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);

        PlayerPrefs.SetFloat("RotationX", playerr.transform.eulerAngles.x);
        PlayerPrefs.SetFloat("RotationY", playerr.transform.eulerAngles.y);
        PlayerPrefs.SetFloat("RotationZ", playerr.transform.eulerAngles.z);
        SaveRotation();
        // PlayerPrefs.Update();
    }

    public void SaveRotation()
    {
        rx = PlayerPrefs.GetFloat("RotationX");
        ry = PlayerPrefs.GetFloat("RotationY");
        rz = PlayerPrefs.GetFloat("RotationZ");
        
      
    }

    public void LoadPosition()
    {
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        
    }

    public void LoadRotation()
    {
        playerr.transform.rotation = Quaternion.Euler(rx, ry, rz);
    }
}
