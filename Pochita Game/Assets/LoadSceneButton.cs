using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadSecondScene()
    {
        SceneManager.LoadScene(1); // Load the scene at index 1
    }
}
