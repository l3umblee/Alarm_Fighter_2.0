using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyButton : MonoBehaviour
{
    public void OnClick()
    {
        Managers.Scene.LoadScene("TimeScene_main");
        Debug.Log("Clicked!");
    }
}
