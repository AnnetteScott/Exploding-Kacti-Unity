using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveKacti : MonoBehaviour
{
    public float minSpeed = 1;
    public float maxSpeed = 5;
    bool explode = false;
    bool enoughWater = false;
    float speed = 50;
    public float secondsToMaxDifficulty = 120;
    Vector2 wellpos;
    Collider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        wellpos = new Vector2(0, 0);
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {      
        if(GameDynamics.playerHealth <= 0){
            GameDynamics.waterAmount = 5;
            GameDynamics.playerHealth = 10;
            GameDynamics.cactiOnScreen = 0;
            SceneManager.LoadScene("RestartScene");
        }
        else {
            if((Vector2)transform.position != wellpos){
                speed = Mathf.Lerp(minSpeed, maxSpeed, getDifficuiltyPercent());
                transform.position = Vector2.MoveTowards(transform.position, wellpos, speed * Time.deltaTime);
            }
            if(Input.touchCount > 0){
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                
                if (touch.phase == TouchPhase.Began){
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    if (col == touchedCollider){
                        explode = true;
                        if(GameDynamics.waterAmount > 0){
                            enoughWater = true;
                        }
                       
                        Debug.Log(GameDynamics.waterAmount);
                    }
                    if (explode == true && enoughWater == true){
                        Destroy(this.gameObject);
                        ParticleSystem ps = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
                        ps.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
                        ps.Play();
                        GameDynamics.cactiOnScreen -= 1;
                        GameDynamics.waterAmount -= 1;
                    }
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Well"){
            Destroy(this.gameObject);
            ParticleSystem ps = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
            ps.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
            ps.Play();
            GameDynamics.playerHealth -= 1;
            GameDynamics.cactiOnScreen -= 1;
        }
    }

    float getDifficuiltyPercent(){
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

}
