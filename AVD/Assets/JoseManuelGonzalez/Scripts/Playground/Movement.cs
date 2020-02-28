using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Player player;
    public float runSpeed=0f, horizontalMove=0f;
    public bool jump=false, crouch=false;
    private bool flip = false;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
 
    void Update()
    {

    }
    void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        jump = Input.GetButtonDown("Jump");

        crouch = Input.GetButton("Crouch");
        //if (Input.GetButtonDown("Crouch")) crouch = true;
        //if (Input.GetButtonUp("Crouch")) crouch = false;

        /*if (horizontalMove < -0.1 && !flip) { 
            flip = true;
        }
        if (horizontalMove > 0.1 && flip ) {
            flip = false;
        }*/

        animator.SetBool("Crouching", crouch);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("Grounded", player.m_Grounded);

        player.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

}
