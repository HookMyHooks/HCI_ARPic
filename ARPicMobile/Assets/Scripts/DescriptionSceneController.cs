using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DescriptionSceneController : MonoBehaviour
{
    public TextMeshProUGUI descriptionText; // Assign in Inspector
    public Image targetImage; // Assign in Inspector (optional)

    private void Start()
    {
        // Get the data from SceneDataManager
        if (SceneDataManager.Instance != null)
        {
            descriptionText.text = SceneDataManager.Instance.description;

            // Set the target image
            if (SceneDataManager.Instance.targetImage != null)
            {
                targetImage.sprite = SceneDataManager.Instance.targetImage;
                Debug.Log("Got An Image!");
            }
        }
        else
        {
            Debug.LogWarning("SceneDataManager instance is missing!");
        }
    }
}
