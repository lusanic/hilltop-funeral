using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float forceForward;
    public float forceHorizontal;

    public bool foundCas;
    public bool lift;

    public GameObject casket;
    public GameObject player2;


    // Body
    public Rigidbody rigidbody;
    private Rigidbody casketBody;

    // Movement
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    public float walkSpeed = 6;
    private float speed;

    // Start is called before the first frame update
  



    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        casketBody = casket.GetComponent<Rigidbody>();
        
    }
    
    private void Awake()
    {
        casket = GameObject.FindGameObjectWithTag("Casket");

        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        //if(foundCas){
        //    GetComponent<Rigidbody>().drag = 10;
        //}
        //else{
        //    GetComponent<Rigidbody>().drag = 5;
        //}

        //if (Input.GetKey(KeyCode.UpArrow)){
        //    if(foundCas){
        //        lift = true;
        //    }
        //    GetComponent<Rigidbody>().AddForce(Vector3.forward * forceForward);
        //    if(lift && player2.GetComponent<Player2>().lift){
        //        Vector3 relativePos = transform.position - casket.transform.position;
        //        casket.GetComponent<Rigidbody>().AddForce(relativePos);
        //    }

        float inputX = Input.GetAxisRaw("Horizontal2");
        float inputY = Input.GetAxisRaw("Vertical2");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * speed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        // Check ground
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        //}

        //if (Input.GetKey(KeyCode.LeftArrow)){

        //    GetComponent<Rigidbody>().AddForce(Vector3.left * forceHorizontal);
        //    if(lift && player2.GetComponent<Player2>().lift){
        //        Vector3 relativePos = transform.position - casket.transform.position;
        //        casket.GetComponent<Rigidbody>().AddForce(relativePos/2);
        //    }
        //}
        //if (Input.GetKey(KeyCode.RightArrow)){
        //    GetComponent<Rigidbody>().AddForce(Vector3.right * forceHorizontal);
        //    if(lift && player2.GetComponent<Player2>().lift){
        //        Vector3 relativePos = transform.position - casket.transform.position;
        //        casket.GetComponent<Rigidbody>().AddForce(relativePos/2);
        //    }
        //}
        //if (Input.GetKey(KeyCode.DownArrow)){
        //    GetComponent<Rigidbody>().AddForce(-Vector3.forward * forceForward);
        //}

        if(Input.GetKeyDown(KeyCode.W)){
           lift = true;
        }

        if(Input.GetKeyUp(KeyCode.W)){
           lift = false;
        }


        //if (foundCas){
        //    GetComponent<Rigidbody>().drag = 10;
        //}
        //else{
        //    GetComponent<Rigidbody>().drag = 5;
        //}

        // if (Input.GetKey(KeyCode.UpArrow)){
        //     if(foundCas){
        //         lift = true;
        //     }
        //     GetComponent<Rigidbody>().AddForce(Vector3.forward * forceForward);
        //     if(lift && player2.GetComponent<Player2>().lift){
        //         Vector3 relativePos = transform.position - casket.transform.position;
        //         casket.GetComponent<Rigidbody>().AddForce(relativePos);
        //     }

        // }

        // if (Input.GetKey(KeyCode.LeftArrow)){

        //     GetComponent<Rigidbody>().AddForce(Vector3.left * forceHorizontal);
        //     if(lift && player2.GetComponent<Player2>().lift){
        //         Vector3 relativePos = transform.position - casket.transform.position;
        //         casket.GetComponent<Rigidbody>().AddForce(relativePos/2);
        //     }
        // }
        // if (Input.GetKey(KeyCode.RightArrow)){
        //     GetComponent<Rigidbody>().AddForce(Vector3.right * forceHorizontal);
        //     if(lift && player2.GetComponent<Player2>().lift){
        //         Vector3 relativePos = transform.position - casket.transform.position;
        //         casket.GetComponent<Rigidbody>().AddForce(relativePos/2);
        //     }
        // }
        // if (Input.GetKey(KeyCode.DownArrow)){
        //     GetComponent<Rigidbody>().AddForce(-Vector3.forward * forceForward);
        // }

        // if(Input.GetKeyUp(KeyCode.UpArrow)){
        //     lift = false;
        // }
    }

    private void FixedUpdate()
    {
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + localMove);
        if(lift && player2.GetComponent<Player2>().lift){
            casket.GetComponent<Casket>().AttractCasket(rigidbody);
        }

    }


    //void OnCollisionExit(Collision coll)
    //{
    //    if (coll.gameObject.name == "Casket")
    //    {
    //        foundCas = false;
    //    }
    //}

    //void OnCollisionEnter(Collision coll){
    //    if (coll.gameObject.name == "Casket"){
    //        foundCas = true;
    //    }
    //}

    //// void OnCollisionExit(Collision coll){
    ////     if (coll.gameObject.name == "Casket"){
    ////         foundCas = false;
    ////     }
    //// }

    //void OnTriggerEnter(Collider coll){
    //    if (coll.gameObject.tag == "Casket"){
    //        foundCas = true;
    //    }
    //}

    //void OnTriggerExit(Collider coll){
    //    if (coll.gameObject.tag == "Casket"){
    //        foundCas = false;
    //    }
    //}
}
