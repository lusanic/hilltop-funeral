using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadbody : MonoBehaviour
{
    public bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void OnCollisionEnter(Collision coll){
        if(coll.gameObject.name == "Terrain"){
            GameState.onGround = true;
        }

        Debug.Log(GameState.onGround);
    }
}
