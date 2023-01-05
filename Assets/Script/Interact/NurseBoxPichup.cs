using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseBoxPichup : Inractable
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
        if (!isOn) return "Press [E] to pick Medic";
        return "";
    }

    public override void Interact()
    {
        isOn = !isOn;
        pickup();
    }
}
