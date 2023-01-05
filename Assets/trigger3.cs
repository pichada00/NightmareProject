using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trigger3 : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject Ghost;
    public GameObject image;

    


    private void OnTriggerEnter(Collider other)
    {
        Scream.Play();

        Ghost.SetActive(true);
        image.SetActive(true);
        Invoke("EndJump", 1.8f);

    }
  

    void EndJump()
    {
        Debug.Log("=w=");
        Ghost.SetActive(false);
        image.SetActive(false);

        Destroy(gameObject);

    }
}
