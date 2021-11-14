using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casket : MonoBehaviour
{
    public bool p1lift = false;
    public bool p2lift = false;

    public Transform target;

    // Angular speed in radians per sec.
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "Player1"){
            p1lift = true;
        }
        if(coll.gameObject.name == "Player2"){
            p2lift = true;
        }
    }

    void moveCasket(){
    }
}
