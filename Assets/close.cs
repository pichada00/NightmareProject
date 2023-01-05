using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    public GameObject gg;

    private void OnTriggerEnter(Collider other)
    {
        gg.SetActive(false);
    }
}
