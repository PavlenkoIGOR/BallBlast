using System;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float reboundSpeed;
    [SerializeField] private float gravityOffset = 10;
    [SerializeField] private float rotationSpeed = 11;
    private Vector3 stoneVelocity;
    private bool useGravity;
    private void Awake()
    {
        stoneVelocity.x = -Mathf.Sign(transform.position.x) * horizontalSpeed;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TryEnableGravity();
        Move();
    }

    private void TryEnableGravity()
    {
        if (Mathf.Abs(transform.position.x) >= Mathf.Abs(LevelBoundary.Instance.LeftBorder) - gravityOffset) 
        {
            useGravity = true;
        }
    }


    private void Move()
    {
        if (useGravity)
        {
            stoneVelocity.y -= gravity * Time.deltaTime;
            transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
        }
        stoneVelocity.x = Mathf.Sign(stoneVelocity.x) * horizontalSpeed;

        transform.position += stoneVelocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.gameObject.GetComponent<LevelEdge>();

        if (levelEdge != null)
        {
            if (levelEdge.EdgeType == EdgeType.Bottom)
            {
                stoneVelocity.y = reboundSpeed;
            }

            if (levelEdge.EdgeType == EdgeType.Left && stoneVelocity.x < 0 || levelEdge.EdgeType == EdgeType.Right && stoneVelocity.x > 0)
            {
                stoneVelocity.x *= -1;
            }
        }
    }

    public void AddVerticalVelocity(float velocity)
    {
        this.stoneVelocity.y += velocity;
    }

    public void SetHorizontalDirection(float direction)
    {
        stoneVelocity.x = Mathf.Sign(direction) * horizontalSpeed;
    }
}
