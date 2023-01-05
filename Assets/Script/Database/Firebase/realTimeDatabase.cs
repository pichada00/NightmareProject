using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Proyecto26;
using Firebase.Database;
using SimpleJSON;

public class realTimeDatabase : MonoBehaviour
{
    DatabaseReference databaseReference;
    [SerializeField] private TMP_InputField username;
    [SerializeField] private int rankstart = 0;
    [SerializeField] private int scorestart = 0;
    [SerializeField] private GameObject startmenu;
    [SerializeField] private GameObject Leaderboard;
    private string url = "https://nightmare233-d4f33-default-rtdb.firebaseio.com";
    private string secret = "28K1O5rUlaZ03ezxTYH1ttxT5Fi4O6AJ9RAuR6pk";
    private string UsernameInput = "";
    private int Rankstart = 1;
    private int maxScore = 0;
    [Space]
    [Header("UI")]
    public TextMeshProUGUI rankText;
    //public Image profileImage;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI scoreText;
    public static realTimeDatabase real;


    private void Awake()
    {
        
        if (real == null)
        {
            real = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }
    [System.Serializable]

    public class UserInRealtimeCode
    {
        [System.Serializable]
        public class UserData
        {
            public int rank;
            public int score;
            public string username;

            public UserData(int Rank, string Username, int Score)
            {
                this.rank = Rank;                
                this.score = Score;
                this.username = Username;
            }
        }
        public List<UserData> userData;
    }

    public UserInRealtimeCode realtimeCode;

    private void Start()
    {
        if(startmenu)
        startmenu.SetActive(true);
        if(Leaderboard)
        Leaderboard.SetActive(false);
    }
    public void setData()
    {
        string urlData = $"{url}/{username.text}.json?auth={secret}";

        User.UserData user = new User.UserData(username.text, rankstart, scorestart);
        string json = JsonUtility.ToJson(user);



        RestClient.Get(urlData).Then(response =>
        {
            Debug.Log(response.Text);

            RestClient.Put<User.UserData>(urlData, user).Then(response =>
            {
                Debug.Log("Work!!");
            }).Catch(error =>
            {
                Debug.Log("error on set to server");
            });
            //user = new UserData(jSONNode["name"], jSONNode["rank"], jSONNode["score"]);
        }).Catch(error =>
        {
            Debug.Log("error");
        });
    }

    public void setScoreData(int scoreUpdate)
    {              
        string urlData = $"{url}/{username.text}.json?auth={secret}";
       
        User.UserData user = new User.UserData(username.text, rankstart, scoreUpdate);
        string json = JsonUtility.ToJson(user);

        RestClient.Get(urlData).Then(response =>
        {
            Debug.Log(response.Text);
            JSONNode jSONNode = JSONNode.Parse(response.Text);

            RestClient.Put<User.UserData>(urlData, user).Then(response =>
            {
                Debug.Log("Work!!");
            }).Catch(error =>
            {
                Debug.Log("error on set to server");
            });            
        }).Catch(error =>
        {
            Debug.Log("error");
        });
    }
    public void OpenLeaderBoard()
    {
        //Leaderboard.SetActive(true);
        //startmenu.SetActive(false);
        GetData();
    }
    public void CloseLeaderboard()
    {
        Leaderboard.SetActive(false);
        startmenu.SetActive(true);
    }
    public void GetData()
    {
        string urlData = $"{ url}/.json?auth={secret}";        
        RestClient.Get(urlData).Then(response =>
        {
            Debug.Log(response.Text);
            JSONNode jSONNode = JSONNode.Parse(response.Text);

            for (int i = 0; i < jSONNode.Count; i++)
            {                
                realtimeCode.userData.Add(new UserInRealtimeCode.UserData(jSONNode[i]["Rank"], jSONNode[i]["Username"], jSONNode[i]["Score"]));                             
                UpdateData(i);
                GameObject rankObj = Instantiate(Rankmanager.rankmanager.rankDataPrototype, Rankmanager.rankmanager.rankPanel) as GameObject;
                rankObj.SetActive(true);
                RankData rankData = rankObj.GetComponent<RankData>();
            }            
        }).Catch(error =>
        {
            Debug.Log("error");
        });
    }
    public void UpdateData(int i)
    {
        rankText.text = realtimeCode.userData[i].rank.ToString();
        playerNameText.text = realtimeCode.userData[i].username;
        scoreText.text = realtimeCode.userData[i].score.ToString();
    }
    
    public void UpdateScore(int Score)
    {
        var DBTask = databaseReference.Child("pichadallkk").Child("Score").SetValueAsync(Score);

        //yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if(DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Fail to register task with {DBTask.Exception}");
        }
        else
        {
            //Score Update
        }
    }

    
}
