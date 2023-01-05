using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class playerData
{
    public int rankNumber;    
    public string playerName;
    public int playerScore;

    public playerData(int rankN, string Name, int Score)
    {
        this.rankNumber = rankN;        
        this.playerName = Name;
        this.playerScore = Score;
    }    
}
public class RankData : MonoBehaviour
{
    public playerData PlayerData;

    [Space]
    [Header("UI")]
    public TextMeshProUGUI rankText;
    //public Image profileImage;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateData()
    {
        rankText.text = PlayerData.rankNumber.ToString();
        //profileImage.sprite = PlayerData.profileSprite;
        playerNameText.text = PlayerData.playerName;
        scoreText.text = PlayerData.playerScore.ToString();
    }

}
