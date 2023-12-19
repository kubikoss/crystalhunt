using UnityEngine;

public class AImovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3.0f;
    public float detectionRange = 5.0f;
    public float patrolDistance = 2.0f;

    private Vector2 initialPosition;
    private Vector2 targetPosition;
    private bool canChase = false;
    private bool isPatrollingRight = true;


    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            canChase = true;
        }
        else if (canChase)
        { 
            Debug.Log(detectionRange);
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
        }
        else
        {
            targetPosition = leftPatrolPosition;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);


        if (Vector2.Distance(transform.position, targetPosition) <= 0.1f)
        {
            isPatrollingRight = !isPatrollingRight;
        }
    }


    void MoveTowardsTarget()
    {
        Debug.Log("k hracovi");
        //enemy se bude "nalepovat" na hrace
        targetPosition = player.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
