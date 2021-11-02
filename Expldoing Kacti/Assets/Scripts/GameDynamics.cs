using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDynamics : MonoBehaviour
{   
    Collider2D col;
    [System.NonSerialized]
    public static int playerHealth = 10;
    [System.NonSerialized]
    public static int cactiOnScreen = 0;
    [System.NonSerialized]
    public static int cactiAllowed = 10;
    [System.NonSerialized]
    public static int waterAmount = 5;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            
            if (touch.phase == TouchPhase.Began){
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider){
                    GameDynamics.waterAmount += 5;
                    if (GameDynamics.waterAmount > 10){
                        GameDynamics.waterAmount = 10;
                    }
                }
            }
        }
    
    }
}