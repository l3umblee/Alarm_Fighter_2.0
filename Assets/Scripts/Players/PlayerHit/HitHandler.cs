using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitHandler
{
    protected HitHandler successor;
    protected PlayerStat stat;      //PlayerStat Script

    public abstract void Request();

}
