using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadbody : MonoBehaviour
{
    public bool isGrounded = false;
    public GameObject deathReset;

    // Start is called before the first frame update
    void Start()
    {
        deathReset = GameObject.Find("DeathReset");
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void OnCollisionEnter(Collision coll){
        if(coll.gameObject.name.Contains("Terrain")){
            GameState.onGround = true;
            
        }

        Debug.Log(GameState.onGround);
    }
}
