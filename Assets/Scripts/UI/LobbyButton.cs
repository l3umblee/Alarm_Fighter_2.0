using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyButton : MonoBehaviour
{
    public void OnClick()
    {
        Managers.Scene.Clear();
        Managers.Scene.LoadScene(Define.GameSceneOrder.TimeScene_main.ToString());        
    }
}
