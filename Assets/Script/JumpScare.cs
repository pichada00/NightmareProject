using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject Ghost;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject image;

    private void OnTriggerEnter(Collider other)
    {
        Scream.Play();
        Ghost.SetActive(true);
        Light1.SetActive(true);
        Light2.SetActive(true);
        image.SetActive(true);
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.3f);
        Ghost.SetActive(false);
        Light1.SetActive(false);
        Light2.SetActive(false);
        image.SetActive(false);
        Destroy(gameObject);
    }
}
