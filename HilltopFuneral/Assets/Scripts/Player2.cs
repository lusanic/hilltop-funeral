using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    public bool foundCas;
    public bool lift;

    public GameObject anchorDirection;

    public float pullForce = 10.0f;

    public float smoothSpeed = 0.125f;
    public float smoothSpeedR = 2f;

    // Body
    public Rigidbody thisrigidbody;


    // Start is called before the first frame update
    void Start()
    {
        anchorDirection = GameObject.FindGameObjectWithTag("AnchorDirection");
        //forceForward = acceleration * GetComponent<Rigidbody>().mass; 
    }

    private void Awake()
    {
        //thisrigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Check if on ground
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        //Vector3 pos = transform.position;
        //float groundLevel = Terrain.activeTerrain.SampleHeight(transform.position);
        //pos.y = groundLevel;
        //transform.position = pos;

    }

    public void AttractPlayer2(Rigidbody casket)
    {
        Vector3 pos = transform.position;
        float groundLevel = Terrain.activeTerrain.SampleHeight(transform.position);
        Vector3 posCasket = casket.transform.TransformPoint(0, -2f, 1.0f);
        posCasket.y = groundLevel;

        transform.position = Vector3.MoveTowards(pos, posCasket, pullForce * Time.deltaTime);
        Vector3 lookatPos = new Vector3(casket.position.x, casket.position.y - 1.0f, casket.position.z);
        transform.LookAt(lookatPos);
    }



    public Vector3 GetBehindPosition(Transform target, float distanceBehind, float distanceAbove)
    {
        return target.position - (target.forward * distanceBehind) + (target.up * distanceAbove);
    }

    private void FixedUpdate()
    {

    }

    //void OnCollisionEnter(Collision coll){
    //    if (coll.gameObject.name == "Casket"){
    //        foundCas = true;
    //    }
    //}

    // void OnCollisionExit(Collision coll){
    //     if (coll.gameObject.name == "Casket"){
    //         foundCas = false;
    //     }
    // }

    //void OnTriggerEnter(Collider coll){
    //    if (coll.gameObject.tag == "Casket"){
    //        Debug.Log("found casket");
    //        foundCas = true;
    //    }
    //}

    //void OnTriggerExit(Collider coll){
    //    if (coll.gameObject.tag == "Casket"){
    //        foundCas = false;
    //    }
    //}
}
