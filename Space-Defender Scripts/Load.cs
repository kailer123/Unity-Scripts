using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        Cursor.visible = true;
    }

    public void Vintera()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Zpet()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
