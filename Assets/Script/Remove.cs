using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    public GameObject bp;
    public bool open;
    private void Start()
    {
        open = false;
        bp.SetActive(open);
    }
    private void Update()
    {
        
    }

    public void OpenBP()
    {
        open = !open;
        bp.SetActive(open);
    }
}
