using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_Interaksi_Puzzle : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
   public void Scene1() {
       SceneManager.LoadScene(sceneName);
   }
   

    
}
