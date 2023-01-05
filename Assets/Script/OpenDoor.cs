using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : Inractable
{
    public Transform TDoor;
    public OpenDoor door;
    public Key key;
    public Item item;
    public bool doorON = false;
    public bool Opened = false;
    float smooth = 5.0f;
    public float doorOpenAngle = 90.0f;
    private Vector3 defaultLoca;
    private Vector3 changeLoca;
    private Vector3 closedoor;
    public TextMeshProUGUI Tutorial;
    private void Start()
    {
        door.enabled = key.haveKey;
        defaultLoca = transform.eulerAngles;
        changeLoca = new Vector3(defaultLoca.x, defaultLoca.y + doorOpenAngle, defaultLoca.z);
        closedoor = new Vector3(defaultLoca.x, changeLoca.y - doorOpenAngle, defaultLoca.z);

    }
    

    void doorOpen()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, changeLoca,  smooth);
        Tutorial.gameObject.SetActive(false);
    }
    private void CloseDoor()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, closedoor,  smooth);
    }

    public override string GetDescription()
    {
        if (!doorON && key.haveKey)return "Press [E] to open the door.";        
        return "Press [E] to close the door.";                  
        
    }

    public override void Interact()
    {
        doorON = !doorON;
        if (doorON && key.haveKey ) 
        {
            doorOpen();           
            
        }
        else
        {
            CloseDoor();            
        }
        if (key.inInventory)
        {
            Backpack.instance.Remove(item);
        }
    }

    
}
