using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private StoneSpawner spawner;
    public StoneSpawner Spawner { get { return spawner; } set { spawner = value; } }
    [SerializeField] private Cart cart;
    [Space(50)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    public bool checkPassed;
    public bool isRestart = false;
    public Cart Cart => cart;
    private void Awake()
    {
        //PlayerPrefs.DeleteKey("SpawnerAmount");
        //spawner.amount = PlayerPrefs.GetInt("SpawnerAmount", spawner.amount); // 0 - значение по умолчанию, если ключ не найден

        //Debug.Log("bug");
        spawner.OnComplited.AddListener(OnSpawnCompleted);
        cart.OnCollisionStone.AddListener(OnCartCollisionStone);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            if (checkPassed == true)
            {
                if (FindObjectsByType<Stone>(FindObjectsSortMode.None).Length == 0)
                {
                    Passed.Invoke();
                    //Debug.Log("bug");
                }
            }
            timer = 0f;
        }
    }
    private void OnSpawnCompleted()
    {
        checkPassed = true;
        //Debug.Log("bug");
    }

    private void OnDestroy()
    {
        spawner.OnComplited.RemoveListener(OnSpawnCompleted);

        cart.OnCollisionStone.RemoveListener(OnCartCollisionStone);
    }

    private void OnCartCollisionStone()
    {
        Defeat.Invoke();

        foreach (Transform wheel in cart.wheelsPublic)
        {
            Animation animation = wheel.GetComponent<Animation>();
            animation.Play();
        }
        Animation animationBody = cart.cartBody.GetComponent<Animation>();
        animationBody.Play();

        PolygonCollider2D cartRB = cart.cartBody.GetComponent<PolygonCollider2D>();
        cartRB.enabled = false;
    }
}
