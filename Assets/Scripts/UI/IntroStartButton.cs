using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroStartButton : MonoBehaviour
{
    public void OnClick()
    {
        Managers.Scene.Clear();
        Managers.Scene.LoadScene("Map");
    }
}
