using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tantacle : MonoBehaviour
{
    SpriteRenderer rend;

    void Start()
    {
        Invoke("Destroy", 0.3f);
    }
    void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }


}
