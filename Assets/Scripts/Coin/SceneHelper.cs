using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHelper : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int lvlIndex)
    {
        SceneManager.LoadScene(lvlIndex);
        Time.timeScale = 1.0f;
    }

    public void QuidApp()
    {
        Application.Quit();
    }
}

