using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SceneDataManager : MonoBehaviour
{
    public static SceneDataManager Instance;

    public string targetName; // The detected target name
    public string description; // The description to display in the next scene
    public Sprite targetImage; // Optional: Image to display in DescriptionScene

    private void Awake()
    {
        // Ensure this GameObject persists across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CopyFilesFromResourcesToPersistentPath();
    }

    private void CopyFilesFromResourcesToPersistentPath()
    {
        // List of files to copy (no extensions here because Resources.Load doesn't use extensions)
        string[] fileNames = { "1", "2", "3", "4", "5",
            "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16",
            "17", "18", "19", "20", "21", "22", "23", "24", "25" };

        foreach (string fileName in fileNames)
        {
            // Load the text asset from Resources
            TextAsset textAsset = Resources.Load<TextAsset>(fileName);
            if (textAsset != null)
            {
                string destinationPath = Path.Combine(Application.persistentDataPath, fileName + ".txt");
                if (!File.Exists(destinationPath))
                {
                    File.WriteAllText(destinationPath, textAsset.text);
                    Debug.Log($"Copied {fileName}.txt to {destinationPath}");
                }
            }
            else
            {
                Debug.LogError($"Failed to load {fileName} from Resources.");
            }
        }
    }
}
