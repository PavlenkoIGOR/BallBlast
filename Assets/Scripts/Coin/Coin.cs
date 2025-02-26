using TMPro;
using UnityEngine;

public class Coin : Pickup
{
    public void CoinSpawner(Vector3 newCoinPosition)
    {
        Coin coin = Instantiate(this, newCoinPosition, Quaternion.identity);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.GetComponent<Cart>() != null)
        {
            //Debug.Log($"name {collision.transform.root.name}");
            Bag bag = collision.transform.root.GetComponent<Bag>();

            if (bag != null) { Debug.Log($"bag not null"); }

            bag.AddCoin(1);

            Destroy(this.gameObject);
        }
    }
}
