using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpBarUpdater : MonoBehaviour
{
    [SerializeField]
    public GameObject monsterHPbar;
    //Stat stat;
    [SerializeField]
    public float playTime;

    private Image hp;
    private float currentTime;
    void Start()
    {
        /*
                stat = GetComponent<Stat>();
                hp = monsterHPbar.transform.Find("FullHP").GetComponent<Image>();
                Debug.Log(hp);
        */
        currentTime = playTime;
        hp = monsterHPbar.transform.Find("FullHP").GetComponent<Image>();
        Debug.Log(hp);
        //hp = this.transform.Find("FullHP").GetComponent<Image>();
    }

    void Update()
    {
        if (currentTime > 0)
            currentTime -= Time.deltaTime;
        else
        {
            currentTime = 0;
            //Managers.Game.GameOver();  // 게임 오버
            Debug.Log("Game Over");
        }
        Debug.Log(currentTime);
        hp.fillAmount = currentTime / playTime;
        //hp.fillAmount = (float)stat.CurrentHP / (float)stat.MaxHP;
    }
}
