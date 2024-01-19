using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool knockFromRight;

    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    private Animator anim;

    Vector2 movement;
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!PauseMenu.gameIsPaused)
        {
            if (KBCounter <= 0)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                if (movement.magnitude != 0)
                {
                    anim.SetTrigger("walking");
                }
                else
                {
                    anim.SetTrigger("idle");
                }
            }
            else
            {
                if (knockFromRight == true)
                {
                    movement.x = -KBForce;
                }
                if (knockFromRight == false)
                {
                    movement.x = KBForce;
                }
                KBCounter -= Time.deltaTime;
            }
        }  
    }

    private void FixedUpdate()
    {
        movement.Normalize();
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}