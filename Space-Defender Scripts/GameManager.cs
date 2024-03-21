using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    magazine mag;
    health hp;
    public GameObject player;
    int neededScore = 25000;
    scoreStorage ScoreStorage21;

    [SerializeField] public int score = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
        mag = player.GetComponent<magazine>();
        hp = player.GetComponent<health>();
        Cursor.visible = false;
        ScoreStorage21 = GameObject.FindWithTag("scoreStorage").GetComponent<scoreStorage>();
        score = ScoreStorage21.storedScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = mag.leftInMag + "/7";
        text2.text = hp._health + "/100";
        text3.text = score.ToString();

        if(score > ScoreStorage21.scoreNeeded)
        {
            ScoreStorage21.storedScore = score;
            ScoreStorage21.scoreNeeded += 25000;
            SceneManager.LoadScene(2);
        }
    }
}
