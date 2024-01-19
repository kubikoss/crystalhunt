using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemies;

    public float attackRange;
    public int damage;
    public int addPlayerHealth = 20;

    [SerializeField] 
    private Animator anim;

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("attack");
                timeBtwAttack = startTimeBtwAttack;

                //detekovani enemies v player range
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    //udeleni damage jednotlivemu enemy, ktery player poskodi
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    Debug.Log(enemiesToDamage[i].GetComponent<Enemy>().health);
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
