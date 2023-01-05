using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickNursingBox : MonoBehaviour
{
    private int HP;

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag.Equals("HP"))
        {
            Destroy(target.gameObject);
            HP += 40;
        }
    }
}
