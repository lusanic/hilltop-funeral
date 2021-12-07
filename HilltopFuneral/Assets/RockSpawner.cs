using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public float spawnCountDown = 10.0f;
    private float spawnCDVal;
    private float positionX;
    private float positionY;
    private float positionZ;

    public GameObject rock;
    // Start is called before the first frame update
    void Start()
    {

        positionY = 100.0f;
        spawnCDVal = spawnCountDown;
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountDown -= Time.deltaTime;
        if(spawnCountDown<=0){
            generateObject();
            spawnCountDown = spawnCDVal;
        }

    }



    public void generateObject(){
        positionZ = Random.Range(480, 530);
        positionX = Random.Range(120, 500);
        Vector3 position = new Vector3(positionX, positionY, positionZ);
        GameObject instantiatedObject = Instantiate(rock, position, Quaternion.identity) as GameObject;
    }
}
