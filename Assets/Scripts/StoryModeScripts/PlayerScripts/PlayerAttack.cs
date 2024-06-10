using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttackSword;
    public float startTimeBtwAttackSword;

    private float timeBtwAttackBow;
    public float startTimeBtwAttackBow;

    public Transform attackPos;
    public LayerMask enemies;

    [SerializeField]
    GameObject arrowPrefab;
    [SerializeField]
    float arrowSpeed = 7f;

    public float attackRange;
    public int damage;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    switching switching;
    public AudioController audioController;

    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            if (switching.playerWithSword.activeSelf)
            {
                AttackSword();
            }
            else if(switching.playerWithBow.activeSelf)
            {
                AttackBow();
            }
        }
    }

    void AttackSword()
    {
        if (timeBtwAttackSword <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("attack");
                audioController.PlayAttackSound();
                timeBtwAttackSword = startTimeBtwAttackSword;

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
        else
        {
            timeBtwAttackSword -= Time.deltaTime;
        }
    }
    void AttackBow()
    {
        if (timeBtwAttackBow <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("attack");
                audioController.PlayBowAttackSound();
                timeBtwAttackBow = startTimeBtwAttackBow;
                CreateArrow();
            }
        }
        else
        {
            timeBtwAttackBow -= Time.deltaTime;
        }
    }
    void CreateArrow()
    {
        GameObject newArrow = Instantiate(arrowPrefab, attackPos.position, Quaternion.identity);
        Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();

        Vector2 direction = Vector2.right;
        if (transform.localScale.x < 0)
        {
            direction = Vector2.left;
            newArrow.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        rb.velocity = direction * arrowSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
