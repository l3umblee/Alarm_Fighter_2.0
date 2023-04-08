using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TypingEffect : MonoBehaviour
{

    public TextMeshProUGUI tx;
    private string m_text = "It was a very sunny day in the morning";

    SwipeCartoon swipeCartoon;
    private int previousPage;

    List<string> introSceneScript = new List<string>();

    void Start()
    {
        tx = gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(_typing());

       
        swipeCartoon = FindObjectOfType<SwipeCartoon>();
        previousPage = swipeCartoon.currentPage;

        IntroSceneScript_Init();
    }

    private void IntroSceneScript_Init()
    {
        introSceneScript.Add("It was a very sunny day in the morning");
        introSceneScript.Add("But the Alarm weren't working");
        introSceneScript.Add("Dammmmn,It's way past 9AM!");
        introSceneScript.Add("Who the hell are these guys");
        introSceneScript.Add("This must be a virus. I need to install a vaccine app");
        introSceneScript.Add("Downloading AlarmFighter");
        introSceneScript.Add("Swooooooooosh");
        introSceneScript.Add("So The Journey Begins...");
        introSceneScript.Add("");
        
    }

    private void Update()
    {
        int currentPage = swipeCartoon.currentPage;

        for (int i = 0; i < introSceneScript.Count; i++)
        {
            if(currentPage == i)
            {
                m_text = introSceneScript[i];
            }
        }

        if (previousPage != currentPage)
        {
            StartCoroutine(_typing());
        }
        previousPage = currentPage;

    }
    

    IEnumerator _typing()
    {
        //yield return new WaitForSeconds(1f);
        for (int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i);
          
            yield return new WaitForSeconds(0.05f);
        }
    }
}
