


using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Bag bag;
    [SerializeField] private TMP_Text coinQText;

    private void Awake()
    {
        coinQText.text = "������: " + bag.CoinsQ.ToString();
        bag.onPickupCoin.AddListener(UpdateCoinText);
    }
    private void UpdateCoinText()
    {
        coinQText.text = "������: " + bag.CoinsQ.ToString();
    }
}
