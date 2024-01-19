using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAttack))]

public class AImovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float detectionRange = 5.0f;
    public float patrolDistance = 2.0f;

    Transform player;
    private Vector2 initialPosition;
    private Vector2 targetPosition;

    private bool canChase = false;
    private bool isPatrollingRight = true;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
        player = GameManager.GameManagerInstance.PlayerTransform;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange || canChase)
        {
            MoveTowardsTarget();
        }
        else
        {
            Patrol();
        }
    }
    

    void Patrol()
    {
        //enemy se hybe zprava doleva, dokud hrac neni v range
        Vector2 leftPatrolPosition = initialPosition - Vector2.right * patrolDistance;
        Vector2 rightPatrolPosition = initialPosition + Vector2.right * patrolDistance;

        if (isPatrollingRight)
        {
            targetPosition = rightPatrolPosition;
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            targetPosition = leftPatrolPosition;
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) <= 0.1f)
        {
            isPatrollingRight = !isPatrollingRight;
        }
    }

    void MoveTowardsTarget()
    {
        //enemy se bude "nalepovat" na hrace
        canChase = true;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
