using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float forceForward;
    public float acceleration;

    public bool foundCas;
    public bool lift;
    // Start is called before the first frame update
    void Start()
    {
        forceForward = acceleration * GetComponent<Rigidbody>().mass;
        setRigidbodyState(true);
        setColliderState(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if(foundCas){
        //     GetComponent<Rigidbody>().drag = 10;
        // }
        // else{
        //     GetComponent<Rigidbody>().drag = 5;
        // }
        if (Input.GetKey(KeyCode.W)){
            if(foundCas){
                lift = true;
            }
            GetComponent<Rigidbody>().AddForce(Vector3.forward * forceForward);

        }

        if (Input.GetKey(KeyCode.A)){
            GetComponent<Rigidbody>().AddForce(Vector3.left * forceForward);
        }
        if (Input.GetKey(KeyCode.S)){
            GetComponent<Rigidbody>().AddForce(-Vector3.forward * forceForward);
        }
        if (Input.GetKey(KeyCode.D)){
            GetComponent<Rigidbody>().AddForce(Vector3.right * forceForward);
        }
        if(Input.GetKeyUp(KeyCode.W)){
            lift = false;
        }


    }

    void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "Casket"){
            foundCas = true;
        }
    }

    // void OnCollisionExit(Collision coll){
    //     if (coll.gameObject.name == "Casket"){
    //         foundCas = false;
    //     }
    // }

    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.tag == "Casket"){
            Debug.Log("found casket");
            foundCas = true;
        }
    }

    void OnTriggerExit(Collider coll){
        if (coll.gameObject.tag == "Casket"){
            foundCas = false;
        }
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
            coll.enabled = state;
        }
        GetComponent<Collider>().enabled = !state;
    }
}
