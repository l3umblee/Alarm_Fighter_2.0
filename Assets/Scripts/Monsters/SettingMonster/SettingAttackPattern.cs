using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingAttackPattern : MonoBehaviour
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;
    public List<FunctionPointer> noteBarList_2;

    private IEnumerator coroutine;
    float del_time = 0.9f;
    float temp;
    void Start()
    {
        coroutine = MyFunction();
        StartCoroutine(coroutine);
    }

    private IEnumerator MyFunction()
    {
        yield return new WaitForSeconds(3.27f);
        Special();

        yield return new WaitForSeconds(0.91f);
        Special();

        yield return new WaitForSeconds(0.98f);
        Special();

        yield return new WaitForSeconds(0.95f);
        Special();

        yield return new WaitForSeconds(0.88f);
        Special();

        yield return new WaitForSeconds(0.99f);
        Special();

        yield return new WaitForSeconds(0.91f);
        Special();

        yield return new WaitForSeconds(0.93f);
        Special();

        yield return new WaitForSeconds(0.90f);//10.72sec
        Special();

        yield return new WaitForSeconds(0.24f);//10.96sec
        Special();
        yield return new WaitForSeconds(0.22f);//11.18sec
        Special();
        yield return new WaitForSeconds(0.52f);//11.70sec
        Special();

        yield return new WaitForSeconds(0.97f);
        Special();

        yield return new WaitForSeconds(0.92f);
        Special();

        yield return new WaitForSeconds(0.97f);
        Special();

        yield return new WaitForSeconds(0.49f);
        Special();

        yield return new WaitForSeconds(0.47f);
        Special();

        yield return new WaitForSeconds(0.89f);
        Special();

        yield return new WaitForSeconds(0.93f);
        Special();

        yield return new WaitForSeconds(0.92f);
        Special();

        yield return new WaitForSeconds(0.98f);
        Special();

        yield return new WaitForSeconds(0.99f);
        Special();

        yield return new WaitForSeconds(0.84f);
        Special();

        yield return new WaitForSeconds(1.0f);
        Special();

        yield return new WaitForSeconds(0.9f);
        Special();

        yield return new WaitForSeconds(0.95f);
        Special();

        yield return new WaitForSeconds(0.98f);
        Special();

        yield return new WaitForSeconds(0.96f);
        Special();
        yield return new WaitForSeconds(0.9f);
        Special();

        yield return new WaitForSeconds(0.94f);
        Special();

        yield return new WaitForSeconds(0.92f);
        Special();

        yield return new WaitForSeconds(0.97f);//29.59
        Special();

        while (true)
        {
            yield return new WaitForSeconds(del_time);
            temp += 0.9f;
            if(temp>10)
            {
                del_time += 0.1f;
                GameObject go = Managers.Sound.GetCurrentBGM();
                go.GetComponent<AudioSource>().pitch = 0.9f;
            }
            Special();
        }
    }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { Row1, Column1, Row2, Column2 };
        noteBarList_2 = new List<FunctionPointer>() { Agun, Rest, Agun, Rest };
        noteBarList_1 = new List<FunctionPointer>() { Row2, Column1, Row3, Column3 };
        // 낫으로 공격하는 부분 추가 필요
    }

    private void Special()
    {
        DarkModeAttack();
    }
    private void Rest()
    {
        //does nothing
    }

    private void Row1()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(0, i).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Row2()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(1, i).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Row3()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(2, i).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Column1()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 0).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Column2()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 1).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Column3()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 2).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Agun()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("One");
    }

    public List<List<FunctionPointer>> CreateCallOrderList()
    {
        List<List<FunctionPointer>> callOrderList = new List<List<FunctionPointer>>();
        
        callOrderList.Add(noteBarList_1);
        callOrderList.Add(noteBarList_2);

        return callOrderList;
    }

    #region settingattackpattern

    public void AgunAttack() 
    { 
        AgunInit(); 
    }
    #region Agun_Private
    private void AgunInit()
    {
        //GameObject mouth = Util.FindChild(Managers.Monster.BossMonster, "Mouth",true);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/SettingMonster/Effects/Agun");

        Managers.Resource.Instantiate("Monsters/SettingMonster/Effects/Agun"); 
    }
    #endregion

    public void DarkModeAttack()
    {
        DarkModeInit();
    }
    #region DarkMode_Private
    private void DarkModeInit()
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/SettingMonster/Effects/DarkMode");
    }
    #endregion
    #endregion
}
