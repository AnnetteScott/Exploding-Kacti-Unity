using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKacti : MonoBehaviour
{
    private int[] topY = {6, 11};
    private int[] bottomY = {-6, -11};
    private int[] rightX = {11, 16};
    private int[] leftX = {-11, -16};
    public int CactiAllowed = 1;
    public int CactiOnScreen = 0;

    Vector2 spawnPosition;
    // Start is called at the start
    void Start()
    {   
        spawnCacti();
        CactiOnScreen += 1;
    }
    // Update is called once per frame
    void Update()
    {
        if(CactiOnScreen < CactiAllowed){
            spawnCacti();
            CactiOnScreen += 1;
        }
    }
 
    Vector2 GetRandomPosition(){
        float randomX = 0;
        float randomY = 5;          
        int randomSide = Random.Range(1, 5);
        if (randomSide == 1){   //Top of Screen
            randomX = Random.Range(leftX[1], rightX[1]);
            randomY = Random.Range(topY[0], topY[1]);
        }
        else if(randomSide == 2){ //  Left of Screen
            randomX = Random.Range(rightX[0], rightX[1]);
            randomY = Random.Range(bottomY[1], topY[1]);
        }
        else if(randomSide == 3){   //Bottom of Screen
            randomX = Random.Range(leftX[1], rightX[1]);
            randomY = Random.Range(bottomY[0], bottomY[1]);
        }
        else if(randomSide == 4){   //Right of Screen
            randomX = Random.Range(leftX[0], leftX[1]);
            randomY = Random.Range(bottomY[1], topY[1]);
        }
        return new Vector2(randomX, randomY);
        
    }

    public void spawnCacti(){
        spawnPosition = GetRandomPosition();
        var gameObject = new GameObject("Cacti");
        gameObject.transform.localScale = new Vector3(1.2F, 1.2F, 1);
        gameObject.transform.position = new Vector3(spawnPosition[0], spawnPosition[1], 0);
        gameObject.AddComponent<MoveKacti>();
        //gameObject.AddComponent<UserTouch>();
        gameObject.AddComponent<CircleCollider2D>();
        gameObject.tag = "Cacti";
        var setTrigger = gameObject.GetComponent<CircleCollider2D>();
        setTrigger.isTrigger = true;

        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        var sprite = Resources.Load<Sprite>("Kacti/normal_cacti");
        spriteRenderer.sprite = sprite;
    }
}


