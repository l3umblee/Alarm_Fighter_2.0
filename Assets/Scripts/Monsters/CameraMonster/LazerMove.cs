using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class LazerMove : MonoBehaviour
{
    Transform effect;
    Transform transform_my;
    Transform transform_target;

    CameraAttackPattern cap;

    private void Start()
    {
        GameObject effectObject = Util.FindChild(transform.root.gameObject, "Lazer_Boom");
        effect = effectObject.transform;
        
        cap = transform.root.GetComponent<CameraAttackPattern>();
        cap.SetBasicScale(gameObject);
    }
    void Update()
    {
        transform.position = Managers.Monster.BossMonster.transform.position;
        transform_my = this.transform;
        transform_target = effect;

        try
        {
            cap.SetRotation(gameObject, transform_my, transform_target);
        }
        catch (MissingReferenceException)
        {
            Destroy(gameObject);
        }
    }
}
