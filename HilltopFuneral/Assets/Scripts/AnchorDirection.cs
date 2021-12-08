using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorDirection : MonoBehaviour
{

 
    public GameObject player2;

    public Terrain terrain;

    // Movement
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    public LayerMask groundedMask;

    Vector3 Rotation;
    public float turnVertcial = 3f;
    public float turnHorizontal = 2f;


    private int pushCount = 0;
    private bool front = true;

    private float gdistance = 0f;

    private Vector3 directionToPlayer1;

    // Start is called before the first frame update
    void Start()
    {

        float groundLevel = Terrain.activeTerrain.SampleHeight(transform.position);
        gdistance = groundLevel;
    }
    private void Awake()
    {

    }


    void Update()
    {
      
    }


    void FixedUpdate()
    {
        float groundLevel = Terrain.activeTerrain.SampleHeight(transform.position);
        gdistance = groundLevel;

        Vector3 lookatPos = new Vector3(transform.position.x, gdistance, transform.position.z);
        transform.position = lookatPos;
    }

    public Vector3 getDirectionToPlayer1()
    {
        return directionToPlayer1;
    }

    public void AttractAnchorDirection(Rigidbody player)
    {
        directionToPlayer1 = (this.transform.position - player.transform.position).normalized;
        //Vector3 pos = anchorrigidbody.transform.position;
        //Vector3 posPlayer = player.transform.TransformPoint(0, 5f, -5f);
        //posPlayer.y = gdistance + groundUp;
        //anchorrigidbody.position = Vector3.MoveTowards(anchorrigidbody.position, posPlayer, pullForce * Time.deltaTime);
        transform.LookAt(player.position);
    }

    public Vector3 GetBehindPosition(Transform target, float distanceBehind, float distanceAbove)
    {
        return target.position - (target.forward * distanceBehind) + (target.up * distanceAbove);
    }
}
