using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float forceForward = 10.0f;

    public bool foundCas;
    public bool lift;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(foundCas){
            GetComponent<Rigidbody>().drag = 15;
        }
        else{
            GetComponent<Rigidbody>().drag = 0;
        }
        if (Input.GetKey(KeyCode.W)){
            GetComponent<Rigidbody>().AddForce(Vector3.forward * forceForward);
            if(foundCas){
                lift = true;
            }
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
        if(Input.GetKeyUp(KeyCode.UpArrow)){
            lift = false;
        }


    }

    void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "Casket"){
            foundCas = true;
        }
    }

    void OnCollisionExit(Collision coll){
        if (coll.gameObject.name == "Casket"){
            foundCas = false;
        }
    }
}
