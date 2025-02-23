using UnityEngine;

/// <summary>
/// класс отвечающий за границы уровня
/// </summary>
public class LevelBoundary : MonoBehaviour
{
    public static LevelBoundary Instance;

    [SerializeField] private Vector2 _screenResolution;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        if (Application.isEditor == false && Application.isPlaying == true)
        {
            _screenResolution.x = Screen.width;
            _screenResolution.y = Screen.height;    
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// левая граница
    /// </summary>
    public float LeftBorder
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        }
    }

    public float RightBorder
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(_screenResolution.x, 0, 0)).x;
            //return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x; //Screen.width - ширина экрана в эдиторе
        }
    }
}
