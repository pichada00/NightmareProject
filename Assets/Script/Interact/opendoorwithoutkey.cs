using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class opendoorwithoutkey : Inractable
{
    public GameObject thisDoor;
    public Transform TDoor;       
    public bool doorON = false;
    public bool Opened = false;
    public bool DoorDestroy = false;
    float smooth = 5.0f;
    public float doorOpenAngle = -65.0f;
    private Vector3 defaultLoca;
    private Vector3 changeLoca;
    private Vector3 closedoor;
    public static opendoorwithoutkey instance;
    private void Start()
    {
        
        defaultLoca = transform.eulerAngles;
        changeLoca = new Vector3(defaultLoca.x, defaultLoca.y + doorOpenAngle, defaultLoca.z);
        closedoor = new Vector3(defaultLoca.x, changeLoca.y - doorOpenAngle, defaultLoca.z);

    }


    void doorOpen()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, changeLoca, smooth);
    }
    private void CloseDoor()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, closedoor, smooth);
    }

    public override string GetDescription()
    {
        if (!doorON ) return "Press [E] to open the door.";
        return "Press [E] to close the door.";

    }

    public override void Interact()
    {
        doorON = !doorON;
        if (doorON )
        {
            doorOpen();

        }
        else
        {
            CloseDoor();
        }
        
    }
    

}
