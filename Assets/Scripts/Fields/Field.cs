using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField]
    int height;
    [SerializeField]
    int width;

    List<List<FieldInfo>> gridArray = new List<List<FieldInfo>>();// 2 demention list
    public int GetHeight() { return height; }
    public int GetWidth() { return width; }
    public List<List<FieldInfo>> GetGridArray() { return gridArray; }
    public FieldInfo GetFieldInfo(int x, int y)
    {
        if (x > width || y > height || x < 0 || y < 0)
        { Debug.Log("RoundField GetFieldInfo out of index"); return null; }
        return gridArray[x][y];
    }
    public GameObject GetGrid(int x, int y)
    {
        return gridArray[x][y].grid;
    }
    
    public void ScaleByRatio(GameObject go, int x, int y)
    {
        Vector3 playerScale = go.transform.localScale;

        playerScale = Vector3.one * GetFieldInfo(x, y).ratio;

        go.transform.localScale = playerScale;
    }
    
    public void Init()
    {
        for (int i = 0; i < width; i++)
            gridArray.Add(new List<FieldInfo>());

        int index = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                FieldInfo fieldInfo = new FieldInfo();
                if (width / 2 > i)
                {

                    fieldInfo.ratio = (0.7f + 0.1f * j + (0.1f / (width / 2)) * (i + 1));
                }
                else
                {
                    fieldInfo.ratio = (0.7f + 0.1f * j + (0.1f / (width / 2)) * (width - i - 1));

                }
                fieldInfo.grid = transform.GetChild(index).gameObject;
                gridArray[i].Add(fieldInfo);
                index++;
            }
        }
    }
    //¿Á¿± √ﬂ∞°
    public int GridInd_X(GameObject go)
    {
        int x = 0;
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                if (gridArray[i][j].grid.Equals(go))
                {
                    x = i;            
                    break;
                }
            }
        }
        return x;
    }
    public int GridInd_Y(GameObject go)
    {
        int y = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (gridArray[i][j].grid.Equals(go))
                {
                    y = j;
                    break;
                }
            }
        }
        return y;
    }

}

public class FieldInfo
{
    public GameObject grid; // one prefab
    public float ratio = 1.0f; // used by player scale
    public bool spawnable = true;
}