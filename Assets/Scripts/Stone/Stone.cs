using UnityEngine;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructable
{
    [SerializeField] private GameObject onStoneCrush;
    public enum Size
    {
        Small,
        Normal,
        Big,
        Huge
    }
    [SerializeField] private Size size;
    [SerializeField] private float spawnUpForce;
    [SerializeField] public Transform stoneSprite;

    private StoneMovement movement;

    private Color stoneColor;

    [SerializeField] private Coin newCoin;
    private void Awake()
    {
        movement = GetComponent<StoneMovement>();
        onDie.AddListener(OnStoneDestroyed);
        SetSize(size);
    }

    private void OnDestroy()
    {
        onDie.RemoveListener(OnStoneDestroyed);

    }
    private void OnStoneDestroyed()
    {
        if (size != Size.Small)
        {
            SpawnStones();
        }

        var stoneCrush = Instantiate(onStoneCrush, transform.position, Quaternion.identity);
        var sc = onStoneCrush.GetComponent<OnStoneCrush>();
        //Destroy(stoneCrush, 1.5f);

        Destroy(gameObject);

        int coinSpawnRnd = Random.Range(1, 4);
        if (coinSpawnRnd == 2)
        {
            newCoin.CoinSpawner(this.transform.position); // spawn a coin
        }
    }
    private void SpawnStones()
    {
        stoneColor = new Color(Random.value, Random.value, Random.value);
        for (int i = 0; i < 2; i++)
        {
            Stone stone = Instantiate(this, transform.position, Quaternion.identity);
            stone.SetSize(size - 1);
            stone.maxHitPoints = Mathf.Clamp(maxHitPoints / 2, 1, maxHitPoints);
            stone.movement.AddVerticalVelocity(spawnUpForce);
            stone.movement.SetHorizontalDirection((i % 2 * 2) - 1);

            SpriteRenderer sr = stone.stoneSprite.GetComponent<SpriteRenderer>();
            sr.color = stoneColor;
        }
    }

    public void SetSize(Size size)
    {
        if (size < 0)
        {
            return;
        }

        transform.localScale = GetVectorFromSize(size);
        this.size = size;
    }

    private Vector3 GetVectorFromSize(Size size)
    {
        if (size == Size.Huge)
        {
            return new Vector3(1, 1, 1);
        }
        if (size == Size.Big)
        {
            return new Vector3(0.75f, 0.75f, 0.75f);
        }
        if (size == Size.Normal)
        {
            return new Vector3(0.6f, 0.6f, 0.6f);
        }
        if (size == Size.Small)
        {
            return new Vector3(0.4f, 0.4f, 0.4f);
        }

        return Vector3.one;
    }
}
