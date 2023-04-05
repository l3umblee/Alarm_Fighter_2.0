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

    public void ClickQuit()
    {
        Managers.Game.QuitGame();
    }
    public void ClickScan()
    {
        GetComponent<LobbyUI>().SetState((int)LobbyState.Scan);
    }

    public void LoadStage(Define.GameSceneOrder stage)
    {
        //
    }
}
