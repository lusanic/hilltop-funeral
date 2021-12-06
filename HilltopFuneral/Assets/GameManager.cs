using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private string name;
    private string date;

    public GameObject canvas;
    public GameObject nameLabel;
    public GameObject nameInput;
    public GameObject startButton;

    public GameObject player1;
    public GameObject player2;

    public GameObject casket;
    public GameObject deadBody;

    // Start is called before the first frame update
    void Start()
    {
        date =  System.DateTime.Now.ToString("MM/dd");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    public void inputName(string input){
        name = input;
        Debug.Log(name);
    }

    public void updateDate(GameObject obj){
        nameLabel.SetActive(false);
        nameInput.SetActive(false);
        
        obj.SetActive(true);
        string deathLabel = "On " + date +",\n\n"+ name + " has died."; 

        obj.GetComponent<Text>().text = deathLabel;
        startButton.SetActive(true);
    }

    public void startGame(GameObject obj){
        startButton.SetActive(false);
        obj.SetActive(false);

        canvas.SetActive(false);
        casket.SetActive(true);
        player1.SetActive(true);
        player2.SetActive(true);
        deadBody.SetActive(true);
    }


}
