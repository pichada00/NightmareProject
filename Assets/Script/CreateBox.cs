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
            //���ҧǧ���
            GameObject SphereClone = Instantiate(sphere) as GameObject;
            //���ҧ�����˹��
            SphereClone.transform.position = transform.position;
        }
    }
}
