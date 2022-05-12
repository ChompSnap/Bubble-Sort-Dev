using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    public static Warning instance;


    private void Awake()
    {
        instance = this;
    }

    public Transform bubble_warning;
    public float click_count;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            click_count += 1;


            if (click_count >= 80)
            {
                Debug.Log("Warning_Bubble_Down_80");
                bubble_warning.position = new Vector2(transform.position.x, -10f);
            }
            else if (click_count >= 76)
            {
                Debug.Log("Warning_Bubble_Down_76");
                bubble_warning.position = new Vector2(transform.position.x, -9.5f);
            }
            else if (click_count >= 72)
            {
                Debug.Log("Warning_Bubble_Down_72");
                bubble_warning.position = new Vector2(transform.position.x, -9f);
            }

            else if (click_count >= 68)
            {
                Debug.Log("Warning_Bubble_Down_68");
                bubble_warning.position = new Vector2(transform.position.x, -8.5f);
            }

            else if (click_count >= 64)
            {
                Debug.Log("Warning_Bubble_Down_64");
                bubble_warning.position = new Vector2(transform.position.x, -8f);
            }

            else if (click_count >= 60)
            {
                Debug.Log("Warning_Bubble_Down_60");
                bubble_warning.position = new Vector2(transform.position.x, -7.5f);
            }


            else if (click_count >= 56)
            {
                Debug.Log("Warning_Bubble_Down_56");
                bubble_warning.position = new Vector2(transform.position.x, -7f);
            }


            else if (click_count >= 52)
            {
                Debug.Log("Warning_Bubble_Down_52");
                bubble_warning.position = new Vector2(transform.position.x, -6.5f);
            }


            else if (click_count >= 48)
            {
                Debug.Log("Warning_Bubble_Down_48");
                bubble_warning.position = new Vector2(transform.position.x, -6f);
            }


            else if (click_count >= 44)
            {
                Debug.Log("Warning_Bubble_Down_44");
                bubble_warning.position = new Vector2(transform.position.x, -5.5f);
            }


            else if (click_count >= 40)
            {
                Debug.Log("Warning_Bubble_Down_40");
                bubble_warning.position = new Vector2(transform.position.x, -5f);
            }


            else if (click_count >= 36)
            {
                Debug.Log("Warning_Bubble_Down_36");
                bubble_warning.position = new Vector2(transform.position.x, -4.5f);
            }


            else if (click_count >= 32)
            {
                Debug.Log("Warning_Bubble_Down_32");
                bubble_warning.position = new Vector2(transform.position.x, -4f);
            }


            else if (click_count >= 28)
            {
                Debug.Log("Warning_Bubble_Down_28");
                bubble_warning.position = new Vector2(transform.position.x, -3.5f);
            }


            else if (click_count >= 24)
            {
                Debug.Log("Warning_Bubble_Down_24");
                bubble_warning.position = new Vector2(transform.position.x, -3f);
            }
            else if (click_count >= 20)
            {
                Debug.Log("Warning_Bubble_Down_20");
                bubble_warning.position = new Vector2(transform.position.x, -2.5f);
            }
            else if (click_count >= 16)
            {
                Debug.Log("Warning_Bubble_Down_16");
                bubble_warning.position = new Vector2(transform.position.x, -2f);
            }
            else if (click_count >= 12)
            {
                Debug.Log("Warning_Bubble_Down_12");
                bubble_warning.position = new Vector2(transform.position.x, -1.5f);
            }
            else if (click_count >= 8)
            {
                Debug.Log("Warning_Bubble_Down_8");
                bubble_warning.position = new Vector2(transform.position.x, -1f);
            }
            else if (click_count >= 4)
            {
                Debug.Log("Warning_Bubble_Down_4");
                bubble_warning.position = new Vector2(transform.position.x, -0.5f);
            }

        }
    }
}
