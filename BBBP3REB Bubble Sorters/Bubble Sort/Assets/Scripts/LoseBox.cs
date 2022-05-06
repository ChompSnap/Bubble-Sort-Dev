using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseBox : MonoBehaviour
{
    public delegate void bubbleFell(int score);
    
    public static event bubbleFell add500;

    public BoxCollider2D box;
    
    // Start is called before the first frame update
    void Start()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("FallingBubble"))
        {
            add500?.Invoke(500);
            
            //This was used to test to see if the bubble was of the correct tag 
            //Debug.Log("Falling bubble touched box");
            
            //We destroy the game object so it can't bump into the bubble in the cannon or the one being held 
            Destroy(col.gameObject);
        }
    }
}
