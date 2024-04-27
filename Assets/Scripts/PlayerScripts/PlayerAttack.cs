using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttackSword;
    public float startTimeBtwAttackSword;

    /*private float timeBtwAttackBow;
    public float startTimeBtwAttackBow;*/

    public Transform attackPos;
    public LayerMask enemies;

    /*[SerializeField]
    GameObject arrowPrefab;
    [SerializeField]
    float arrowSpeed = 7f;
    int arrowDamage = 20;*/

    public float attackRange;
    public int damage;

    [SerializeField]
    private Animator anim;

    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            if (timeBtwAttackSword <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    anim.SetTrigger("attack");
                    timeBtwAttackSword = startTimeBtwAttackSword;

                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                        //Debug.Log(enemiesToDamage[i].GetComponent<Enemy>().health);
                    }
                }
            }
            else
            {
                timeBtwAttackSword -= Time.deltaTime;
            }
            /*if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                AttackSword();
            }*/
            /*else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                AttackBow();
            }*/
        }
    }

    /*void AttackSword()
    {
        
    }*/

    /*void AttackBow()
    {
        if (timeBtwAttackBow <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("attack");
                timeBtwAttackBow = startTimeBtwAttackBow;

                GameObject newArrow = Instantiate(arrowPrefab, attackPos.position, Quaternion.identity);
                Vector2 direction = Vector2.right;
                if (!Mathf.Approximately(transform.localScale.x, 1f))
                {
                    direction = Vector2.left;
                }
                newArrow.GetComponent<Rigidbody2D>().velocity = direction * arrowSpeed;
            }
        }
        else
        {
            timeBtwAttackBow -= Time.deltaTime;
        }
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(arrowDamage);

            Destroy(collision.gameObject);
        }
    }*/
}
