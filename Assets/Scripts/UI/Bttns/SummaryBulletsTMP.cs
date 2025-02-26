using TMPro;
using UnityEngine;

public class SummaryBulletsTMP : MonoBehaviour
{
    [SerializeField] private Turret turret;
    [SerializeField] private TMP_Text textSummaryProjectiles;

    private void Awake()
    {
        ChangeSummaryTMP();
    }

    public void ChangeSummaryTMP()
    {
        textSummaryProjectiles.text = "Итого: " + turret.ProjectileAmount.ToString();
    }
}
