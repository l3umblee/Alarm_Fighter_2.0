using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : BaseScene//At the beginning of the this scene, responsible for the essential spawn.
{

    public override void Clear()
    {

    }

    protected override void Init()
    {
        base.Init();            
        SoundBgmPlay();
        SpawnBackGround();
        SpawnField();
        SpawnMonster();       
        SpawnPlayer();
        SpawnItemSpawner();
    }

    private void SpawnBackGround()
    {
        GameObject go = Managers.Resource.Instantiate("BackGrounds/CameraStageBackGround");
    }
    private void SpawnField()
    {
        GameObject go = Managers.Resource.Instantiate("Fields/Fields");
        if(go != null) 
        {
            Managers.Field.SetField(go.GetComponent<Field>());
            Managers.Field.Init();
        }
    }
    private void SpawnPlayer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Players/Player");
        if(go != null) 
        {
            Managers.Player.SetPlayer(go.GetComponent<Player>());
            go = Managers.Resource.Instantiate("Players/Player");
            SpawnPlayerHpBar(go);
        }
    }
    private void SpawnMonster()                
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/CameraMonster/CameraMonster");
        if( go != null)
        {
            SpawnMonsterHpBar(go);
            Managers.Monster.BossMonster = go;
        }
    }   
    private void SpawnPlayerHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Players/PlayerHP");
        go = Instantiate<GameObject>(go) as GameObject;
        go.transform.Find("HPLoss1").gameObject.SetActive(false);
        go.transform.Find("HPLoss2").gameObject.SetActive(false);
        go.transform.Find("HPLoss3").gameObject.SetActive(false);
        go.transform.Find("HPLoss4").gameObject.SetActive(false);
        go.transform.Find("HPLoss5").gameObject.SetActive(false);

        parent.GetComponent<PlayerHpBarUpdater>().playerHpbar = go;
    }

    private void SpawnMonsterHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/CameraMonster/MonsterHP");
        if(go != null) 
        {
            parent.GetComponent<MonsterHpBarUpdater>().monsterHPbar = go;
        }
    }
    private void SpawnItemSpawner()
    {
        Managers.Item.Init();
    }
}
