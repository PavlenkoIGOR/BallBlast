using UnityEngine;
using UnityEngine.SceneManagement;

public enum Levels
{
    Menu,
    MainLevel
}

public class LevelsController : MonoBehaviour
{
    [SerializeField] private Levels levels;

    public void ChangeScene()
    {
        Levels activeScene = (Levels)SceneManager.GetActiveScene().buildIndex;
        switch (activeScene)
        {
            case Levels.MainLevel:
                SceneManager.LoadSceneAsync((int)Levels.Menu);
                break;
            case Levels.Menu:
                SceneManager.LoadSceneAsync((int)Levels.MainLevel);
                Time.timeScale = 1.0f;
                break;
        }
        
    }
}
