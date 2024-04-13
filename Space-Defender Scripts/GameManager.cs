using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameManager : MonoBehaviour
{

    public int i;
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public GameObject player;
    magazine mag;
    health hp;
    scoreStorage ScoreStorage21;
    JsonReadWrite jsonMan;
    

    [SerializeField] public int score = 0; 
    void Start()
    {
        
        mag = player.GetComponent<magazine>();
        hp = player.GetComponent<health>();
        Cursor.visible = false;
        ScoreStorage21 = GameObject.FindWithTag("scoreStorage").GetComponent<scoreStorage>();
        jsonMan = ScoreStorage21.GetComponent<JsonReadWrite>();
        score = ScoreStorage21.storedScore;
        
    }
    void Update()
    {
        string json = File.ReadAllText(Application.dataPath + "/DataFile.json");
        Data data = JsonUtility.FromJson<Data>(json);
        i = Convert.ToInt32(data.score);
        text1.text = mag.leftInMag + "/7";
        text2.text = hp._health + "/100";
        text3.text = score.ToString();

        if(score > ScoreStorage21.scoreNeeded)
        {
            StartCoroutine(loadBoss());
        }
    }

    IEnumerator loadBoss()
    {
        ScoreStorage21.storedScore = score;
        ScoreStorage21.scoreNeeded += 25000;
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(2);
    }

    public IEnumerator loadgameOver()
    {

        ScoreStorage21.storedScore = score;
        if(score > ScoreStorage21.highscore)
        {
            jsonMan.SaveToJson();
        }
        yield return new WaitForSeconds(0.2f);
        player.transform.localScale = new Vector3(2, 2, 1);
        yield return new WaitForSeconds(1.8f);
        SceneManager.LoadScene(3);
    }
    
    
}
