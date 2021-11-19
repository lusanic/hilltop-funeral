using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casket : MonoBehaviour
{

    public Rigidbody rigidbody;

    //Pull
    public float pullForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
    }


    void FixedUpdate()
    {

    }

    public void AttractCasket(Rigidbody player)
    {
        Vector3 vectorTo = (rigidbody.position - player.position).normalized;
        float casketDist = Vector3.Distance(rigidbody.position, player.position);

        if (Mathf.Abs(casketDist) < 7)
        {
            rigidbody.rotation = Quaternion.FromToRotation(rigidbody.transform.forward, vectorTo) * rigidbody.rotation;
            rigidbody.AddForce(-vectorTo * (casketDist * 4));
        }
    }
}
