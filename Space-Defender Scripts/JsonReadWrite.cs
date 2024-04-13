using System;
using System.IO;
using UnityEngine;

public class JsonReadWrite : MonoBehaviour
{
    public scoreStorage scoreScript;
    public void SaveToJson()
    {
        Debug.Log("XD");
        Data data = new Data();
        data.score = Convert.ToString(scoreScript.storedScore);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/DataFile.json", json);
    }

    public void LoadToJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/DataFile.json");
        Data data = JsonUtility.FromJson<Data>(json);

        scoreScript.highscore = Convert.ToInt32(data.score);
    }
}
