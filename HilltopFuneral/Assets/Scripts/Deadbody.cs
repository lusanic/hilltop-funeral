using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadbody : MonoBehaviour
{
    public bool isGrounded = false;
    public GameObject deathReset;
    AudioSource AS;
    public AudioClip bodyFalling;

    // Start is called before the first frame update
    void Start()
    {
        deathReset = GameObject.Find("DeathReset");
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void OnCollisionEnter(Collision coll){
        if(coll.gameObject.name.Contains("Terrain")){
            GameState.onGround = true;
            AS.PlayOneShot(bodyFalling);
            
        }

        Debug.Log(GameState.onGround);
    }


}
