using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpBarUpdater : MonoBehaviour
{
    [SerializeField]
    public GameObject playerHpbar;

    Stat stat;
    List<GameObject> hpbarLossList;

    // Start is called before the first frame update
    void Start()
    {
        stat = GetComponent<Stat>();
        hpbarLossList = new List<GameObject>();
        hpbarLossList.Add(playerHpbar.transform.Find("HPLoss5").gameObject);
        hpbarLossList.Add(playerHpbar.transform.Find("HPLoss4").gameObject);
        hpbarLossList.Add(playerHpbar.transform.Find("HPLoss3").gameObject);
        hpbarLossList.Add(playerHpbar.transform.Find("HPLoss2").gameObject);
        hpbarLossList.Add(playerHpbar.transform.Find("HPLoss1").gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = hpbarLossList.Count - 1; i >= 0; i--)
        {
            if (i > stat.CurrentHP)
                hpbarLossList[i].SetActive(true);
            else 
                hpbarLossList[i].SetActive(false);
        }
    }
}
