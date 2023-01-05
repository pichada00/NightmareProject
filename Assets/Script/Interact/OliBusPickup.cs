using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliBusPickup : Inractable
{
    public bool isOn;
    public Item item;



    void pickup()
    {
        Backpack.instance.Add(item);
        Backpack.instance.Check(item, "OilBus");
        Destroy(gameObject);
    }


    public override string GetDescription()
    {
        if (!isOn) return "Press [E] to pick Oli Burn";
        return "";
    }

    public override void Interact()
    {
        isOn = !isOn;
        pickup();
    }
}
