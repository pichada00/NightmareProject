using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableObject : Inractable
{
    public Transform tDrawer;
    public bool failSafe = false;
    public bool drawerOn;
    float smooth = 5.0f;
    public float drawerChangeZ = 1.0f;
    private Vector3 defaultDrawer;
    private Vector3 openDrawer;
    private Vector3 closeDrawer;
    private void Start()
    {
        defaultDrawer = transform.position;       
        openDrawer = new Vector3(defaultDrawer.x, defaultDrawer.y, defaultDrawer.z - drawerChangeZ);
        closeDrawer = new Vector3(defaultDrawer.x, defaultDrawer.y, openDrawer.z + drawerChangeZ );        
    }

    void UpdateDrawer()
    {
        if (drawerOn && failSafe == false) {                      
            tDrawer.transform.position = openDrawer;
            StartCoroutine(FailSafe());
        }

        else {            
            tDrawer.transform.position = closeDrawer;
            StartCoroutine(FailSafe());
        }

    }

    public override string GetDescription()
    {
        if (!drawerOn) return "Press [E] to Open drawer.";
        return "Press [E] to Close drawer.";
    }

    public override void Interact()
    {
        drawerOn = !drawerOn;
        UpdateDrawer();
    }
    public IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.0001f);
        failSafe = false;
    }
}
