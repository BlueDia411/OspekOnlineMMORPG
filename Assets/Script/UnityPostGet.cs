using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;

public class UnityPostGet : MonoBehaviour
{
    public TextMeshProUGUI NamaNPC;
    private readonly string url = "https://materigame.herokuapp.com/public/npc";
    private void Start()
    {
        NamaNPC.text = "";
    }

}
