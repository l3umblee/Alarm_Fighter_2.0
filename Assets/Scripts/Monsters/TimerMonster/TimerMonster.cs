using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMonster : MonoBehaviour
{
    TimerAttackPattern timerAttackPattern;
    List<List<TimerAttackPattern.FunctionPointer>> callOrderList;

    int index;
    int note;

    void Start()
    {
        timerAttackPattern = GetComponent<TimerAttackPattern>();

        Managers.Bpm.BehaveAction -= BitBehave;      //몬스터의 비트 마다 실행할 BitBehave 구독
        Managers.Bpm.BehaveAction += BitBehave;

        callOrderList = timerAttackPattern.CreateCallOrderList();

        index = 0;
        note = 0;
    }

    void BitBehave()
    {
        if (index > callOrderList.Count - 1)
            index = 0;

        callOrderList[index][note]();

        note++;
        if (note >= 4)
        {
            note = 0;
            //index++; // notebarlist를 추가하면 다시 주석 풀어줘야 됨.
        }

        //index++;
    }

}
