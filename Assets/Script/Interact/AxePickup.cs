using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxePickup : Inractable
{
    public bool isOn;
    public Item item;
    



    void pickup()
    {
        Backpack.instance.Add(item);
        Backpack.instance.Check(item, "Axe");
        Destroy(gameObject);
    }


    public override string GetDescription()
    {
        if (!isOn) return "Press [E] to pick Axe";
        return "";
    }

    public override void Interact()
    {
        isOn = !isOn;
        pickup();
    }



}
