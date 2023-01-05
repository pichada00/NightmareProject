using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemQuest : Inractable
{
    public bool isOn;
    public Item item;    

    public static ItemQuest instance;
   
    void pickup()
    {
        Backpack.instance.Add(item);  
        Backpack.instance.Check(item, "Stick");
        Destroy(gameObject);        
    }

    public void Testclear()
    {        
        //Backpack.instance.Add(itemresult);
    }

    public override string GetDescription()
    {
        if (!isOn) return "Press [E] to GetaCrowbar part";
        return "";
    }

    public override void Interact()
    {
        isOn = !isOn;

        pickup();
    }
}
