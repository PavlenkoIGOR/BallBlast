using UnityEngine;
using UnityEngine.UI;

public class BuyBttn : MonoBehaviour
{
    [SerializeField] private Bag bag;
    [SerializeField] private Turret turret;
    [SerializeField] private Button bttn;
    [SerializeField] private int cost;
    [SerializeField] private SummaryBulletsTMP summaryBulletsTMP;

    private void Awake()
    {
        bttn.onClick.AddListener(ClickBuyBttn);
    }


    private void ClickBuyBttn()
    {
        if (bag.CoinsQ > 0 && bag.CoinsQ >= cost)
        {
            turret.ChangeProjectilesAmount(1);

            bag.AddCoin(-cost);

            summaryBulletsTMP.ChangeSummaryTMP();
        }
    }
}
