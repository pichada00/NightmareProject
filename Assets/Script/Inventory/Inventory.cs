using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 3;
    public List<Item> items = new List<Item>();
    public static Inventory instance;

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
        if(onItemChangeCallback != null)
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


}
