using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighterPickup : Inractable
{
    public bool isOn;
    public Item item;    

    public static GetaBook instance;

    void pickup()
    {
        Backpack.instance.Add(item);
        Destroy(gameObject);
    }
    

    public override string GetDescription()
    {
        if (!isOn) return "Press [E] to pickup lighter";
        return "";
    }

    public override void Interact()
    {
        isOn = !isOn;
        pickup();
    }
}
