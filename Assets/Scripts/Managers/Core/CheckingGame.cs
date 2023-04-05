using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingGame : MonoBehaviour
{
    bool HasBeenCalled = false;
    void Start()
    {
        HasBeenCalled = false;
    }


    void Update()
    {
        if(!Managers.Player.IsAlive()&&!HasBeenCalled)
        {
            GameObject go = Managers.Resource.Instantiate("UI/DoorClose");
            go.GetComponent<Door>().SetName("Map");
            HasBeenCalled = true;
        }
        else if(!Managers.Monster.IsAlive()&&!HasBeenCalled)
        {
            GameObject go = Managers.Resource.Instantiate("UI/DoorClose");
            if ((Managers.Monster.CurrentMonsterSceneName() + 1) != Define.GameSceneOrder.Map)
            {
                go.GetComponent<Door>().SetName((Managers.Monster.CurrentMonsterSceneName() + 1).ToString());
                HasBeenCalled = true;
            }
            else
            {
                go.GetComponent<Door>().SetName("Map");
                HasBeenCalled = true;
            }
            
        }
    }
}
