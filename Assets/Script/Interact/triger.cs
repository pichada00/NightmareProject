using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triger : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        panel.SetActive(true);
    }

}
