using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 150.0f;
    public float rotation = 0;
    private float rotateHold;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //This function acts as the player controller and rotates the launcher up to 90 degrees on either side
        if (Input.GetKey(KeyCode.A))
        {
            rotateHold = rotation + 1.0f * speed * Time.deltaTime;
            if (rotateHold < 90)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotateHold);
                rotation = rotateHold;
                Debug.Log(rotateHold);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotateHold = rotation + -1.0f * speed * Time.deltaTime;
            if (rotateHold > -90)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotateHold);
                rotation = rotateHold;
            }
        }

    }
}
