using UnityEngine;
using UnityEngine.UI;

public class BuyBttn : MonoBehaviour
{
    [SerializeField] private Bag bag;
    [SerializeField] private Turret turret;
    [SerializeField] private Button bttn;

    [SerializeField] private SummaryBulletsTMP summaryBulletsTMP;

    private void Awake()
    {
        bttn.onClick.AddListener(ClickBuyBttn);
    }


    private void ClickBuyBttn()
    {
        if (bag.CoinsQ > 0)
        {
            turret.ChangeProjectilesAmount(1);

            bag.AddCoin(-1);

            summaryBulletsTMP.ChangeSummaryTMP();
        }
    }
}
