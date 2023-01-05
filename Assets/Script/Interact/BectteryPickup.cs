using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BectteryPickup : Inractable
{
    public bool isOn;
    public Item item;
    public AudioSource audioSource;
    public GameObject Button;

    public void pickup()
    {
        SoundManager.Instance.Play(audioSource, SoundManager.Sound.Pickup);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
    public override string GetDescription()
    {
        if (!isOn) return "Press [E] to pick battery";
        return "";
    }

    public override void Interact()
    {
        isOn = !isOn;
        pickup();
    }
}
