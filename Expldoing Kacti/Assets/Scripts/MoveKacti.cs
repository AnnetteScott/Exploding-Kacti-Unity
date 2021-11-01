using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKacti : MonoBehaviour
{
    public float speed = 5;
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
            transform.position = Vector2.MoveTowards(transform.position, wellpos, speed * Time.deltaTime);
        }
    }

}
