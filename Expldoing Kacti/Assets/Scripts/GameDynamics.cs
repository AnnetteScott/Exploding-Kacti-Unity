using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDynamics : MonoBehaviour
{   
    
    public GameObject restartPanel;
    public Text score;


    [System.NonSerialized]
    public static int playerHealth = 10;
    [System.NonSerialized]
    public static int cactiOnScreen = 0;
    [System.NonSerialized]
    public static int cactiAllowed = 10;
    [System.NonSerialized]
    public static int waterAmount = 5;
    [System.NonSerialized]
    public static int scoreTotal = 0;
    [System.NonSerialized]
    public static float secondsToMaxDifficulty = 120;
    [System.NonSerialized]
    public static float minSpeed = 0.5F;
    [System.NonSerialized]
    public static float maxSpeed = 3;

    [System.NonSerialized]
    public static string[] cactiTypesArr = {"normal_cacti", "left_cacti", "right_cacti", "dead_cacti", "tumbleweed", "fire_cacti"};
    [System.NonSerialized]
    public static int[] spawnChanceArr = {        50,          67,            85,             93,           98,           100}; // spawnChance
    [System.NonSerialized]
    public static int[] cactiHealthArr = {        1,           1,             1,              1,            2,            4}; // cactiHealth
    [System.NonSerialized]
    public static int[] cactiPointsArr = {        1,           2,             2,              3,            4,            5}; // cactiPoints
    
    [System.NonSerialized]
    public static int[] number = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0}; // number array

    GameObject heartSprite;
    GameObject wellSprite;
    SpriteRenderer heartSpriteRenderer;
    SpriteRenderer wellSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        heartSprite = GameObject.FindGameObjectWithTag("Hearts");
        heartSpriteRenderer = heartSprite.GetComponent<SpriteRenderer>();
        wellSprite = GameObject.FindGameObjectWithTag("Well");
        wellSpriteRenderer = wellSprite.GetComponent<SpriteRenderer>();
        restartPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + GameDynamics.scoreTotal.ToString();
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
    }
    public void GameOver(){
       Invoke("Delay", 1.2f);
    }
}