using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Player player;
    public float runSpeed=0f, horizontalMove=0f;
    public bool jump=false, crouch=false;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
 
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        jump = Input.GetButtonDown("Jump");

        if (Input.GetButtonDown("Crouch")) crouch = true;
        if (Input.GetButtonUp("Crouch")) crouch = false;

        Debug.Log("jump = " + jump + "// crouch = " + crouch);

        spriteRenderer.flipX = horizontalMove < 0;

        animator.SetBool("Crouching", crouch);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("Grounded", player.m_Grounded);

    }
    void FixedUpdate()
    {
        player.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

}
