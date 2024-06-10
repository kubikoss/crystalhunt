using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAttack))]

public class AImovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 7f;
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

    Rigidbody2D rb;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
        player = GameManager.GameManagerInstance.PlayerTransform;
        player2 = GameManager.GameManagerInstance.Player2Transform;
        switching = FindObjectOfType<switching>();

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; 
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Story Mode")
        {
            detectionRange = 6f;
            if (switching.playerWithSword.activeSelf)
            {
                distanceToPlayer = Vector2.Distance(rb.position, player.position);
            }
            else if (switching.playerWithBow.activeSelf)
            {
                distanceToPlayer = Vector2.Distance(rb.position, player2.position);
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
        else if (currentScene.name == "Infinite World")
        {
            detectionRange = 500f;

            if (switching.playerWithSword.activeSelf)
            {
                distanceToPlayer = Vector2.Distance(rb.position, player.position);
            }
            else if (switching.playerWithBow.activeSelf)
            {
                distanceToPlayer = Vector2.Distance(rb.position, player2.position);
            }
            if (distanceToPlayer <= detectionRange || canChase)
            {
                MoveTowardsTarget();
            }
        }
        
    }

    void Patrol()
    {
        moveSpeed = 8f;
        Vector2 leftPatrolPosition = initialPosition - Vector2.right * patrolDistance;
        Vector2 rightPatrolPosition = initialPosition + Vector2.right * patrolDistance;

        if (isPatrollingRight)
        {
            targetPosition = rightPatrolPosition;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            targetPosition = leftPatrolPosition;
            transform.localScale = new Vector3(1, 1, 1);
        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime));

        if (Vector2.Distance(rb.position, targetPosition) <= 0.1f)
        {
            isPatrollingRight = !isPatrollingRight;
        }
    }

    public void MoveTowardsTarget()
    {
        moveSpeed = 10f;
        canChase = true;

        Vector2 target = switching.playerWithSword.activeSelf ? player.position : player2.position;

        rb.MovePosition(Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime));

        if (target.x > rb.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
