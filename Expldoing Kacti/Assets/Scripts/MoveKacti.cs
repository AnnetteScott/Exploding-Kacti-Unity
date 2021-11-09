using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveKacti : MonoBehaviour
{
    float speed = 1;
    int health;
    int points;
    Vector2 wellpos;
    Collider2D col;

    private EndlessRunner gm;
    
    // Start is called before the first frame update
    void Start()
    {
        wellpos = new Vector2(0, 0);
        col = GetComponent<Collider2D>();
        CactiHealthPoints();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<EndlessRunner>();
    }

    // Update is called once per frame
    void Update()
    {      
        if(EndlessRunner.playerHealth <= 0){
            gm.GameOver();
        }
        else {
            if((Vector2)transform.position != wellpos){
                speed = Mathf.Lerp(EndlessSettings.minSpeed, EndlessSettings.maxSpeed, getDifficuiltyPercent());
                transform.position = Vector2.MoveTowards(transform.position, wellpos, speed * Time.deltaTime);
            }
            if(Input.touchCount > 0){
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                
                if (touch.phase == TouchPhase.Began){
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    if (col == touchedCollider){
                        if (EndlessRunner.waterAmount > 0){
                            if(health > 1){
                                health -= 1;
                                EndlessRunner.waterAmount -= 1;
                                ParticleSystem wps = GameObject.Find("WaterParticle").GetComponent<ParticleSystem>();
                                wps.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
                                wps.Play();
                            }
                            else {
                                Destroy(this.gameObject);
                                EndlessRunner.waterAmount -= 1;
                                EndlessRunner.cactiOnScreen -= 1;                    
                                EndlessRunner.scoreTotal += points;  
                                ParticleSystem ps = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
                                ps.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
                                ps.Play();
                            }
                        }
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
            EndlessRunner.playerHealth -= 1;
            EndlessRunner.cactiOnScreen -= 1;
        }
    }

    float getDifficuiltyPercent(){
        return Mathf.Clamp01(Time.timeSinceLevelLoad / EndlessSettings.secondsToMaxDifficulty);
    }

    void CactiHealthPoints(){
        string sprite = this.gameObject.name;
        int counter = 0;
        foreach(string cactiName in KactiSettings.cactiTypesArr){
            if (sprite == cactiName){
                health = KactiSettings.cactiHealthArr[counter];
                points = KactiSettings.cactiPointsArr[counter];
                
                break;
            }
            counter += 1;
        }
    }
}
