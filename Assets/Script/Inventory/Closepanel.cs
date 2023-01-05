using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closepanel : MonoBehaviour
{
    public GameObject showItem;
    public GameObject ItemDetail;
    public showDetail show;

    public void close()
    {
        show.showON = !show.showON;
        //show.ItemDetail.SetActive(show.showON);
        showItem.SetActive(false);
    }
}
