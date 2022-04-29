using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelParser : MonoBehaviour
{
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
    
    public Transform levelRoot;
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");
        
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
                    redObject.transform.position = new Vector3(column, row, 0f);
                }
                
                if (letter == 'b')
                {
                    blueObject.transform.position = new Vector3(column, row, 0f);
                }
                
                if (letter == 'g')
                {
                    greenObject.transform.position = new Vector3(column, row, 0f);
                }

                if (letter == 'y')
                {
                    yellowObject.transform.position = new Vector3(column, row, 0f);
                }

                if (letter == 'o')
                {
                    orangeObject.transform.position = new Vector3(column, row, 0f);
                }

                if (letter == 'p')
                {
                    purpleObject.transform.position = new Vector3(column, row, 0f);
                }
                
                // Position the new GameObject at the appropriate location by using row and column
                // Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
        
    }
    
    private void ReloadLevel()
    {
        foreach (Transform child in levelRoot)
        {
            Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
