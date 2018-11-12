using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public float speed = 6.0F;
    private float jumpSpeed = 8.0F;
    private float gravity = 20.0F;
    private float cooldown, timer;
    public bool dealDamage = false;
    

    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        cooldown = GameObject.Find("Player").GetComponent<PlayerStats>().cooldown;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        if (controller.enabled == true)
        {
            controller.Move(moveDirection * Time.deltaTime);

        }
        if (Input.GetButtonDown("Fire1") && timer <= 0) {
        
            Hit();
            timer = cooldown;
            dealDamage = true;
        }

    }
    void Hit() {
        animator.SetTrigger("Attack");
        animator.SetBool("Reset", true);
    }
}

