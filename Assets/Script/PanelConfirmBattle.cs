using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelConfirmBattle : MonoBehaviour
{

    [SerializeField] public GameObject canvasBattle;
    public string sceneName;
    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInteraksiDown()
    {
        canvasBattle.SetActive(true);
    }
    public void OnPointerExitDown()
    {
        // isPressed = true;
        canvasBattle.SetActive(false);
        
    }
    public void OnPointerIyaDown()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnPointerUp()
    {
        isPressed = false;
        
    }

}
