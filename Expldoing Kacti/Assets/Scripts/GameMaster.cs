using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public void GoToGameScene(){
        SceneManager.LoadScene("GameScene");
    }    
    
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }   
    
    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
    public void addWater(){
        GameDynamics.waterAmount += 5;
        if (GameDynamics.waterAmount > 10){
            GameDynamics.waterAmount = 10;
        }
        Debug.Log("This ran");

    }
}
