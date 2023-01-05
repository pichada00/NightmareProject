using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public Transform itemParent;
    Backpack backpack;

    // Start is called before the first frame update
    void Start()
    {
        backpack = Backpack.instance;
        backpack.onItemChangeCallback += UpdateUI;
    }
    public void UpdateUI()
    {
        BackpackSlot[] slots = GetComponentsInChildren<BackpackSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < backpack.items.Count)
            {
                slots[i].AddItem(backpack.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }*/
        UpdateUI();
    }
}
