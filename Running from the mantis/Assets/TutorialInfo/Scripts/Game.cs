using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public void GameMenu()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;

    }
}
