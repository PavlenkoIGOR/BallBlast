using TMPro;
using UnityEngine;

[RequireComponent(typeof(Destructable))]
public class StoneHitpointsText : MonoBehaviour
{
    [SerializeField] private TMP_Text hitpointText;
    private Destructable destructable;

    private void Awake()
    {
        destructable = GetComponent<Destructable>();

        destructable.onChangeHitPoints.AddListener(OnChangeHitPoint);
    }

    private void OnDestroy()
    {
        destructable.onChangeHitPoints.RemoveListener(OnChangeHitPoint);
    }

    private void OnChangeHitPoint()
    {
        int hitPoints = destructable.GetHitPoints();

        if (hitPoints >= 1000)
        {
            hitpointText.text = hitPoints / 1000 + "K";
        }
        else 
        {
            hitpointText.text = hitPoints.ToString();
        }
    }
}
