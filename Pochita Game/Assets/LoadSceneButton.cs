using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadSecondScene()
    {
        SceneManager.LoadScene("Demo Level");
    }
}
