using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    [SerializeField]
    private TMP_InputField input;
    [SerializeField]
    private PuzzleManager puzzleManager;
    void Awake()
    {
        LoadScores();
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void AddScore()
    {
        if (input.text != "")
        {
            Score score = new Score(input.text, puzzleManager.score);
            input.text = "";
            sd.scores.Add(score);
            SaveScore();
        }
    }

    public void LoadScores()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }
}
