using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    
    public void GoToGameScene(){
        GameDynamics.playerHealth = 10;
        GameDynamics.cactiOnScreen = 0;
        GameDynamics.cactiAllowed = 10;
        GameDynamics.waterAmount = 5;
        GameDynamics.scoreTotal = 0;
        SceneManager.LoadScene("GameScene");
    }    
    
    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    
}
