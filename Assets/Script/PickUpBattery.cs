using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBattery : MonoBehaviour
{
    public GameObject player;
    public float changeValue;//ค่าแบตเตอรี่
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            other.gameObject.GetComponent<BatterySystem>().PickUpPanel.SetActive(true);
            
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<BatterySystem>().PickUpPanel.SetActive(false);
                this.gameObject.SetActive(false);
                AddBattery(player, changeValue);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<BatterySystem>().PickUpPanel.SetActive(false);
    }
    void AddBattery(GameObject player,float value)
    {
        if(player.GetComponent<BatterySystem>().Battery<player.GetComponent<BatterySystem>().MaxBattery)
        {
            player.GetComponent<BatterySystem>().Battery += value;
        }
    }
}
