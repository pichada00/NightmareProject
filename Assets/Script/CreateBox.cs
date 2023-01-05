using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBox : MonoBehaviour
{
    public GameObject sphere;
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //สร้างวงกลม
            GameObject SphereClone = Instantiate(sphere) as GameObject;
            //สร้างที่ตำแหน่งใด
            SphereClone.transform.position = transform.position;
        }
    }
}
