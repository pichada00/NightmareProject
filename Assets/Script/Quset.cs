using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quset : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    
    public void Quest(string quest)
    {
        textMesh.text = quest;
    }

    public void OnTriggerEnter(Collider other)
    {
        Quest("Quest : find a way out");
    }
    
}
