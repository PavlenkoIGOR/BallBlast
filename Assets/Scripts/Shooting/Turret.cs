using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;
    [SerializeField][Range(1,20)] private sbyte projectileAmount;
    [SerializeField] private float projectileInterval;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    public int Damage => damage;
    public sbyte ProjectileAmount { get { return projectileAmount; } }
    public float FireRate => fireRate;

    float timer;

    private void Awake()
    {
        timer = fireRate;
    }
    void Update()
    {
        timer += Time.deltaTime;

    }

    public void Fire()
    {
        if (timer > fireRate)
        {
            audioSource.Play();

            SpawnProjectile();
            timer = 0;
        }
    }

    private void SpawnProjectile()
    {
        float startposX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;
        for (int i = 0; i < projectileAmount; i++)
        {
            Projectile projectile = Instantiate(
                projectilePrefab,
                new Vector3(startposX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z),
                transform.rotation
                );

            projectile.SetDamage(damage);
        }
    }

    public void ChangeProjectilesAmount(sbyte amount)
    {
        projectileAmount += amount;
    }
}
