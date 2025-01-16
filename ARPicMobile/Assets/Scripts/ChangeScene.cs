using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChangeMainAPP()
    {
        Debug.Log("Transition to MainApp");
        SceneManager.LoadScene("MainAPP");
    }

    public void SceneChangeDescriptionScene()
    {
        SceneManager.LoadScene("DescriptionScene");
    }
}
