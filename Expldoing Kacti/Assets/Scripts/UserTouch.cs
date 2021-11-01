using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTouch : MonoBehaviour
{ 
    Collider2D col;
    bool explode = false;
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
                   explode = true;
                   //Debug.Log("this was touched");
               }
               if (explode == true){
                   Destroy(gameObject);
               }
            }
        }
    }
    
}
