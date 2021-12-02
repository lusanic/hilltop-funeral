using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public GameObject casket;

    public float turnVertcial = 3f;
    public float turnHorizontal = 2f;

    float turnX;
    float turnY;
    public float torqueX = 20;
    public float torqueY = 20;

    private int pushCount = 0;
    private bool front = true;

    Vector3 WindDirection;
    float WindSpeed = 500;
    public float windMin = 40f;
    public float windMax = 70f;

    private int windCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        casket = GameObject.FindGameObjectWithTag("Casket");
        WindDirection = Random.rotation.eulerAngles.normalized;
    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion h = Quaternion.FromToRotation(transform.forward, WindDirection) * transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, h, 2f);
    }

    void FixedUpdate()
    {
        windCounter++;
        // No wind
        if (windCounter > 100) 
        {
            // Blow wind for x frames
            casket.GetComponent<Casket>().BlowCasket(WindDirection, WindSpeed);
            if (windCounter > 400) // change wind speed
            {

                print("wind reset");
                WindDirection = Random.rotation.eulerAngles.normalized;
                WindSpeed = Random.Range(windMin, windMax);
                windCounter = 0;
            }
        }
    }

    public Vector3 GetBehindPosition(Transform target, float distanceBehind, float distanceAbove)
    {
        return target.position - (target.forward * distanceBehind) + (target.up * distanceAbove);
    }
}
