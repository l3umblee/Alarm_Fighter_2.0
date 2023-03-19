using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public int x, y;

    public void SetGridInfo(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
