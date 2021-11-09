using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenes : MonoBehaviour
{
    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToEndlessMode(){
        SceneManager.LoadScene("EndlessScene");
    }    
    

}
