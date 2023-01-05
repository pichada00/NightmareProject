using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trigger2 : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject Ghost;
    public GameObject Ghost2;


    private void OnTriggerEnter(Collider other)
    {
        Ghost2.SetActive(true);

    }
    private void OnTriggerExit(Collider other)
    {
        Scream.Play();
        Ghost2.SetActive(false);
        Ghost.SetActive(true);
        Invoke("EndJump",2f) ;
    }

    void EndJump()
    {
        Debug.Log("=w=");
        Ghost.SetActive(false);
       
        Destroy(gameObject);

    }
}
