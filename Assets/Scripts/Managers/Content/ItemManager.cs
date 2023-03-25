using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    List<string> itemList;
    GameObject pool;    //@ItemSpawn(GameObject)

    //spawns an item below certain grid(GameObject)
    public GameObject ItemSpawn(int x, int y)
    {
        int rand = Random.Range(0, itemList.Count);
        GameObject grid = Managers.Field.GetGrid(x, y);
        GameObject item = Managers.Resource.Instantiate(itemList[3]/*itemList[rand]*/, grid.transform);//sunho 임시수정
        item.GetComponent<DroppedItem>().SetGridInfo(x, y);
        

        Managers.Field.ScaleByRatio(item, x, y);
        Managers.Field.GetFieldInfo(x, y).spawnable = false;
        Managers.Sound.Play("Effects/ItemSpawn", Define.Sound.Effect, 1.0f, 0.2f);
        return item;
    }
    
    //Destroys an item
    public void ItemDeSpawn(GameObject go)
    {
        Managers.Resource.Destroy(go);
        pool.GetComponent<GridBaseSpawn>().ReduceItemCount();
        Managers.Field.GetFieldInfo(go.GetComponent<DroppedItem>().x, go.GetComponent<DroppedItem>().y).spawnable = true;
    }

    public void Init()
    {
        SetWeaponList();
        pool = Managers.Resource.Instantiate("Items/@ItemSpawn");
    }

    public void SetWeaponList()
    {
        //to do : player 캐릭터에 따라 weaponList 바뀌게
        itemList = new List<string>();
        itemList.Add("Items/DroppedItems/DroppedShield");
        itemList.Add("Items/DroppedItems/DroppedHealPotion");
        itemList.Add("Items/DroppedItems/DroppedRandomBox");
        itemList.Add("Items/DroppedItems/DroppedVaccineGun");
    }

}
