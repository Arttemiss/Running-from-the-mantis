using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public static levelManager LM;

    [SerializeField] GameObject mGameOver;
    
    void Start()
    {
        LM = this;
        mGameOver.SetActive(false);
    }

    
    public void GameOver()
    {
        mGameOver.SetActive(true);

        Time.timeScale = 0;//cambiar
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        mGameOver.SetActive(false);
        Time.timeScale = 1;
    }
}
