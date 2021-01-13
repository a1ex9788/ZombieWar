using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void PauseGame() {

    }

    public void RestartGame() {
        SceneManager.LoadScene("SurvivalMode");
    }

    public void GoHomeScreen() {
        SceneManager.LoadScene("HomeScreen");
    }
}
