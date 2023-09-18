using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    public void PlayAgin()
    {
        SceneManager.LoadScene("minigame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
