using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDetail : Inractable
{
    //public GameObject ItemDetail;
    
    public GameObject panel;
    

    
    public GameObject[] UIincanvas;

    public bool showON = false;
    private void Start()
    {
        DetailItem();
        UIincanvas = GameObject.FindGameObjectsWithTag("UIincanvas");
    }
    
    public void DetailItem()
    {
        //ItemDetail.SetActive(showON);
        panel.SetActive(showON);
        foreach (GameObject uiInCanvas in UIincanvas) 
        { 
            uiInCanvas.SetActive(!showON);
        }
        
    }

    public override string GetDescription()
    {
        if (!showON) return "Press [E] to ShowDetail. ";
        return "Press [E] to Quit ";
    }

    public override void Interact()
    {
        showON = !showON;
        DetailItem();
    }
    public void close()
    {
        showON = !showON;
        //ItemDetail.SetActive(showON);
        panel.SetActive(showON);
        foreach (GameObject uiInCanvas in UIincanvas)
        {
            uiInCanvas.SetActive(!showON);
        }
    }
}
