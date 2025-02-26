using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private StoneSpawner spawner;
    [SerializeField] private Cart cart;
    [Space(50)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool checkPassed;
    private void Awake()
    {
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
                }
            }
            timer = 0f;
        }
    }
    private void OnSpawnCompleted()
    {
        checkPassed = true;
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
