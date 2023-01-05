using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Object;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        Object.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Object.SetActive(false);
        Destroy(gameObject);
    }
}
