using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBarUpdater : MonoBehaviour
{
    private GameObject playerHpbar;

    PlayerStat stat;                    //playerStat Script
    List<GameObject> hpbarLossList;

    public void SetPlayerHpBar(GameObject go)
    {
        playerHpbar = go;
    }

    void Start()
    {
        stat = GetComponent<PlayerStat>();
        hpbarLossList = new List<GameObject>();        
        hpbarLossList.Add(playerHpbar.transform.Find("Panel/HPLoss/HPLoss1").gameObject);
        hpbarLossList.Add(playerHpbar.transform.Find("Panel/HPLoss/HPLoss2").gameObject);
        hpbarLossList.Add(playerHpbar.transform.Find("Panel/HPLoss/HPLoss3").gameObject);
        hpbarLossList.Add(playerHpbar.transform.Find("Panel/HPLoss/HPLoss4").gameObject);
        hpbarLossList.Add(playerHpbar.transform.Find("Panel/HPLoss/HPLoss5").gameObject);
    }

    //checks PlayerStat script's CurrentHP and changes the PlayerHP UI
    void Update()
    {
        
        for (int i = hpbarLossList.Count - 1; i >= 0; i--)
        {
            if (i > stat.CurrentHP-1)
            {
                hpbarLossList[i].SetActive(true);
            }
            else 
            {
                hpbarLossList[i].SetActive(false);
            }
        }
    }
}
