using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTree : Inractable
{
    public bool isOn;
    public Item item1;    
    public GameObject gameObject;
    public string[] Description;
    void DestroyonObject()
    {
        
        if (Backpack.instance.Complete == true)
        {
            Backpack.instance.items.Remove(item1);
            Destroy(gameObject);
            Backpack.instance.Complete = false;
            Debug.Log("Destroygam");
            
        }

    }



    public override string GetDescription()
    {
        if (Backpack.instance.Complete) return "Press [E] to Destroy";
        return "need Axe to destroy,Axe in canteen";
    }

    public override void Interact() => DestroyonObject();
}
