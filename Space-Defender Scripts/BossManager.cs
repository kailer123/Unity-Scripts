using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    magazine mag;
    health hp;
    public GameObject player;
    int neededScore = 25000;
    [SerializeField] public int score = 0;
    // Start is called before the first frame update
    void Start()
    {

        mag = player.GetComponent<magazine>();
        hp = player.GetComponent<health>();
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        text1.text = mag.leftInMag + "/7";
        text2.text = hp._health + "/100";
    }
}