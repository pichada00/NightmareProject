using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractiveObject
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        pickup();
    }
    void pickup()
    {
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
