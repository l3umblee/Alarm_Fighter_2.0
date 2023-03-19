using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injector : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = transform.parent.GetComponent<SpriteRenderer>().sortingOrder-1;
    }
    public void Attack()
    {
        //Managers.Timer.ReduceTime(timeAmount);
        Destroy();
    }

    void Destroy()
    {
        //Managers.Resource.Destroy(gameObject);
        Object.Destroy(gameObject);
    }
}
