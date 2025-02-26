using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController instance;
    public PauseController pauseController;

    //private void Awake()
    //{

    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseController.TogglePause();
        }
    }
}
