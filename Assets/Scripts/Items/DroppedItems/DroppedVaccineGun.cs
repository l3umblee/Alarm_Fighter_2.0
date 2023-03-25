using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedVaccineGun : DroppedItem
{
    public float timeAmount = 3f;
    string vaccine = "Items/ActiveItems/VaccineEffect";
    public void Active()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            PlayerStat stat = go.GetComponent<PlayerStat>();
            if (stat != null)
            {
                GameObject attack = Managers.Resource.Instantiate(vaccine, go.transform);
                Managers.Item.ItemDeSpawn(gameObject);
            }
        }
    }

}
