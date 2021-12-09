using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.triggerCheckpoint && GameState.level == 2){
            checkpointUI.SetActive(true);
            ChangeText(600);
            
        }
    }



    public void ChangeText(int meters){
        checkpointUI.transform.GetChild(0).gameObject.GetComponent<Text>().text = "You dropped "+GameState.name+" "
            +GameState.dropped+" times!\n Just "+meters+ " meters left until we get there!";
    }


    public void CheckpointOver(){
        checkpointUI.SetActive(false);
    }
}
