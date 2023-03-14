using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class GameManagerEx
{
    public GameObject CurrentPlayer { get; set; }

    public void GameOver()      
    {
        Managers.Clear();
        Managers.Sound.Clear();     
        Managers.Scene.LoadScene("GameOver");
        //Managers.Sound.Play("GameClear", Define.Sound.Bgm);   

    }
    public void StageClear()       
    {
        Managers.Clear();
        Managers.Scene.LoadScene("StageClear");
        Managers.Sound.Clear();     
        //Managers.Sound.Play("GameClear", Define.Sound.Bgm);

    }

}

