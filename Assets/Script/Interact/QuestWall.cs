using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestWall : Inractable
{   
    public bool isOn;
    public Item item;
    public GameObject gameObject;
    void DestroyonObject()
    {       
        
        if (Backpack.instance.Complete == true)
        {
            Backpack.instance.items.Remove(item);
            Debug.Log("Destroygam");
            Backpack.instance.Complete = false;
            Backpack.instance.count = 0;
            Destroy(gameObject);
        }        
        
    }   



    public override string GetDescription()
    {
        if (Backpack.instance.Complete) return "Press [E] to Destroy";
        return "need Iron to destroy";
    }

    public override void Interact() => DestroyonObject();    
}
