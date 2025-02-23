using UnityEngine;
using UnityEngine.Events;

public class Cart : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _vehicleWidth;
    private Vector3 _movementTarget;

    [Header("Wheeels")]
    [SerializeField] private Transform[] _wheels;    
    private float _wheelRadius;

    [HideInInspector] public UnityEvent OnCollisionStone;
    private float _deltaMovement;
    private float _lastPosition;

    private void Start()
    {
        _movementTarget = transform.position;
        _wheelRadius = _wheels[0].GetComponent<SpriteRenderer>().localBounds.size.x / 2;
    }

    private void Update()
    {
        Move();
        RotateWheel();
    }

    private void Move()
    {
        _lastPosition = transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, _movementTarget, _movementSpeed * Time.deltaTime);
        _deltaMovement = transform.position.x - _lastPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stone stone = collision.transform.root.GetComponent<Stone>();
        Debug.Log("Cart - Collide with stone");
        if (stone != null)
        {
            OnCollisionStone.Invoke();
            //Debug.Log("Cart - Collide with stone");
        }
    }
    public void SetMovementTarget(Vector3 target)
    {
        _movementTarget = ClampMovementTarget(target);
    }
    private Vector3 ClampMovementTarget(Vector3 target)
    {
        float leftBorder = LevelBoundary.Instance.LeftBorder + _vehicleWidth * 0.5f;
        float rightBorder = LevelBoundary.Instance.RightBorder - _vehicleWidth * 0.5f;
        Vector3 movTarget = target;
        movTarget.z = transform.position.z;
        movTarget.y = transform.position.y;
        if (movTarget.x < leftBorder)
        {
            movTarget.x = leftBorder;
        }
        if (movTarget.x > rightBorder) 
        {
            movTarget.x = rightBorder; 
        }
        return movTarget;
    }

    private void RotateWheel()
    {
        
        float angle = (180 * _deltaMovement) / (Mathf.PI * _wheelRadius);

        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].Rotate(new Vector3(0,0, -angle));
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position - new Vector3(_vehicleWidth * 0.5f, 0.5f, 0), transform.position + new Vector3(_vehicleWidth* 0.5f, -0.5f, 0));
    }
#endif
}
