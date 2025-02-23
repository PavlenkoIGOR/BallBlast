using UnityEngine;
using UnityEngine.Events;

public class Destructable : MonoBehaviour
{
    [SerializeField] public int maxHitPoints;

    [HideInInspector] public UnityEvent onDie;
    [HideInInspector] public UnityEvent onChangeHitPoints;
    private int hitPoints;
    private bool isDied = false;

    private void Start()
    {
        hitPoints = maxHitPoints;
        onChangeHitPoints.Invoke();
    }

    public void ApplyDamage(int dmg)
    {
        hitPoints -= dmg;
        onChangeHitPoints.Invoke();

        if (hitPoints <= 0)
        {
            Kill();
        }
    }

    public void ApplyHealing(int heal)
    {
        hitPoints += heal;
        onChangeHitPoints?.Invoke();

        if (hitPoints >= maxHitPoints)
        {
            hitPoints = maxHitPoints;
        }
    }

    public void Kill()
    {
        if (isDied == true)
        {
            return;
        }
        hitPoints = 0;
        isDied = true;
        onChangeHitPoints?.Invoke();
        onDie?.Invoke();
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
}
