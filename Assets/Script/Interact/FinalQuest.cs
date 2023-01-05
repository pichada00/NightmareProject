using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalQuest : Inractable
{
    public bool isOn;
    public Item item1;
    public Item item2;
    public GameObject gameObject;
    public string[] Description;
    void DestroyonObject()
    {

        if (Backpack.instance.Complete1 == true && Backpack.instance.Complete2 == true)
        {
            Backpack.instance.items.Remove(item1);
            Backpack.instance.items.Remove(item2);           
            Backpack.instance.book.Remove(item2);           
            Debug.Log("Destroygam");
            Gamemanager.gamemanager.ChangeScene("End");
            Scoremanager.scoremanager.EndGame = true;        
            Destroy(gameObject);
        }

    }



    public override string GetDescription()
    {
        if (Backpack.instance.Complete1) return "Press [E] to Exit";
        return "need Key and Oilbus , Key in LB ,Oil Behind Bus";
    }

    public override void Interact() => DestroyonObject();
}
