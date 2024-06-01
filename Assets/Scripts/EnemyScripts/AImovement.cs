using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAttack))]

public class AImovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float detectionRange = 5f;
    [SerializeField]
    float patrolDistance = 2f;

    Transform player;
    Transform player2;
    switching switching;
    float distanceToPlayer;

    private Vector2 initialPosition;
    private Vector2 targetPosition;

    public bool canChase = false;
    private bool isPatrollingRight = true;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
        player = GameManager.GameManagerInstance.PlayerTransform;
        player2 = GameManager.GameManagerInstance.Player2Transform;
        switching = FindObjectOfType<switching>();
        //enemy = GetComponent<Enemy>();
        //initialHealth = GetComponent<Enemy>().health;
    }

    void Update()
    {
        //Debug.Log(enemy.health);
        if (switching.playerWithSword.activeSelf)
        {
            distanceToPlayer = Vector2.Distance(transform.position, player.position);
        }
        else if (switching.playerWithBow.activeSelf)
        {
            distanceToPlayer = Vector2.Distance(transform.position, player2.position);
        }
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
        moveSpeed = 3f;
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

    public void MoveTowardsTarget()
    {
        moveSpeed = 4f;
        //enemy se bude "nalepovat" na hrace
        canChase = true;
        if (switching.playerWithSword.activeSelf)
        {
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
        else if (switching.playerWithBow.activeSelf)
        {
            transform.position = Vector2.MoveTowards(transform.position, player2.position, moveSpeed * Time.deltaTime);

            if (player2.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        //transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        /*if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/
    }
}
