using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackSlot : MonoBehaviour
{
    public Image icon;
    //public Button removeButton;
    Item item;//current item in slot
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
    }
    public void ClearSlot()
    {
        item = null;
        icon.enabled = false;
        //removeButton.interactable = false;
    }
    public void RemoveItemFromInventory()
    {
        Backpack.instance.Remove(item);
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
