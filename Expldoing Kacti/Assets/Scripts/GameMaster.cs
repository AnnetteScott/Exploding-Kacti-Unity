using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject restartPanel;

    public Text score;

    public void Update(){
        score.text = "Score: " + GameDynamics.scoreTotal.ToString();
    } 

    public void GameOver(){
        Invoke("Delay", 1.2f);
    }
    
    public void GoToGameScene(){
        GameDynamics.playerHealth = 10;
        GameDynamics.cactiOnScreen = 0;
        GameDynamics.cactiAllowed = 10;
        GameDynamics.waterAmount = 5;
        GameDynamics.scoreTotal = 0;
        restartPanel.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }    
    
    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    void Delay(){
        restartPanel.SetActive(true);
    }
    
}
