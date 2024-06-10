 using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    [SerializeField]
    public int damage = 10;
    bool canAttack = false;

    Player _player;
    Player _player2;
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private Animator anim;
    switching switching;
    AudioController audioController;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        switching = FindObjectOfType<switching>();

        _player = switching.playerWithSword.GetComponent<Player>();
        _player2 = switching.playerWithBow.GetComponent<Player>();

        audioController = FindObjectOfType<AudioController>();
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
        if (canAttack)
        {
            if (HasTrigger(anim, "attack"))
            {
                anim.SetTrigger("attack");
            }
            if (collision.gameObject.TryGetComponent(out Player collidedPlayer) && canAttack == true)
            {
                audioController.PlayEnemyAttackSound();
                if (collidedPlayer == _player)
                { 
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
                }
                if(collidedPlayer == _player2)
                {
                    _player2.GetComponent<PlayerMovement>().KBCounter = _player2.GetComponent<PlayerMovement>().KBTotalTime;
                    if (_player2.transform.position.x <= transform.position.x)
                    {
                        _player2.GetComponent<PlayerMovement>().knockFromRight = true;
                    }
                    if (_player2.transform.position.x >= transform.position.x)
                    {
                        _player2.GetComponent<PlayerMovement>().knockFromRight = false;
                    }
                    _player2.TakeDamage(damage);
                    _player2.isPlayerDead();
                }
                
            }
        }
    }
    public bool HasTrigger(Animator animator, string triggerName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger && param.name == triggerName)
            {
                return true;
            }
        }
        return false;
    }
}
