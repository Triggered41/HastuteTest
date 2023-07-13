using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speed;
    public bool isAttacking;
    private Vector3 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animate();
        Attack();
    }

    void Movement(){
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction *= speed*Time.deltaTime;

        controller.Move((transform.forward*direction.z)+(transform.right*direction.x));
    }

    void Animate(){

        // Straf
        if (direction.z == 0 && direction.x != 0){
            animator.SetBool("IsStraffing", true);
        }else{
            animator.SetBool("IsStraffing", false);
        }
        if (animator.GetBool("IsStraffing")) return;

        // Walk
        if (direction.x + direction.z != 0){
            animator.SetBool("IsWalking", true);
        }else{
            animator.SetBool("IsWalking", false);
        }

        // Run
        if (Input.GetKey(KeyCode.LeftShift)){
            animator.SetBool("IsRunning", true);
            speed = 4;
        }else{
            speed = 2;
            animator.SetBool("IsRunning", false);
        }
    }

    void Attack(){
        if (isAttacking) return;

        if (Input.GetButtonDown("Fire1")){
            isAttacking = true;
            animator.CrossFade("RunCombo", 0.1f);
        }
        if (Input.GetButtonDown("Fire2")){
            animator.CrossFade("SimpleCombo", 0.1f);
            isAttacking = true;
        }
        if (Input.GetButtonDown("Fire3")){
            animator.CrossFade("Slash", 0.1f);
            isAttacking = true;
        }
    }

    public void AfterAttack(){
        isAttacking = false;
        print("Attacked");
    }

    void OnAnimatorMove(){

        // if (animator.GetCurrentAnimatorStateInfo(0).IsName("SimpleCombo")){
        // }

        direction = animator.deltaPosition;
        controller.Move(direction);
    }


    // bool isPlaying(Animator anim, string stateName)
    // {
    //     if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
    //             anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
    //         return true;
    //     else
    //         return false;
    // }
}
