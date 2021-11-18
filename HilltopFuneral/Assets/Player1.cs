using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float forceForward;
    public float forceHorizontal;
    public float acceleration;

    public bool foundCas;
    public bool lift;

    public GameObject casket;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        casket = GameObject.Find("Casket");
        player2 = GameObject.Find("Player2");
        forceForward = acceleration * GetComponent<Rigidbody>().mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(foundCas){
            GetComponent<Rigidbody>().drag = 10;
        }
        else{
            GetComponent<Rigidbody>().drag = 5;
        }

        if (Input.GetKey(KeyCode.UpArrow)){
            if(foundCas){
                lift = true;
            }
            GetComponent<Rigidbody>().AddForce(Vector3.forward * forceForward);
            if(lift && player2.GetComponent<Player2>().lift){
                Vector3 relativePos = transform.position - casket.transform.position;
                // Debug.Log(relativePos);
                // var step = 0.5f * Time.deltaTime;
                // casket.transform.rotation = Quaternion.RotateTowards(casket.transform.rotation, transform.rotation, step);
                casket.GetComponent<Rigidbody>().AddForce(relativePos);
            }

        }

        if (Input.GetKey(KeyCode.LeftArrow)){

            GetComponent<Rigidbody>().AddForce(Vector3.left * forceHorizontal);
            if(lift && player2.GetComponent<Player2>().lift){
                Vector3 relativePos = transform.position - casket.transform.position;
                casket.GetComponent<Rigidbody>().AddForce(relativePos/2);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            GetComponent<Rigidbody>().AddForce(Vector3.right * forceHorizontal);
            if(lift && player2.GetComponent<Player2>().lift){
                Vector3 relativePos = transform.position - casket.transform.position;
                casket.GetComponent<Rigidbody>().AddForce(relativePos/2);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            GetComponent<Rigidbody>().AddForce(-Vector3.forward * forceForward);
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

    // void OnCollisionExit(Collision coll){
    //     if (coll.gameObject.name == "Casket"){
    //         foundCas = false;
    //     }
    // }

    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.tag == "Casket"){
            foundCas = true;
        }
    }

    void OnTriggerExit(Collider coll){
        if (coll.gameObject.tag == "Casket"){
            foundCas = false;
        }
    }
}
