using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKacti : MonoBehaviour
{
    //public Sprite sprite;

    void Start()
    {
        var gameObject = new GameObject("Cacti");
        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        var sprite = Resources.Load<Sprite>("Kacti/normal_cacti");
        spriteRenderer.sprite = sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}


