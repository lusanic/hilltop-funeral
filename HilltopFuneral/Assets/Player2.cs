using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float forceForward;
    public float acceleration;

    public bool foundCas;
    public bool lift;


    // Body
    public Rigidbody rigidbody;

    // Movement
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    public float walkSpeed = 6;
    private float speed;




    // Start is called before the first frame update
    void Start()
    {
        forceForward = acceleration * GetComponent<Rigidbody>().mass;
        rigidbody = GetComponent<Rigidbody>();
        setRigidbodyState(true);
        setColliderState(false);
    }

    private void Awake()
    {
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * speed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        // Check if on ground
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;



        //if (foundCas){
        //    GetComponent<Rigidbody>().drag = 10;
        //}
        //else{
        //    GetComponent<Rigidbody>().drag = 5;
        //}


    }

    private void FixedUpdate()
    {
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + localMove);
    }

    void setRigidbodyState(bool state){
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies){
            rb.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    void setColliderState(bool state){
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider coll in colliders){
            GetComponent<Collider>().enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }


}
