using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Transform tr;
    private Rigidbody rb;
    private Animator _Planim;
    private LayerMask chGround;
    private Vector3 Axis, Cursor;
    public  int sp;
    private float grRadius = 2; 
    private bool isStand, isRun, Jumped, CheckGround;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        _Planim = GetComponent<Animator>();
        chGround = GameObject.FindGameObjectWithTag("Ground").layer;

        isStand = true;
        isRun = false;
        Jumped = false;
    }
    private void Update()
    {
        Axis = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));

        isStand = Axis.magnitude == 0;
        if (!isStand)
        {           
            Move();
        }
        else
        {
            _Planim.SetBool("isRun", false);
            _Planim.SetBool("isStand", true);
            isStand = true;
            isRun = false;
        }
        
    }


   
    
    void Move()
    {
        isRun = true;
        _Planim.SetBool("isRun", true);
        _Planim.SetBool("isStand", false);
        rb.velocity = Axis * sp * Time.deltaTime;
        
    }
}
