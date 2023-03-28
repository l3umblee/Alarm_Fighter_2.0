using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgunAttack : MonoBehaviour
{
    
    void Start()
    {
        //Invoke("Destroy", 0.5f);
        
    }
    void Update()
    {
        GameObject AgunUp = Util.FindChild(gameObject, "AgunUp");
        GameObject AgunDown = Util.FindChild(gameObject, "AgunDown");

        Quaternion OpenUp = new Quaternion(0, 0, -0.210584193f, 0.977575719f);
        Quaternion OpenDown = new Quaternion(0, 0, 0.314079553f, 0.949396729f);
        AgunDown.transform.rotation = Quaternion.Slerp(AgunDown.transform.localRotation,OpenDown, 0.8f);
        AgunUp.transform.rotation = Quaternion.Slerp(AgunUp.transform.localRotation, OpenUp,  0.8f);
        
    }
    void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }
    void Move()
    {
        GameObject AgunUp = Util.FindChild(gameObject, "AgunUp");
        GameObject AgunDown = Util.FindChild(gameObject, "AgunDown");
     
        Quaternion OpenUp = Quaternion.Euler(new Vector3(0, 0, -20));
        Quaternion OpenDown = Quaternion.Euler(new Vector3(0, 0, 20));
        AgunDown.transform.rotation = Quaternion.Slerp(OpenDown, Quaternion.identity, 0.1f);
        AgunUp.transform.rotation = Quaternion.Slerp(OpenUp, Quaternion.identity, 0.1f);
      

    }
}
