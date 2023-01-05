using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public class UserData
    {
        public string Username;
        public int Rank;
        public int Score;

        public UserData(string username, int rank, int score)
        {
            this.Username = username;
            this.Rank = rank;
            this.Score = score;
        }
    }

}
