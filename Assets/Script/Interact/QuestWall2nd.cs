using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestWall2nd : Inractable
{
    public bool isOn;
    public Item item1;
    public Item item2;
    public GameObject gameObject;
    public string[] Description;
    void DestroyonObject()
    {

        if (Backpack.instance.Complete == true)
        {
            Backpack.instance.items.Remove(item1);
            Backpack.instance.items.Remove(item2);
            Backpack.instance.items.Remove(item2);
            Backpack.instance.book.Remove(item2);
            Backpack.instance.book.Remove(item2);
            Backpack.instance.Complete = false;
            Debug.Log("Destroygam");
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
