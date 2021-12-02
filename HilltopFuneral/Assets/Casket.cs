using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casket : MonoBehaviour
{

    public Rigidbody rigidbody;
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
    public float pullForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player2 = GameObject.Find("Player2");
        rigidbody.centerOfMass = com;
    }
    private void Awake()
    {
        speed = walkSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        turnX = Input.GetAxisRaw("Horizontal");
        turnY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(turnX, 0, turnY).normalized;
        Vector3 targetMoveAmount = moveDir * speed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
    }


    void FixedUpdate()
    {
        player2.GetComponent<Player2>().AttractPlayer2(rigidbody);
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigidbody.AddTorque(transform.forward * torqueX * turnX);
        rigidbody.AddTorque(-transform.right * torqueY * turnY);

    }

    public void AttractCasket(Rigidbody player)
    {
        Vector3 above = GetBehindPosition(player.transform, 0, 1.5f);

        Vector3 vectorTo = (rigidbody.position - above).normalized;
        float casketDist = Vector3.Distance(rigidbody.position, above);


        Quaternion h = Quaternion.FromToRotation(rigidbody.transform.forward, vectorTo) * rigidbody.rotation;
        rigidbody.rotation = Quaternion.RotateTowards(rigidbody.rotation, h, 5f);
    }

    public Vector3 GetBehindPosition(Transform target, float distanceBehind, float distanceAbove)
    {
        return target.position - (target.forward * distanceBehind) + (target.up * distanceAbove);
    }
}
