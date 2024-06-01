    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        public float moveSpeed = 6f;

        public float KBForce;
        public float KBCounter;
        public float KBTotalTime;

        public bool knockFromRight;

        [SerializeField]
        public Rigidbody2D rb;
        [SerializeField]
        private Animator anim;

        GameObject levelUpMenuUI;
        CanvasGroup canvasGroup;
        public AudioController audioController;

        Vector2 movement;

        void Start()
        {
            levelUpMenuUI = GameObject.FindGameObjectWithTag("LevelUI");
            canvasGroup = levelUpMenuUI.GetComponent<CanvasGroup>();
        }

        void Update()
        {
            if (PauseMenu.gameIsPaused == false || Time.timeScale != 0f)
            {
                if (canvasGroup.alpha == 0f)
                {
                    Time.timeScale = 1f;
                }
                else if (canvasGroup.alpha == 1f)
                {
                    Time.timeScale = 0f;
                }

                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");

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
                        //audioController.PlayPlayerWalkingSound();
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