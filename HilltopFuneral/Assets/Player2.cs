using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    public bool foundCas;
    public bool lift;

    public float pullForce = 10.0f;

    // Body
    public Rigidbody thisrigidbody;

    // Start is called before the first frame update
    void Start()
    {
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

        //transform.GetChild(0).transform.localPosition = new Vector3(0,0,0);

        

    }

    public void AttractPlayer2(Rigidbody casket)
    {



        Vector3 pos = transform.position;
        transform.position = Vector3.MoveTowards(pos, casket.transform.TransformPoint(0, -2f, 1.0f), pullForce * Time.deltaTime);



        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, casket.transform.eulerAngles.y-178.0f, transform.eulerAngles.z);
 
        transform.rotation = Quaternion.Euler(eulerRotation);
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
