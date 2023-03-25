using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridBaseSpawn : MonoBehaviour      //below @ItemSpawn
{
    public int maxItem = 4;
    public float delay = 10f;

    int currentItem = 0;        //num of currnent items spawned in field
    double currentTime = 0;

    public void ReduceItemCount()
    {
        currentItem--;
    }


    void Update()       //keeps on spawning items in the field
    {
        currentTime += Time.deltaTime;
        if (currentItem >= maxItem)
            return;
        if(currentTime >= delay)
        {
            int x, y;
            
            CalculateLocation(out x, out y);     //chooses an avaiable grid to spawn an item
            Managers.Item.ItemSpawn(x, y);
            currentItem += 1;
            currentTime = 0;
        }

    }

    //out parameter is used when more than two return values are required
    //in this case x and y are returned
    void CalculateLocation(out int x, out int y)
    {
        int rangeX = Managers.Field.GetWidth();
        int rangeY = Managers.Field.GetHeight();
        while (true)
        {
            int tempX = Random.Range(0, rangeX);
            int tempY = Random.Range(0, rangeY);

            if (!(Managers.Field.GetFieldInfo(tempX, tempY).spawnable))
                continue;


            x = tempX;
            y = tempY;
            return;

        }


    }
}
