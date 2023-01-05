using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Change : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject panelStory;
    public TextMeshProUGUI textQuest;
    public TextMeshProUGUI textstory;
    public string FirstQuest;
    public string[] Story;
    private int number = 0;
    private void Start()
    {
        panelStory.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            panelStory.SetActive(true);
            textQuest.text = FirstQuest;
            textstory.text = Story[0];
            //StartCoroutine(TellStory(1, 2.0f));
            Invoke("TellStory", 2.0f);
            //StartCoroutine(TellStory(2, 2.0f));
            Invoke("DestOnDestroy", 6f);
        }
        
    }
    private void DestOnDestroy()
    {
        panelStory.SetActive(false);
        Destroy(gameObject);
    }

    private void TellStory()
    {        //yield return new WaitForSeconds(delaytime);        
        textstory.text = Story[1];        
        
    }
}
