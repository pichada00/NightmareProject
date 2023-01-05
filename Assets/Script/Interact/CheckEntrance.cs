using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEntrance : MonoBehaviour
{
    /*public bool entrance = false;
    public bool DoorDestroy = false;*/
    public GameObject Ghost;
    //public Collider collider;
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ghost")
        {
           
        }     
    }
}
