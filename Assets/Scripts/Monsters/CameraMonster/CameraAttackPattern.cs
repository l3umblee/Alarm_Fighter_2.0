using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraAttackPattern :MonoBehaviour
{
    //public delegate void FunctionPointer();
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;//new List<FunctionPointer>() { Row, Rest, Row, Rest, Column, Row, Column, Rest };
    private void Awake()
    {
        Init();
    }
    
    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { Row, Rest, Row, Rest, Column, Row, Column, Rest };
    }

    public void Row()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            //LazerAttack(Managers.Monster.BossMonster.transform, i, Managers.Player.GetCurrentY());
            LazerAttack(Managers.Monster.BossMonster.transform, i, 1);
        }
    }
    public void Rest()
    {
      
    }
    
    public void Column()
    {
        // int rand = UnityEngine.Random.Range(1, Managers.Field.GetWidth() - 1);
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            //LazerAttack(Managers.Monster.BossMonster.transform, Managers.Player.GetCurrentX(), i);
            LazerAttack(Managers.Monster.BossMonster.transform,1, i);
        }
    }
    public List<FunctionPointer> CreateCallOrderList()
    {
        List<FunctionPointer> callOrderList = new List<FunctionPointer>();
        
        for (int i = 0; i < noteBarList_1.Count; i++)
        {
            callOrderList.Add(noteBarList_1[i]);
        }
        return callOrderList;
    }

    
    //-----------------------------------------------------------------------------------------------------------------
    #region CameraAttackPatterns

    public async void LazerAttack(Transform transform, int x, int y)//Lazer attack where is in grid(x,y), start  = monster eye, where = (x,y)
    {
        //Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("GridRed");
        //await Task.Delay(300);
        LazerInit(transform, x, y);//n second after use
    }
    #region LazerAttack_Private
    private void LazerInit(Transform transform, int x, int y)
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/CameraMonster/Effects/Lazer");
        GameObject effect = Managers.Resource.Load<GameObject>("Prefabs/Monsters/CameraMonster/Effects/Lazer_Boom");

        go.transform.position = transform.position;
        SetBasicScale(go);
        Transform transform_my = go.transform;
        Transform transform_target = SetTarget(x, y);
        effect.transform.position = SetEffect(x, y);
        SetRotation(go, transform_my, transform_target);
        go = Managers.Resource.Instantiate("Monsters/CameraMonster/Effects/Lazer");
        effect = Managers.Resource.Instantiate("Monsters/CameraMonster/Effects/Lazer_Boom");

        go.AddComponent<Lazer>();
        effect.AddComponent<Lazer_Boom>();


    }
    public void SetBasicScale(GameObject go)        //Change private to public
    {
        float x = 10.0f;
        float y = go.transform.localScale.y;
        float z = go.transform.localScale.z;
        go.transform.localScale = new Vector3(x, y, z);
    }
    public Transform SetTarget(int x, int y)        //Change private to public
    {
        return Managers.Field.GetGrid(x, y).transform;
    }
    private  void UpdateScale(GameObject go, Vector3 vector)
    {
        float vectorX = go.transform.localScale.x;
        float vectorY = -vector.magnitude;
        float vectorZ = vector.z;
        go.transform.localScale = new Vector3(vectorX, vectorY, vectorZ);
    }
    public  void SetRotation(GameObject go, Transform transform_my, Transform transform_target)    //Change private to public
    {
        Vector3 myPos = transform_my.position;
        Vector3 targetPos = transform_target.position;
        targetPos.z = myPos.z;

        Vector3 vectorToTarget = targetPos - myPos;
        UpdateScale(go, vectorToTarget);

        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: vectorToTarget);
        transform_my.rotation = targetRotation;


        //transform_my.rotation = Quaternion.RotateTowards(transform_my.rotation, targetRotation, 100 * Time.deltaTime);
    }
    private  Vector3 SetEffect(int x, int y)
    {
        Vector3 vec = Managers.Field.GetGrid(x, y).transform.position;
        //vec.z = 0;
        return vec;
    }
    #endregion
    //
    public void LazerMoveAttack(Transform transform, int where = 0, int speed = 500)//Lazer move attack where is row, start = monster eye, where = row
    {
        LazerMoveInit(transform, where, speed);
    }
    #region LazerMoveAttack_Private
    private void LazerMoveInit(Transform transform, int where, int speed)
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/CameraMonster/Effects/Lazer");
        GameObject effect = Managers.Resource.Instantiate("Monsters//CameraMonster/Effects/Lazer_Boom");

        /*GameObject lazerMoveAttack = new GameObject("LazerMoveAttack");
        go.transform.SetParent(lazerMoveAttack.transform);
        effect.transform.SetParent(lazerMoveAttack.transform);*/

        go.transform.SetParent(Managers.Monster.BossMonster.transform);
        effect.transform.SetParent(Managers.Monster.BossMonster.transform);
        
        go.AddComponent<LazerMove>();
        //effect.AddComponent<HorizontalAttack1>(); 
    }

    #endregion
    public void TantacleAttack() { }
    #region TantacleAttack_Private

    #endregion
    public void FlashAttack() { FlashInit(); }
    #region FlashAttack_Private
    private void FlashInit()
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/CameraMonster/Effects/Flash");
    }
    #endregion

    #endregion


  


}
