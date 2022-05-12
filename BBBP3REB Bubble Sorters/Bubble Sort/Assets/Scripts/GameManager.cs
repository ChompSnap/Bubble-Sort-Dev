using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    //public Button home_btn;
    public Shooter shootScript;
    public Transform pointerToLastLine;

    private int sequenceSize = 3;
    [SerializeField]
    private List<Transform> bubbleSequence;

    public delegate void bubblePop(int score);

    public static event bubblePop addScore;



    void Start()
    {
        //home_btn.onClick.AddListener(Home_btn_Click);

        bubbleSequence = new List<Transform>();

        LevelManager.instance.GenerateLevel();

        shootScript.canShoot = true;
        shootScript.CreateNextBubble();
    }

    void Update()
    {
        if (shootScript.canShoot
            && Input.GetMouseButtonUp(0)
            && (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > shootScript.transform.position.y))
        {
            shootScript.canShoot = false;
            shootScript.Shoot();

        }
    }

    void Home_btn_Click()
    {
        SceneManager.LoadScene(0);
    }
    public void ProcessTurn(Transform currentBubble)
    {
        bubbleSequence.Clear();
        CheckBubbleSequence(currentBubble);

        if (bubbleSequence.Count >= sequenceSize)
        {
            DestroyBubblesInSequence();
            DropDisconectedBubbles();
        }

        LevelManager.instance.UpdateListOfBubblesInScene();

        shootScript.CreateNextBubble();
        shootScript.canShoot = true;
    }

    private void CheckBubbleSequence(Transform currentBubble)
    {
        bubbleSequence.Add(currentBubble);

        Bubble bubbleScript = currentBubble.GetComponent<Bubble>();
        List<Transform> neighbors = bubbleScript.GetNeighbors();

        foreach (Transform t in neighbors)
        {
            if (!bubbleSequence.Contains(t))
            {

                Bubble bScript = t.GetComponent<Bubble>();

                if (bScript.bubbleColor == bubbleScript.bubbleColor)
                {
                    CheckBubbleSequence(t);
                }
            }
        }
    }

    private void DestroyBubblesInSequence()
    {
        foreach (Transform t in bubbleSequence)
        {
            Destroy(t.gameObject);
        }
        addScore?.Invoke(10 * bubbleSequence.Count);
    }

    private void DropDisconectedBubbles()
    {
        SetAllBubblesConnectionToFalse();
        SetConnectedBubblesToTrue();
        SetGravityToDisconectedBubbles();

    }

    #region Drop Disconected Bubbles
    private void SetAllBubblesConnectionToFalse()
    {
        foreach (Transform bubble in LevelManager.instance.bubblesArea)
        {
            bubble.GetComponent<Bubble>().isConnected = false;
            //Debug.Log("All_Down");
        }
    }

    private void SetConnectedBubblesToTrue()
    {
        bubbleSequence.Clear();

        RaycastHit2D[] hits = Physics2D.RaycastAll(pointerToLastLine.position, pointerToLastLine.right, 15f);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.gameObject.tag.Equals("Bubble"))
                SetNeighboursConnectionToTrue(hits[i].transform);

        }
    }

    private void SetNeighboursConnectionToTrue(Transform bubble)
    {
        Bubble bubbleScript = bubble.GetComponent<Bubble>();
        bubbleScript.isConnected = true;
        bubbleSequence.Add(bubble);

        foreach (Transform t in bubbleScript.GetNeighbors())
        {
            if (!bubbleSequence.Contains(t))
            {
                SetNeighboursConnectionToTrue(t);
            }
        }
    }

    private void SetGravityToDisconectedBubbles()
    {
        foreach (Transform bubble in LevelManager.instance.bubblesArea)
        {
            if (!bubble.GetComponent<Bubble>().isConnected)
            {
                bubble.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                if (!bubble.GetComponent<Rigidbody2D>())
                {
                    Rigidbody2D rb2d = bubble.gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
                    bubble.gameObject.GetComponent<CircleCollider2D>().enabled = true;
                    bubble.tag = "FallingBubble";
                    //Debug.Log("Balls_Falling");
                }
            }
        }
    }
    #endregion
}