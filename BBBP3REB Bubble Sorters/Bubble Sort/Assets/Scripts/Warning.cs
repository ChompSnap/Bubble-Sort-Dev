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


            if (click_count == 100)
            {
                Debug.Log("Warning_Bubble_Down_100");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }

            else if (click_count == 96)
            {
                Debug.Log("Warning_Bubble_Down_96");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 92)
            {
                Debug.Log("Warning_Bubble_Down_92");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 88)
            {
                Debug.Log("Warning_Bubble_Down_88");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 84)
            {
                Debug.Log("Warning_Bubble_Down_84");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 80)
            {
                Debug.Log("Warning_Bubble_Down_80");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 76)
            {
                Debug.Log("Warning_Bubble_Down_76");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }

            else if (click_count == 72)
            {
                Debug.Log("Warning_Bubble_Down_72");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 68)
            {
                Debug.Log("Warning_Bubble_Down_68");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 64)
            {
                Debug.Log("Warning_Bubble_Down_64");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 60)
            {
                Debug.Log("Warning_Bubble_Down_60");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 56)
            {
                Debug.Log("Warning_Bubble_Down_56");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 52)
            {
                Debug.Log("Warning_Bubble_Down_52");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }

            else if (click_count == 48)
            {
                Debug.Log("Warning_Bubble_Down_48");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 44)
            {
                Debug.Log("Warning_Bubble_Down_44");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 40)
            {
                Debug.Log("Warning_Bubble_Down_40");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 36)
            {
                Debug.Log("Warning_Bubble_Down_36");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 32)
            {
                Debug.Log("Warning_Bubble_Down_32");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 28)
            {
                Debug.Log("Warning_Bubble_Down_28");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }

            else if (click_count == 24)
            {
                Debug.Log("Warning_Bubble_Down_24");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 20)
            {
                Debug.Log("Warning_Bubble_Down_20");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 16)
            {
                Debug.Log("Warning_Bubble_Down_16");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 12)
            {
                Debug.Log("Warning_Bubble_Down_12");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 8)
            {
                Debug.Log("Warning_Bubble_Down_8");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }
            else if (click_count == 4)
            {
                Debug.Log("Warning_Bubble_Down_4");
                CameraShake.instance.ShakeEffect();
                LevelManager.instance.AddNewLine();
            }

        }//bubble_warning.position = new Vector2(transform.position.x, -0.5f);
    }
}
