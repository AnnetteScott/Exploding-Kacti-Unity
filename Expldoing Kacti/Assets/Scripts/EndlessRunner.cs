using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessRunner : MonoBehaviour
{
    [System.NonSerialized]
    public static int playerHealth = 10;
    [System.NonSerialized]
    public static int cactiOnScreen = 0;
    [System.NonSerialized]
    public static int waterAmount = 5;
    [System.NonSerialized]
    public static int scoreTotal = 0;
    

    GameObject heartSprite;
    GameObject wellSprite;
    SpriteRenderer heartSpriteRenderer;
    SpriteRenderer wellSpriteRenderer;
    public GameObject restartPanel;
    public Text score;
    public static int[] number = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0};


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = EndlessSettings.playerHealthStart;
        cactiOnScreen = EndlessSettings.cactiOnScreenStart;
        waterAmount = EndlessSettings.waterAmountStart;
        scoreTotal = EndlessSettings.scoreTotalStart;
        heartSprite = GameObject.FindGameObjectWithTag("Hearts");
        heartSpriteRenderer = heartSprite.GetComponent<SpriteRenderer>();
        wellSprite = GameObject.FindGameObjectWithTag("Well");
        wellSpriteRenderer = wellSprite.GetComponent<SpriteRenderer>();
        restartPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreTotal.ToString();
        if(playerHealth > 10){
            playerHealth = 10;
        }
        //Health and Well
        foreach(int health in number){
            if(health == playerHealth){
                //Hearts
                var heart = Resources.Load<Sprite>("Health/" + health);
                heartSpriteRenderer.sprite = heart;
            }
        }    
        //Well water Level
        foreach(int water in number){
            if(water == waterAmount){
                //Hearts
                var waterImg = Resources.Load<Sprite>("WellWater/" + water);
                wellSpriteRenderer.sprite = waterImg;
                //Well
                break;
            }
        }
    }
    void Delay(){
        restartPanel.SetActive(true);
        score.color = Color.white;
    }
    public void GameOver(){
       Invoke("Delay", 1.2f);
    }
}
