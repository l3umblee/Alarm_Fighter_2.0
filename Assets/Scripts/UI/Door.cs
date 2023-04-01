using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private IEnumerator coroutine;
    private string SceneName;

    public void SetName(string name) { SceneName = name; }
    void Start()
    {
        coroutine = MyFunction(SceneName);
        StartCoroutine(coroutine);

    }

    private IEnumerator MyFunction(string name)
    {
        yield return new WaitForSeconds(3.27f);//finish animation time
        StopCoroutine(coroutine);
        Managers.Scene.LoadScene(name);
    }

}
