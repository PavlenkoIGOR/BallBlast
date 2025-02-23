using UnityEngine;

public class CartControl : MonoBehaviour
{
    [SerializeField] private Cart _cart;
    [SerializeField] private Turret turret;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _cart.SetMovementTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0))
        {
            turret.Fire();
        }
    }
}
