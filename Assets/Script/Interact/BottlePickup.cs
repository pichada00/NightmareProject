using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePickup : Inractable
{
    public bool isOn;
    public Item item;



    void pickup()
    {
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }


    public override string GetDescription()
    {
        if (!isOn) return "Press [E] to pick Water";
        return "";
    }

    public override void Interact()
    {
        isOn = !isOn;
        pickup();
    }
}
