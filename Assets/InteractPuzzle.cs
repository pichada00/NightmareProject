using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractPuzzle : Inractable
{
    public bool isOn;
    public bool boolCheck = false;
    public GameObject Puzzle1;
    public GameObject windowPuzzle;
    public Item item;    
    [SerializeField]private Gamemanager gamemanager;

    public static InteractPuzzle inter;
    private void Awake()
    {
        inter = this;
    }

    private void Start()
    {
        windowPuzzle.SetActive(isOn);        
    }    
    void pickUp()
    {
        if(boolCheck == false)
        {
            Backpack.instance.Add(item);            
            Scoremanager.scoremanager.FindSecretItem = true;
            Scoremanager.scoremanager.MinigamePass = true;
            boolCheck = true;            
        }       
        
        //Destroy(gameObject);
    }

    public override string GetDescription()
    {
        if (!isOn) return "Press [E] to pick picture parts";
        return "Press [E] to Back";
    }

    public override void Interact()
    {
        isOn = !isOn;
        windowPuzzle.SetActive(isOn);
        pickUp();
        if (isOn == true)
        {
            Debug.Log("sdsada");
            Time.timeScale = 0;
            gamemanager.control = true;
        }
        else
        {
            Debug.Log("xzcxzc");
            Time.timeScale = 1;
            gamemanager.control = false;
        }


    }
}
