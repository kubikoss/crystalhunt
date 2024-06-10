using UnityEngine;

public class switching : MonoBehaviour
{
    [SerializeField]
    public GameObject playerWithSword;
    [SerializeField]
    public GameObject playerWithBow;

    int currentHealth, maxHealth, defence, level, xp, damage;

    void Start()
    {
        currentHealth = playerWithSword.GetComponent<Player>().currHealth;
        maxHealth = playerWithSword.GetComponent<Player>().maxHealth;
        defence = playerWithSword.GetComponent<Player>().defence;
        level = playerWithSword.GetComponent<Player>().level;
        xp = playerWithSword.GetComponent<Player>().xp;
        damage = playerWithSword.GetComponent<PlayerAttack>().damage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !playerWithSword.activeSelf && Time.timeScale != 0f)
        {
            EnableSword();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !playerWithBow.activeSelf && Time.timeScale != 0f)
        {
            EnableBow();
        }
    }

    public void EnableSword()
    {
        playerWithSword.SetActive(true);
        playerWithBow.SetActive(false);
        playerWithSword.transform.position = new Vector3(playerWithBow.transform.position.x, playerWithBow.transform.position.y, 0);

        Vector3 bowScale = playerWithBow.transform.localScale;
        playerWithSword.transform.localScale = new Vector3(bowScale.x, bowScale.y, bowScale.z);

        ChangeSwordStats();
    }

    public void EnableBow()
    {
        playerWithSword.SetActive(false);
        playerWithBow.SetActive(true);
        playerWithBow.transform.position = new Vector3(playerWithSword.transform.position.x, playerWithSword.transform.position.y, 0);

        Vector3 swordScale = playerWithSword.transform.localScale;
        playerWithBow.transform.localScale = new Vector3(swordScale.x, swordScale.y, swordScale.z);

        ChangeBowStats();
    }

    void ChangeSwordStats()
    {
        currentHealth = playerWithBow.GetComponent<Player>().currHealth;
        playerWithSword.GetComponent<Player>().currHealth = currentHealth;

        maxHealth = playerWithBow.GetComponent<Player>().maxHealth;
        playerWithSword.GetComponent<Player>().maxHealth = maxHealth;

        level = playerWithBow.GetComponent<Player>().level;
        playerWithSword.GetComponent<Player>().level = level;

        damage = playerWithBow.GetComponent<PlayerAttack>().damage;
        playerWithSword.GetComponent<PlayerAttack>().damage = damage;

        defence = playerWithBow.GetComponent<Player>().defence;
        playerWithSword.GetComponent<Player>().defence = defence;

        xp = playerWithBow.GetComponent<Player>().xp;
        playerWithSword.GetComponent<Player>().xp = xp;
    }

    void ChangeBowStats()
    {
        currentHealth = playerWithSword.GetComponent<Player>().currHealth;
        playerWithBow.GetComponent<Player>().currHealth = currentHealth;

        maxHealth = playerWithSword.GetComponent<Player>().maxHealth;
        playerWithBow.GetComponent<Player>().maxHealth = maxHealth;

        level = playerWithSword.GetComponent<Player>().level;
        playerWithBow.GetComponent<Player>().level = level;

        damage = playerWithSword.GetComponent<PlayerAttack>().damage;
        playerWithBow.GetComponent<PlayerAttack>().damage = damage;

        defence = playerWithSword.GetComponent<Player>().defence;
        playerWithBow.GetComponent<Player>().defence = defence;

        xp = playerWithSword.GetComponent<Player>().xp;
        playerWithBow.GetComponent<Player>().xp = xp;
    }
}
