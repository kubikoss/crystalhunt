using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBiomeCollider : MonoBehaviour
{
    [SerializeField]
    PlayerMovement pm1;
    [SerializeField]
    PlayerMovement pm2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pm1.moveSpeed = 6f;
            pm2.moveSpeed = 6f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pm1.moveSpeed = 10;
        pm2.moveSpeed = 10f;
    }
}
