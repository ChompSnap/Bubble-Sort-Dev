using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour
{
    public Transform gunSprite;
    public Animator firingAnim;
    public bool canShoot;
    public float speed = 6f;

    public Transform nextBubblePosition;
    public GameObject currentBubble;
    public GameObject nextBubble;

    private Vector2 lookDirection;
    private float lookAngle;
    public bool isSwaping = false;
    public float time = 0.02f;
    int count = 0;
    public void Update()
    {
        //Rotating the launcher
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        gunSprite.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);



        if(isSwaping)
        {
            if(Vector2.Distance(currentBubble.transform.position, nextBubblePosition.position) <= 0.2f
                && Vector2.Distance(nextBubble.transform.position, transform.position) <= 0.2f)
            {
                nextBubble.transform.position = transform.position;
                currentBubble.transform.position = nextBubblePosition.position;

                currentBubble.GetComponent<Collider2D>().enabled = true;
                nextBubble.GetComponent<Collider2D>().enabled = true;

                isSwaping = false;

                GameObject reference = currentBubble;
                currentBubble = nextBubble;
                nextBubble = reference;
            }

            nextBubble.transform.position = Vector2.Lerp(nextBubble.transform.position, transform.position, time);
            currentBubble.transform.position = Vector2.Lerp(currentBubble.transform.position, nextBubblePosition.position, time);
        }
    }

    public void Shoot()
    {
        if(currentBubble.GetComponent<Rigidbody2D>() == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
            currentBubble.transform.rotation = transform.rotation;
            currentBubble.GetComponent<Rigidbody2D>().AddForce(currentBubble.transform.up * speed, ForceMode2D.Impulse);
            currentBubble.transform.parent = null;
            firingAnim.Play("GunShoot", 0, 0);
            currentBubble = null;
        }
        count++;
        if(count==4)
        {
            count = 0;
            StartCoroutine(StartMove(.1f));
        }

    }
    public IEnumerator StartMove(float move)
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        CameraEffects.instance.Shake();
        canShoot = true;
        //while(move>=0)
        //{
        //    move -= Time.deltaTime;
        //    GameLevel.transform.position -= new Vector3(0, 20, 0) * Time.deltaTime;
        //    Manager.transform.position -= new Vector3(0, 20, 0) * Time.deltaTime;

        //    yield return new WaitForSeconds(.09f);
        //}

    }

    [ContextMenu("SwapBubbles")]
    public void SwapBubbles()
    {
        currentBubble.GetComponent<Collider2D>().enabled = false;
        nextBubble.GetComponent<Collider2D>().enabled = false;
        isSwaping = true;
    }

    [ContextMenu("CreateNextBubble")]
    public void CreateNextBubble()
    {
        List<GameObject> bubblesInScene = LevelManager.instance.bubblesInScene;
        List<string> colors = LevelManager.instance.colorsInScene;

        if (nextBubble == null)
        {
            nextBubble = InstantiateNewBubble(bubblesInScene);
        }
        else
        {
            if(!colors.Contains(nextBubble.GetComponent<Bubble>().bubbleColor.ToString()))
            {
                Destroy(nextBubble);
                nextBubble = InstantiateNewBubble(bubblesInScene);
            }
        }

        if(currentBubble == null)
        {
            currentBubble = nextBubble;
            currentBubble.transform.parent = gunSprite;
            currentBubble.transform.position = gunSprite.GetChild(0).position;
            nextBubble = InstantiateNewBubble(bubblesInScene);
        }
    }

    private GameObject InstantiateNewBubble(List<GameObject> bubblesInScene)
    {
        GameObject newBubble = Instantiate(bubblesInScene[(int)(Random.Range(0, bubblesInScene.Count * 1000000f) / 1000000f)]);
        newBubble.transform.position = new Vector2(nextBubblePosition.position.x, nextBubblePosition.position.y);
        newBubble.GetComponent<Bubble>().isFixed = false;
        Rigidbody2D rb2d = newBubble.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rb2d.gravityScale = 0f;

        return newBubble;
    }
}
