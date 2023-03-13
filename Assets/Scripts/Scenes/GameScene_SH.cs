using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene_SH : BaseScene
{
    [SerializeField] GameObject backGround;
    [SerializeField] GameObject BossMonster;
   
    public override void Clear()
    {
        Managers.Bpm.Clear();
    }

    protected override void Init()
    {
        base.Init();
        SpawnBackGround();
        SpawnField();
        SoundBgmPlay();
        SpawnMonster();
        //SpawnPlayer();
        //SpawnTimer();
        //SpawnHpBarMiddle();
        //SpawnMoveButton();

        //Managers.Item.Init();
        //Managers.Resource.Instantiate("Items/ItemBoxes/@GridBaseSpawn");
        //Managers.Menu.Init();

    }
    
    public void Update()
    {
        Managers.Bpm.UpdatePerBit();          
    }
    
    private void SpawnBackGround()              
    {
        GameObject go = Instantiate(backGround) as GameObject;      
        //go = Instantiate<GameObject>(go) as GameObject;     //?????
    }

    private void SpawnField()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Fields/Fields");
        go = Instantiate<GameObject>(go) as GameObject;
        //GameObject go = Managers.Resource.Instantiate("Prefabs/Fields/Fields");
        Managers.Field.SetField(go.GetComponent<Field>());
        Managers.Field.Init();
    }

    private void SpawnMonster()
    {
        GameObject go = Instantiate(BossMonster) as GameObject;
        Managers.Monster.BossMonster = go;

        //SpawnMonsterHpBar(go);
    }
    /*private void SpawnMonsterHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/MonsterHpBar");
        go = Instantiate<GameObject>(go) as GameObject;
        parent.GetComponent<HpBarUpdater>().hpbar = go;
        //GameObject go1 = Managers.Resource.Instantiate("Prefabs/UI/MonsterHpBar");
    }*/
    
    /*private void SpawnPlayer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Players/Player");
        go = Instantiate<GameObject>(go) as GameObject;
        Managers.Player.SetPlayer(go.GetComponent<Character>());
        Managers.Game.CurrentPlayer = go;

        SpawnPlayerHpBar(go);
    }*/

    /*private void SpawnPlayerHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/PlayerHpBar");
        go = Instantiate<GameObject>(go) as GameObject;
        parent.GetComponent<HpBarUpdater>().hpbar = go;
        //GameObject go2 = Managers.Resource.Instantiate("Prefabs/UI/PlayerHpBar");
    }*/
    
    /*private void SpawnHpBarMiddle()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/HpBarMiddle");
        go = Instantiate<GameObject>(go) as GameObject;
        //GameObject go1 = Managers.Resource.Instantiate("Prefabs/UI/HpBarMiddle");
    }*/
    /*
    private void SpawnTimer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/Timer");
        go = Instantiate<GameObject>(go) as GameObject;
    }
*/
    /*private void SpawnMoveButton()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/MoveButton");
        go = Instantiate<GameObject>(go) as GameObject;

    }*/
}
