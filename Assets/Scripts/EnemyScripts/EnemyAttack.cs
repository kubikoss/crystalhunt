 using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    [SerializeField]
    public int damage = 10;
    bool canAttack = false;

    Player _player;
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private Animator anim;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (timeBtwAttack <= 0)
        {
            timeBtwAttack = startTimeBtwAttack;
            canAttack = true;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out _player) && canAttack == true)
        {
            //anim.SetTrigger("attack");

            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if (_player.transform.position.x <= transform.position.x)
            {
                playerMovement.knockFromRight = true;
            }
            if (_player.transform.position.x >= transform.position.x)
            {
                playerMovement.knockFromRight = false;
            }

            _player.TakeDamage(damage);
            _player.isPlayerDead();

            canAttack = false;
        }
    }
}
