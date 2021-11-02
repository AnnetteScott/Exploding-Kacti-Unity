using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveKacti : MonoBehaviour
{
    public float minSpeed = 1;
    public float maxSpeed = 2;
    float speed = 50;
    public float secondsToMaxDifficulty = 120;
    Vector2 wellpos;
    // Start is called before the first frame update
    void Start()
    {
        wellpos = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {      
        if((Vector2)transform.position != wellpos){
            speed = Mathf.Lerp(minSpeed, maxSpeed, getDifficuiltyPercent());
            transform.position = Vector2.MoveTowards(transform.position, wellpos, speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Well"){
            Destroy(this.gameObject);
            ParticleSystem ps = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
            ps.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
            ps.Play();
        }
    }

    float getDifficuiltyPercent(){
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

}
