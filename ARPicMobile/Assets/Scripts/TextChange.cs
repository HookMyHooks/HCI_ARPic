using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Vuforia;
using System.IO;
using System.Collections.Generic;

public class TextChange : MonoBehaviour
{
    public Dictionary<string, Sprite> targetSprites = new Dictionary<string, Sprite>();

    private void Start()
    {
        // Preload your sprites into the dictionary
        LoadSprites();
    }

    public void ChangeText()
    {
        var imageTarget = GetComponent<ImageTargetBehaviour>();
        if (imageTarget == null)
        {
            Debug.LogError("ImageTargetBehaviour component not found!");
            return;
        }

        string targetName = imageTarget.TargetName;

        // Construct the path to the text file
        string filePath = Path.Combine(Application.persistentDataPath, $"{targetName}.txt");
      
        if (targetName == "3_1" || targetName == "3_2" || targetName == "3_3")
        {
            filePath = Path.Combine(Application.persistentDataPath, "3.txt");
        }

        string description = "Description not available.";
        if (File.Exists(filePath))
        {
            description = File.ReadAllText(filePath);
        }

        // Pass description to SceneDataManager
        SceneDataManager.Instance.targetName = targetName;
        SceneDataManager.Instance.description = description;

        // Retrieve the sprite from the dictionary
        if (targetSprites.ContainsKey(targetName))
        {
            Debug.Log("Sprite retrieved from dictionary");
            SceneDataManager.Instance.targetImage = targetSprites[targetName];
        }
        else
        {
            Debug.LogWarning($"No sprite found for target: {targetName}");
        }

        // Transition to the DescriptionScene
        SceneManager.LoadScene("DescriptionScene");
    }

    private void LoadSprites()
    {
        // Load all sprites from the Resources/TargetSprites folder
        Sprite[] sprites = Resources.LoadAll<Sprite>("TargetSprites");

        if (sprites.Length == 0)
        {
            Debug.LogError("No sprites found in the TargetSprites folder. Check your folder structure and import settings.");
            return;
        }

        foreach (Sprite sprite in sprites)
        {
            Debug.Log($"Loaded sprite: {sprite.name}");
            targetSprites[sprite.name] = sprite;
        }

        Debug.Log($"Sprites loaded successfully: {targetSprites.Count}");
    }

}
