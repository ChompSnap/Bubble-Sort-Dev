 using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelParser : MonoBehaviour
{
    public Grid grid;
    public Transform bubblesArea;
    public string filename;

    [FormerlySerializedAs("redBubble")] 
    public GameObject RedPrefab;
    [FormerlySerializedAs("blueBubble")] 
    public GameObject BluePrefab;
    [FormerlySerializedAs("greenBubble")] 
    public GameObject GreenPrefab;
    [FormerlySerializedAs("yellowBubble")] 
    public GameObject YellowPrefab;
    [FormerlySerializedAs("orangeBubble")] 
    public GameObject OrangePrefab;
    [FormerlySerializedAs("purpleBubble")] 
    public GameObject PurplePrefab;
    
    public float offset = 1f;
    public GameObject leftLine;
    public GameObject rightLine;
    private bool lastLineIsLeft = true;
    //public Transform levelRoot;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
        grid = GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.R))
       // {
       //     ReloadLevel();
       // }
    }

    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resource/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");
        SnapChildrensToGrid(bubblesArea);
        Stack<string> levelRows = new Stack<string>();
        
        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                // Instantiate a new GameObject that matches the type specified by letter
                var redObject = Instantiate(RedPrefab);
                var blueObject = Instantiate(BluePrefab);
                var greenObject = Instantiate(GreenPrefab);
                var yellowObject = Instantiate(YellowPrefab);
                var orangeObject = Instantiate(OrangePrefab);
                var purpleObject = Instantiate(PurplePrefab);
                
                if (letter == 'r')
                {
                    redObject.transform.position = new Vector2(column, row);
                    //redObject.transform.position = new Vector3(column, row, 0f);
                }
                
                if (letter == 'b')
                {
                    blueObject.transform.position = new Vector2(column, row);
                }
                
                if (letter == 'g')
                {
                    greenObject.transform.position = new Vector2(column, row);
                }

                if (letter == 'y')
                {
                    yellowObject.transform.position = new Vector2(column, row);
                }

                if (letter == 'o')
                {
                    orangeObject.transform.position = new Vector2(column, row);
                }

                if (letter == 'p')
                {
                    purpleObject.transform.position = new Vector2(column, row);
                }
                
                // Position the new GameObject at the appropriate location by using row and column
                // Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
        
    }
    
 //   private void ReloadLevel()
 //   {
 //       foreach (Transform child in levelRoot)
 //       {
 //           Destroy(child.gameObject);
 //       }
 //       LoadLevel();
 //   }
    
    private void SnapChildrensToGrid(Transform parent)
    {
        foreach (Transform t in parent)
        {
            SnapToNearestGripPosition(t);
        }
    }
    
    public void SnapToNearestGripPosition(Transform t)
    {
        Vector3Int cellPosition = grid.WorldToCell(t.position);
        t.position = grid.GetCellCenterWorld(cellPosition);
    }
    
    public void SetAsBubbleAreaChild(Transform bubble)
    {
        SnapToNearestGripPosition(bubble);
        bubble.SetParent(bubblesArea);
    }
    
    public void AddNewLine()
    {
        OffsetGrid();
        OffsetBubblesInScene();
        GameObject newLine = lastLineIsLeft == true ? Instantiate(rightLine) : Instantiate(leftLine); 
        //FillWithBubbles(newLine, bubblesInScene);
        SnapChildrensToGrid(bubblesArea);
        lastLineIsLeft = !lastLineIsLeft;
    }

    private void OffsetGrid()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - offset);
    }

    private void OffsetBubblesInScene()
    {
        foreach (Transform t in bubblesArea)
        {
            t.transform.position = new Vector2(t.position.x, t.position.y - offset);
        }
    }
}
