using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnTime;
    

    [Header("Balance")]
    [SerializeField] private int amount;
    [SerializeField] private Turret turret;

    [SerializeField][Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private float maxHitpointsRate;

    [Space(20)]
    public UnityEvent OnComplited;

    private int stoneMaxHitpoints;
    private int stoneMinHitpoints;
    private float timer;
    private int amountSpawned;

    void Start()
    {
        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));

        stoneMaxHitpoints = (int)(damagePerSecond * maxHitpointsRate);
        stoneMinHitpoints = (int)(stoneMaxHitpoints * minHitpointsPercentage);
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            Spawn();

            timer = 0;
        }

        if (amountSpawned == amount)
        {
            enabled = false;

            OnComplited.Invoke();
        }
    }

    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0,spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size)Random.Range(1,4));
        stone.maxHitPoints = Random.Range(stoneMinHitpoints, stoneMaxHitpoints + 1);
        amountSpawned++;
    }
}
