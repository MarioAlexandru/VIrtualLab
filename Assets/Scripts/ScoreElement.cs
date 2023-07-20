using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreElement : MonoBehaviour
{
    public TMP_Text numeText;
    public TMP_Text scoreText;

    public void NewScoreElement(string name, int score)
    {
        numeText.text = name;
        scoreText.text = score.ToString();
    }
}
