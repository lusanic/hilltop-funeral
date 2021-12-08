using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameState
{
    public static int life = 3;
    public static bool onGround = false;


}

public class GameManager : MonoBehaviour
{
    private string name;
    private string date;

    public GameObject canvas;
    public GameObject nameLabel;
    public GameObject nameInput;
    public GameObject startButton;

    public GameObject deathCanvas;

    public GameObject player1;
    public GameObject player2;
    public GameObject p1dialogue;
    public GameObject p2dialogue;

    public GameObject casket;
    public GameObject deadBody;

    public int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        date =  System.DateTime.Now.ToString("MM/dd");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.onGround){
            handleDropping();
        }
    }

    public void handleDropping(){
        GameState.life = GameState.life-1;
        player1.transform.LookAt(deadBody.transform);
        player2.transform.LookAt(deadBody.transform);
        disablePlayer1();
        disablePlayer2();
        disableCasket();
        disableBody();
        StartCoroutine(displayIngameDialogue());

        GameState.onGround = false;
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

    public void disablePlayer1(){
        player1.GetComponent<Player1>().enabled = false;
        player1.GetComponent<Animator>().enabled = false;
    }

    public void disablePlayer2(){
        player2.GetComponent<Player2>().enabled = false;
        player2.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;
    }

    public void disableCasket(){
        casket.GetComponent<Casket>().enabled = false;
        casket.GetComponent<Rigidbody>().isKinematic = true;
        casket.transform.GetChild(0).gameObject.GetComponent<Anchor>().enabled = false;
        casket.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void enableCasket(){
        casket.GetComponent<Casket>().enabled = true;
        casket.GetComponent<Rigidbody>().isKinematic = false;
        casket.transform.GetChild(0).gameObject.GetComponent<Anchor>().enabled = true;
        casket.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void disableBody(){
        deadBody.transform.GetChild(1).gameObject.GetComponent<Collider>().enabled = false;
        deadBody.transform.GetChild(1).gameObject.GetComponent<Deadbody>().enabled = false;
    }

    public IEnumerator displayIngameDialogue(){
        p1dialogue.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y+5.0f, player1.transform.position.z);
        p2dialogue.transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y+5.0f, player2.transform.position.z);
        yield return new WaitForSeconds(1.0f);
        switch(GameState.life){
            case 2:
                
                p1dialogue.GetComponent<TextMesh>().text = "...";
                yield return new WaitForSeconds(1.0f);
                p2dialogue.GetComponent<TextMesh>().text = "Shit.";
                StartCoroutine(deathReset());
                break;
            case 1:
                p1dialogue.GetComponent<TextMesh>().text = "One more time...";
                yield return new WaitForSeconds(0.2f);
                p2dialogue.GetComponent<TextMesh>().text = "We will be really screwed.";
                StartCoroutine(deathReset());
                break;
            default:
                break;
        }
    }

    public IEnumerator deathReset(){
        yield return new WaitForSeconds(1.0f);
        deathCanvas.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        player1.transform.rotation = Quaternion.Euler(0, 90, 0);
        player1.GetComponent<Player1>().enabled = true;
        player2.GetComponent<Player2>().enabled = true;
        enableCasket();
        Vector3 newPos = new Vector3(casket.transform.position.x-1.0f, casket.transform.position.y+5.0f, casket.transform.position.z);
        deadBody.transform.GetChild(1).gameObject.transform.position = newPos;
        deadBody.transform.GetChild(1).localRotation = Quaternion.Euler(0, 0, 0);
        p1dialogue.GetComponent<TextMesh>().text = "";
        p2dialogue.GetComponent<TextMesh>().text = "";
        yield return new WaitForSeconds(1.0f);
        deathCanvas.GetComponent<Animator>().Play("DeathResetFadeOut");
        deadBody.transform.GetChild(1).gameObject.GetComponent<Collider>().enabled = true;
        deadBody.transform.GetChild(1).gameObject.GetComponent<Deadbody>().enabled = true;
    }


}
