using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    private int coinsQuantity;
    public UnityEvent onPickupCoin;
    public int CoinsQ => coinsQuantity;

    private void Awake()
    {
        //onPickupCoin.AddListener(AddCoin);
    }
    public void AddCoin(int amount)
    {
        coinsQuantity += amount;
        //Debug.Log($"coinsQuantity {coinsQuantity}");
        onPickupCoin?.Invoke();
    }

    public int GetAmount()
    {
        //Debug.Log($"coinsQuantity {coinsQuantity}");
        return coinsQuantity;
    }
}
