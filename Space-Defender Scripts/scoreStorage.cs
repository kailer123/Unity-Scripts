using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreStorage : MonoBehaviour
{
    JsonReadWrite jsonMan;
    private void Start()
    {
        jsonMan = this.GetComponent<JsonReadWrite>();
        jsonMan.LoadToJson();
    }

    public int storedScore = 0;
    public int scoreNeeded = 25000;
    public int highscore = 0;
}
