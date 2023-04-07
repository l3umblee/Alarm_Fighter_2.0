using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    public Define.GameSceneOrder NextStage { get; private set; }

    public void UpdateNextStage() { NextStage += 1; }

    public void QuitGame()
    {
        SaveGame();
        Application.Quit();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("NextStage", (int)NextStage);
    }

    public void LoadGame()
    {
        if (!PlayerPrefs.HasKey("NextStage"))
            return;

        NextStage = (Define.GameSceneOrder)PlayerPrefs.GetInt("NextStage");

    }

    public void ResetGame()
    {
        NextStage = Define.GameSceneOrder.TimeScene_main;
        SaveGame();
    }

    public void Init()
    {
        LoadGame();
        NextStage = Define.GameSceneOrder.Count;
    }
}

