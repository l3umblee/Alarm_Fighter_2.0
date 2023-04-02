using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMonster_Test : MonoBehaviour
{
    MessageAttackPattern messageAttackPattern;
    List<List<MessageAttackPattern.FunctionPointer>> callOrderList;

    int index;
    int note;

    void Start()
    {
        messageAttackPattern = GetComponent<MessageAttackPattern>();

        Managers.Bpm.BehaveAction -= BitBehave;      //몬스터의 비트 마다 실행할 BitBehave 구독
        Managers.Bpm.BehaveAction += BitBehave;

        callOrderList = messageAttackPattern.CreateCallOrderList();

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
        if (note >= callOrderList[index].Count)
        {
            note = 0;
            index++;
        }

    }

    public void SetStartEnd_Message()
    {
        this.transform.GetComponent<Animator>().SetBool("startEnd", true);
    }
}
