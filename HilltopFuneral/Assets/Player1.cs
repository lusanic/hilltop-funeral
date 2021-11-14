using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float forceForward;
    public float forceHorizontal;

    public GameObject casket;
    // Start is called before the first frame update
    void Start()
    {
        casket = GameObject.Find("Casket");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            GetComponent<Rigidbody>().AddForce(Vector3.forward * forceForward);
            Vector3 relativePos = transform.position - casket.transform.position;
            casket.GetComponent<Rigidbody>().AddForce(relativePos/2);
        }

        if (Input.GetKey(KeyCode.LeftArrow)){
            GetComponent<Rigidbody>().AddForce(Vector3.left * forceHorizontal);
            Vector3 relativePos = transform.position - casket.transform.position;
            casket.GetComponent<Rigidbody>().AddForce(relativePos/2);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            GetComponent<Rigidbody>().AddForce(Vector3.right * forceHorizontal);
            Vector3 relativePos = transform.position - casket.transform.position;
            casket.GetComponent<Rigidbody>().AddForce(relativePos/2);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            GetComponent<Rigidbody>().AddForce(-Vector3.forward * forceHorizontal);
        }



    }
}
