using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{

    scoreStorage ScoreStorage21;
    private void Start()
    {
        Cursor.visible = true;
        ScoreStorage21 = GameObject.FindWithTag("scoreStorage").GetComponent<scoreStorage>();
        ScoreStorage21.storedScore = 0;
    }

    public void Vintera()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void Zpet()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
