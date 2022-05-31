using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _Planim;
    private Vector3 Axis, Cursor;
    public  int sp;
    private bool isStand, isRun;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _Planim = GetComponent<Animator>();

        isStand = false;
    }
    private void Update()
    {
        Axis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        isStand = Axis.magnitude == 0;
        if (!isStand)
        {
            
            isRun = true;
            Move();
        }
        else
        {
            isStand = true;
            isRun = false;
        }
        
    }



    void Move()
    {
        //          _Planim.SetBool("isRunnin", true);
        
        _rb.velocity = Axis * sp * Time.deltaTime;
    }
}
