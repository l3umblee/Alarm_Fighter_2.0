using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBeak : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 0.3f);
    }

    void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }
}
