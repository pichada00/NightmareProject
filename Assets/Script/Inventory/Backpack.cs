using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public int space = 3;
    public int count = 0;
    public List<Item> items = new List<Item>();
    public List<Item> book = new List<Item>();
    public bool Complete = false;
    public bool Complete1 = false;
    public bool Complete2 = false;
    public Item itemresult;
    public static Backpack instance;

    private void Awake()
    {
        instance = this;
    }
    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;
    public void Add(Item item)
    {
        if (item.showIntenvory)
        {
            if (items.Count >= space)
                return;
        }        
        
        
        items.Add(item);
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }
    public void Check(Item item , string name)
    {
        if (item.name == name && count < 3)
        {           
            book.Add(item);
            count += 1;
            if (item.name == "Oil") 
            {
                if(book.Count == 2)
                {                    
                    Complete = true;
                    count = 0;
                }
            }
            if(item.name == "Stick")
            {
                if (book.Count == 3)
                {
                    //playvideo
                    for (int i = 0; i <= count; i++)
                    {
                        //Debug.Log(i);
                        items.Remove(item);
                        book.Remove(item);
                    }
                    items.Add(itemresult);
                    Complete = true;
                    count = 0;
                }
            }
            if (item.name == "Axe")
            {
                Complete = true;
                book.Remove(item);
            }
            if (item.name == "OilBus")
            {
                Complete1 = true;
            }
            if(item.name == "KeyBus")
            {
                Complete2 = true;
            }
        }
    }
}
