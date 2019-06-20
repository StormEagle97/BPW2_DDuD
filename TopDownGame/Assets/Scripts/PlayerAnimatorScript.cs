using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour {

    private Animation anim;
    public Animator animator;

    void Start () {
        anim = gameObject.GetComponent<Animation>();
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        if (Input.GetKey("w")) {
            animator.SetBool("Front", true);
        }
        if (Input.GetKeyUp("w"))
        {
            animator.SetBool("Front", false);
        }
        if (Input.GetKey("s"))
        {
            animator.SetBool("Back", true);
        }
        if (Input.GetKeyUp("s"))
        {
            animator.SetBool("Back", false);
        }
        if (Input.GetKey("a"))
        {
            animator.SetBool("Left", true);
        }
        if (Input.GetKeyUp("a"))
        {
            animator.SetBool("Left", false);
        }
        if (Input.GetKey("d"))
        {
            animator.SetBool("Right", true);
        }
        if (Input.GetKeyUp("d"))
        {
            animator.SetBool("Right", false);
        }
    }
}
