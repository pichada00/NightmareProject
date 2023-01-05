using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rankmanager : MonoBehaviour
{
    public GameObject rankDataPrototype;
    public Transform rankPanel;

    public static Rankmanager rankmanager;
    
    public List<playerData> PlayerDatas;
    // Start is called before the first frame update
    void Start()
    {
        //CreateRankDara();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        rankmanager = this;
    }
    /*public void CreateRankDara()
    {
        for (int i = 0; i < PlayerDatas.Count; i++)
        {
            GameObject rankObj = Instantiate(rankDataPrototype, rankPanel) as GameObject;
            RankData rankData = rankObj.GetComponent<RankData>();
            rankData.PlayerData = new playerData(PlayerDatas[i].rankNumber, PlayerDatas[i].playerName, PlayerDatas[i].playerScore);
            rankData.UpdateData();
        }

    }*/
}
