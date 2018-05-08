using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public Animator animator;
    public static bool Wwalk;
    public static bool Awalk;
    public static bool Swalk;
    public static bool Dwalk;

    void Start()
    {
        animator = GetComponent<Animator>();       
    }

        // Update is called once per frame
        void Update ()
    {
        //getkey
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Wwalk = true;
            animator.enabled = true;
            animator.Play("BackBomWalk");
        }
        else if (Input.GetKey(KeyCode.A )|| Input.GetKey(KeyCode.LeftArrow))
        {
            Awalk = true;
            animator.enabled = true;
            animator.Play("LeftBomWalk");
        }
        else if (Input.GetKey(KeyCode.D  )||Input.GetKey(KeyCode.RightArrow))
        {
            Dwalk = true;
            animator.enabled = true;
            animator.Play("RightBomWalk");
        }
        else if (Input.GetKey(KeyCode.S )||Input.GetKey(KeyCode.DownArrow))
        {
            Swalk = true;
            animator.enabled = true;
            animator.Play("FaceWalk");
        }
        //getkeyup
        if (Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.S)
            ||Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.DownArrow))
        {
            Wwalk = false;
            Awalk = false;
            Swalk = false;
            Dwalk = false;
            animator.enabled = false ;
        }
    }
}
