using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    private int _dmg;

    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }


    void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructable destructable = collision.transform.root.GetComponent<Destructable>();

        if (destructable != null)
        {
            destructable.ApplyDamage(_dmg);
        }

        Destroy(gameObject);
    }

    public void SetDamage(int dmg)
    {
        _dmg = dmg;
    }
}
