using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    
    private Transform chGround;

    private Animator _Planim;
    public LayerMask whatisGround;
    private Vector3 Axis;

    public  int sp, runSpeed;
    private float grRadius = 2; 
    private bool isStand, isWalk, isRun, Jumped, isGr;

    private void Awake()
    {
        chGround = transform.GetChild(3).GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        _Planim = GetComponent<Animator>();
        

        isStand = true;
        isWalk = false;
        isRun = false;
        Jumped = false;
    }
    protected void FixedUpdate()
    {
        Axis = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward; 
        isGr = Physics.CheckSphere(chGround.position, grRadius, whatisGround);
        isStand = Axis.magnitude == 0;
        if (!isStand && isGr)
        {
            
            Move();
            
           
        }
        
        else
        {
            isStand = true;
            isWalk = false;
            isRun = false;
            _Planim.SetBool("isWalk", isWalk);
            _Planim.SetBool("isStand", isStand);
            _Planim.SetBool("isRun", isRun);


        }
        
    }


   
    
    void Move()
    {
         isWalk = true;
        _Planim.SetBool("isWalk", isWalk);
        _Planim.SetBool("isStand", isStand);
        rb.MovePosition(transform.position + Axis * sp * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift) && !isRun)
        {
            isWalk = false;
            Run();
        }
    }

    void Run()
    {
        
        isRun = true;
        _Planim.SetBool("isRun", isRun);
        _Planim.SetBool("isWalk", isWalk);
        _Planim.SetBool("isStand", isStand);
        rb.velocity = -transform.position + Axis * runSpeed * Time.deltaTime;
    }
   
}
