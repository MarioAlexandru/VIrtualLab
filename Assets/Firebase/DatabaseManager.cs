using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase;
using Firebase.Database;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class DatabaseManager : MonoBehaviour
{
    public TMP_InputField numeInput;
    public GameObject puzzleManager;
    public GameObject timeManager;
    public GameObject scoreElement;
    public Transform scoreboardContent;
    private PuzzleManager _puzzleManager;
    private TimeManager _timeManager;
    public GameObject submitScoreScreen;
    public GameObject scoreboardScreen;

    const string url = "https://virtual-lab-f8389-default-rtdb.europe-west1.firebasedatabase.app/";
    private DatabaseReference dbReference;

    void Start()
    {
        _puzzleManager = puzzleManager.GetComponent<PuzzleManager>();
        _timeManager = timeManager.GetComponent<TimeManager>();
        dbReference = FirebaseDatabase.GetInstance(url).RootReference;
    }
    public void ScoreboardButton()
    {
        StartCoroutine(LoadLeaderboard());
    }

    public void BackButton()
    {
        submitScoreScreen.SetActive(true);
        scoreboardScreen.SetActive(false);
    }

    public void CreateUser()
    {
        //User newUser = new User(numeInput.text, (int)_timeManager.time, _puzzleManager.score);
        //string json = JsonUtility.ToJson(newUser);
        string key = dbReference.Child("Leaderboard").Push().Key;

        LeaderboardEntry entry = new LeaderboardEntry(numeInput.text, _puzzleManager.score);
        Dictionary<string, System.Object> entryValues = entry.ToDictionary();

        Dictionary<string, System.Object> childUpdates = new Dictionary<string, System.Object>();
        
        //childUpdates["/scores/" + key] = entryValues;
        childUpdates["Leaderboard/" + key] = entryValues;


        dbReference.UpdateChildrenAsync(childUpdates);
    }

    private IEnumerator LoadLeaderboard()
    {
        var dbTask = dbReference.Child("Leaderboard").OrderByChild("score").GetValueAsync();

        yield return new WaitUntil(predicate: () => dbTask.IsCompleted);

        if(dbTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {dbTask.Exception}");
        }
        else
        {
            DataSnapshot snapShot = dbTask.Result;
            
            foreach(Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            foreach(DataSnapshot childSnapshot in snapShot.Children.Reverse<DataSnapshot>())
            {
                string nume = childSnapshot.Child("uid").Value.ToString();
                int score = int.Parse(childSnapshot.Child("score").Value.ToString());

                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(nume,score);
            }

            submitScoreScreen.SetActive(false);
            scoreboardScreen.SetActive(true);
        }
    }

    public class LeaderboardEntry
    {
        public string uid;
        public int score = 0;

        public LeaderboardEntry()
        {
        }

        public LeaderboardEntry(string uid, int score)
        {
            this.uid = uid;
            this.score = score;
        }

        public Dictionary<string, System.Object> ToDictionary()
        {
            Dictionary<string, System.Object> result = new Dictionary<string, System.Object>();
            result["uid"] = uid;
            result["score"] = score;

            return result;
        }
    }
    public void Update()
    {
        //var dbref = FirebaseDatabase.DefaultInstance.GetReference("Leaderboard");
        //
        //dbref.ChildAdded += HandleChildAdded;
    }

    void HandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        Debug.Log(args.Snapshot.Key);
        // Do something with the data in args.Snapshot
    }
}
