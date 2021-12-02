using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{

    public Rigidbody anchorrigidbody;
    public GameObject player2;

    // Movement
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    public Vector3 com;
    public float walkSpeed = 6;
    public float pushForce = 15;
    private float speed;

    Vector3 Rotation;
    public float turnVertcial = 3f;
    public float turnHorizontal = 2f;

    float turnX;
    float turnY;
    public float torqueX = 20;
    public float torqueY = 20;

    private int pushCount = 0;
    private bool front = true;

    //Pull
    public float pullForce = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        anchorrigidbody = GetComponent<Rigidbody>();
        anchorrigidbody.centerOfMass = com;
    }
    private void Awake()
    {
        speed = walkSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        //transform.position = anchorrigidbody.position;
    }


    void FixedUpdate()
    {

    }

    public void AttractAnchor(Rigidbody player)
    {
        Vector3 pos = anchorrigidbody.transform.position;
        anchorrigidbody.position = Vector3.MoveTowards(anchorrigidbody.position, player.transform.TransformPoint(0, 5, -5), pullForce * Time.deltaTime);
       
    }

    public Vector3 GetBehindPosition(Transform target, float distanceBehind, float distanceAbove)
    {
        return target.position - (target.forward * distanceBehind) + (target.up * distanceAbove);
    }
}
