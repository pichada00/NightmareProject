using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Inractable
{
    public GameObject objectKey;
    public bool haveKey;
    public bool inInventory;
    public Item item;

    public Key key;
    private void Start()
    {
        


        
    }
    public void pickup()
    {
        Backpack.instance.Add(item);
        Backpack.instance.Check(item, "KeyBus");
        Destroy(gameObject);
    }

    void UpdateDoor()
    {
        Destroy(gameObject);
        
    }

    public override string GetDescription()
    {
        if (!haveKey) return "Press [E] for pickup.";
        return " ";
    }

    public override void Interact()
    {
        haveKey = !haveKey;
        inInventory = !inInventory;
        pickup();
    }
}
