using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetaBook : Inractable
{
    
    public bool isOn;     
    public Item item;
    private void Start()
    {
        

        
    }

    void UpdateLight()
    {
        // m_light.enabled = isOn;

    }
    void pickup()
    {
        Backpack.instance.Add(item);
        Destroy(gameObject);
    }

    public override string GetDescription()
    {
        if (!isOn) return "Press [E] to GetaBook";
        return "Press [E] to empty";
    }

    public override void Interact()
    {
        isOn = !isOn;
        
        pickup();
    }
}
