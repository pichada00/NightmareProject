using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName = "InventoryItem")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool showIntenvory = true;

    //คำสั่งใช้Item
    public void Use()
    {
        /*Debug.Log("UseFlashlight");
         if (name.Equals("Flashlight"))
         {
             //CharacterControl.instance.ShowFlashlight();
             RemoveItemFromInventory();
         }
         if (name.Equals("battery"))
         {
             BatterySystem.batterySystem.UseBattery(100f);
                 Debug.Log("use''s;s;");
                 RemoveItemFromInventory();
         }*/
        switch (name)
        {
            case "battery":
                BatterySystem.instance.UseBattery(100f);               
                RemoveItemFromInventory();
                break;
            case "Medic":
                HealthSystem.healthSystem.GainHealth(50f);
                RemoveItemFromInventory();
                break;
            case"Bottle":
                StaminaSystem.staminaSystem.GainStamina(100f);
                RemoveItemFromInventory();
                break;
            default :
                Debug.Log("U dont have");
                break;
        }
    }
    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
