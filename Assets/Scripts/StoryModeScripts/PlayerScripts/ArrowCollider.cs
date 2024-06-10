using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollider : MonoBehaviour
{
    [SerializeField]
    public static int arrowDamage = 20;
    float destroyArrow = 3f;
    switching switching;
    AudioController audioController;

    void Start()
    {
        switching = FindObjectOfType<switching>();
        audioController = FindObjectOfType<AudioController>();
    }
    void Update()
    {
        destroyArrow -= Time.deltaTime;
        if (destroyArrow <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (switching.playerWithBow.activeSelf)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
            {
                audioController.PlayArrowHitSound();
                collision.GetComponent<Enemy>().TakeDamage(arrowDamage);
                collision.GetComponent<AImovement>().canChase = true;
                Destroy(gameObject);
            }
            else if (collision.CompareTag("tree"))
            {
                Destroy(gameObject);
            }
        }
    }
}
