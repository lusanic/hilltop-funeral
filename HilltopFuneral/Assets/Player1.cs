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
    public GameObject anchor;


    // Body
    public Rigidbody rigidbody;
    private Rigidbody casketBody;

    // Movement
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    public float walkSpeed = 6;
    private float speed;

    // Start is called before the first frame update
  
    private Vector3 targetAngle;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        casketBody = casket.GetComponent<Rigidbody>();
    }
    
    private void Awake()
    {
        casket = GameObject.FindGameObjectWithTag("Casket");
        anchor = GameObject.FindGameObjectWithTag("Anchor");
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxisRaw("Horizontal2");
        float inputY = Input.GetAxisRaw("Vertical2");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * speed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);


        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        //}
    }

    private void FixedUpdate()
    {
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + localMove);
        casket.GetComponent<Casket>().AttractCasket(rigidbody);
        anchor.GetComponent<Anchor>().AttractAnchor(rigidbody);


        Quaternion h = Quaternion.FromToRotation(rigidbody.transform.forward, localMove) * rigidbody.rotation;
        Vector3 direction = h.eulerAngles;
        h.x = 0;
        h.z = 0;

        rigidbody.rotation = Quaternion.RotateTowards(rigidbody.rotation, h, 0.3f);
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
