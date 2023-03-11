using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldManager
{
    private Field field;

    public void SetField(Field roundField) { this.field = roundField; }
    public Field GetField() { return this.field; }
    public List<List<FieldInfo>> GetGridArray() { return field.GetGridArray(); }
    public FieldInfo GetFieldInfo(int x, int y) { return field.GetFieldInfo(x, y); }
    public GameObject GetGrid(int x, int y) { return field.GetGrid(x, y); }//z value is zero
    public void ScaleByRatio(GameObject go, int x, int y) { field.ScaleByRatio(go, x, y); }
    public int GetHeight() { return field.GetHeight(); }
    public int GetWidth() { return field.GetWidth(); }
    public void Init() { field.Init(); }
}