using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    scoreStorage ScoreStorage21;
    JsonReadWrite jsonMan;
    void Start()
    {
        Cursor.visible = true;
        ScoreStorage21 = GameObject.FindWithTag("scoreStorage").GetComponent<scoreStorage>();
        jsonMan = ScoreStorage21.GetComponent<JsonReadWrite>();
        ShowScore();
        ShowHighScore();
    }
    void ShowScore()
    {
        scoreText.text += Convert.ToString(ScoreStorage21.storedScore);
    }

    void ShowHighScore()
    {
        jsonMan.LoadToJson();
        highscoreText.text += Convert.ToString(ScoreStorage21.highscore);
    }
}
