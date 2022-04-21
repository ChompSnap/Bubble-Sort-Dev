using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO 1: Make it we're able to detect when 3 or more matching bubbles are touching
/*
    Current idea:
    After firing bubble we check collisions, if any match color we store these game objects into an array 
    We check to see if after collision if touching bubbles are matching color if they are we store them into the array 
*/
//TODO 2: Destroy all of the bubbles that are touching 
/*
    At this point we know that all bubbles are matching so we pop em 
 */
//TODO 3: Make it so bubbles that are only touching any of those 3 bubbles fall down, just destroy them early on 
/*
    We should have checks for surrounding bubbles on the ends of the array, if they arent touching the walls/roof 
    we drop them, play an animation and then destroy 
 */
public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Basically todo 1 should go here
    private void OnCollisionEnter2D(Collision2D col)
    {
        
    }
}
