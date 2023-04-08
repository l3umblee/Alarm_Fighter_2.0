using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class NavigationMonster : MonoBehaviour
{
    NavigationAttackPattern navigationAttackPattern;
    List<List<NavigationAttackPattern.FunctionPointer>> callOrderList;

    int index;
    int note;

    void Start()
    {
        navigationAttackPattern = GetComponent<NavigationAttackPattern>();

        Managers.Bpm.BehaveAction -= BitBehave;      //몬스터의 비트 마다 실행할 BitBehave 구독
        Managers.Bpm.BehaveAction += BitBehave;

        callOrderList = navigationAttackPattern.CreateCallOrderList();

        index = 0;
        note = 0;
    }

    void BitBehave()
    {
        if (!this.transform.GetComponent<Animator>().GetBool("startEnd"))
            return;
        
        if (index > callOrderList.Count - 1)
            index = 0;

        callOrderList[index][note]();

        note++;
        if (note >= 8)
        {
            note = 0;
            index++;
            
            if(index == 1 || index == 3 || index == 5)
            {
                GetComponent<Animator>().SetTrigger("Caution");
            }
            else if(index == 7)
            {
                GetComponent<Animator>().SetTrigger("Angry_Idle");
            }
        }
     }

    public void ActivateStart()
    {
        this.transform.GetComponent<Animator>().SetBool("startEnd", true);
    }
        //index++;
}


