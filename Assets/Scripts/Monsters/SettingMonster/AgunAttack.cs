using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgunAttack : MonoBehaviour
{
    
    void Start()
    {
        Invoke("Destroy", 0.3f);
        Invoke("Move", 0.1f);
    }
    void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }
    void Move()
    {
        gameObject.transform.position = Managers.Player.GetCurrentTransform().position;
        Vector3 vector = gameObject.transform.localScale;
        vector.x = vector.x * 0.2f;
        vector.y = vector.y * 0.2f;
        vector.z = vector.z * 0.2f;
        gameObject.transform.localScale = vector;
    }
}
