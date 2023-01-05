using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Scoremanager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI SecretText;
    [SerializeField] private TextMeshProUGUI MinigameText;
    [SerializeField] private TextMeshProUGUI TotalScoreText;
    public GameObject ScoreSecretInt;
    public GameObject ScoreSecretText;
    public GameObject ScorePassMinigame;
    public GameObject ScorePassMinigameINT;

    public int ScoreEndGame = 3333;
    public int SecretItem = 100;
    public int count = 0;
    public int count1 = 0;
    public int Minigame = 50;
    public int ScorePlayer = 0 ;
    
    [Header("Check Boolean")]
    public bool EndGame = false;
    public bool FindSecretItem = false;
    public bool MinigamePass = false;

    public static Scoremanager scoremanager;

    /*public int scorePlayer
    {
        get
        {
            return this.ScorePlayer;
        }
        set
        {
            this.ScorePlayer = value;
            SetScore(scorePlayer);
        }
    }*/
    
    private void Start()
    {
        ScoreSecretText.SetActive(false);
        ScoreSecretInt.SetActive(false);
        ScorePassMinigame.SetActive(false);
        ScorePassMinigameINT.SetActive(false);        
        EndGame = true;
    }
    private void Awake()
    {        
        if (scoremanager == null)
        {
            scoremanager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetScore(int score)
    {
        scoreText.text = $"{score}";
        TotalScoreText.text = $"{score}";        
        Debug.Log(ScorePlayer);
    }
    public void Update()
    {
        if (EndGame == true)
        {
            ScorePlayer += ScoreEndGame;
            SetScore(ScorePlayer);
            Debug.Log(ScorePlayer);
            //scoreText.text = $"{ScoreEndGame}";
            EndGame = false;
        }
        if(FindSecretItem == true)
        {
            ScorePlayer += SecretItem;
            count++;
            SetScore(ScorePlayer);            
            FindSecretItem = false;
        }
        if(MinigamePass == true)
        {
            ScorePlayer += Minigame;
            count1++;
            SetScore(ScorePlayer);
            MinigamePass = false;
        }
        if (count > 1)
        {
            ScoreSecretInt.SetActive(true);
            ScoreSecretText.SetActive(true);
            SecretText.text = $"{SecretItem*count}";
        }
        if (count1>1)
        {
            ScorePassMinigameINT.SetActive(true);
            ScorePassMinigame.SetActive(true);
            MinigameText.text = $"{Minigame*count1}";
        }
        //Debug.Log(ScorePlayer);
        //TotalScoreText.text = $"{ScorePlayer}";
    }

    public void SetScoreToFirebase()
    {
        Debug.Log(ScorePlayer);
        realTimeDatabase.real.setScoreData(ScorePlayer);
    }

}
