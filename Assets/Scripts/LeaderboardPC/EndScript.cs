using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField]private GameObject scoreboard;
    [SerializeField]private ScoreManager scoreManager;
    [SerializeField]private ScoreUI gameUi;
    public void ShowScoreBoard()
    {
        scoreManager.AddScore();
        this.gameObject.SetActive(false);
        scoreboard.SetActive(true);
        scoreManager.LoadScores();
        gameUi.UpdateUi();
    }
    public void ShowEnd()
    {
        this.gameObject.SetActive(true);
        scoreboard.SetActive(false);
        gameUi.DeleteUI();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Joculet");
    }
}
