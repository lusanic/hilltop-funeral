using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public static class GameState
{
    public static int dropped = 0;
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
    public GameObject droppedLabel;

    public GameObject deathCanvas;

    public GameObject player1;
    public GameObject player2;
    public GameObject p1dialogue;
    public GameObject p2dialogue;

    public GameObject casket;
    public GameObject deadBody;
    public GameObject anchor;
    public GameObject anchorDir;

    public int level = 1;

    public Vector3 p1Pos;
    public Vector3 p2Pos;
    public Vector3 casPos;
    public Vector3 bodyPos;
    public Vector3 anchorPos;
    public Vector3 anchorDirPos;

    private List<string> deathCauses;
    private List<string> deathItems;

    // Start is called before the first frame update
    void Start()
    {
        date =  System.DateTime.Now.ToString("MM/dd");
        p1Pos = player1.transform.position;
        p2Pos = player2.transform.position;
        casPos = casket.transform.position;
        anchorPos = anchor.transform.position;
        bodyPos = deadBody.transform.GetChild(1).position;





        deathCauses = new List<string>();
        deathItems = new List<string>();

        readFile("Assets/TextFiles/Cause.txt", deathCauses);
        readFile("Assets/TextFiles/Items.txt", deathItems);

    }

    // Update is called once per frame
    void Update()
    {
        droppedLabel.GetComponent<Text>().text = "Dropped: "+GameState.dropped;

        if(GameState.onGround){
            p1Pos = player1.transform.position;
            p2Pos = player2.transform.position;
            casPos = casket.transform.position;
            anchorPos = anchor.transform.position;
            anchorDirPos = anchorDir.transform.position;
            bodyPos = new Vector3(casket.transform.position.x, casket.transform.position.y+2.0f, casket.transform.position.z);
            casket.transform.rotation = Quaternion.Slerp(casket.transform.rotation, Quaternion.Euler(0, 180, 0), 0.1f * Time.deltaTime);
            player2.transform.parent = null;
            handleDropping();
        }
    }

    public void readFile(string filePath, List<string> items){
        StreamReader reader = new StreamReader(filePath);
        string line;
        while((line = reader.ReadLine())!=null){
            items.Add(line);
        }
        reader.Close();
    }

    public void handleDropping(){
        GameState.dropped = GameState.dropped + 1;
        player1.transform.LookAt(deadBody.transform);
        player2.transform.LookAt(deadBody.transform);
        //disableCasket();
        disablePlayer1();
        disablePlayer2();
        disableBody();
        StartCoroutine(displayIngameDialogue());

        GameState.onGround = false;
    }


    public void inputName(string input){
        name = input;
        Debug.Log(name);
    }

    public void updateDate(GameObject obj){
        int causeIndex = Random.Range(0, deathCauses.Count-1);
        int itemIndex = Random.Range(0, deathItems.Count-1);
        nameLabel.SetActive(false);
        nameInput.SetActive(false);
        
        obj.SetActive(true);
        string deathLabel = "On " + date +",\n\n"+ name + " has died.\n\n Cause of Death: "+deathCauses[causeIndex]+" "+deathItems[itemIndex]+"."; 

        obj.GetComponent<Text>().text = deathLabel;
        startButton.SetActive(true);
    }

    public void startGame(){
        StartCoroutine(fadeCutscene());

    }

    public IEnumerator fadeCutscene(){
        canvas.GetComponent<Animator>().Play("cutsceneOver");
        yield return new WaitForSeconds(3.0f);
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
        anchor.GetComponent<Anchor>().enabled = false;
        anchor.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void enableCasket(){
        casket.GetComponent<Casket>().enabled = true;
        casket.GetComponent<Rigidbody>().isKinematic = false;
        anchor.GetComponent<Anchor>().enabled = true;
        anchor.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void disableBody(){
        deadBody.transform.GetChild(1).gameObject.GetComponent<Collider>().enabled = false;
        deadBody.transform.GetChild(1).gameObject.GetComponent<Deadbody>().enabled = false;
    }

    public IEnumerator displayIngameDialogue(){
        p1dialogue.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y+5.0f, player1.transform.position.z);
        p2dialogue.transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y+5.0f, player2.transform.position.z);
        yield return new WaitForSeconds(1.0f);
        // switch(GameState.life){
        //     case 2:
                
                p1dialogue.GetComponent<TextMesh>().text = "...";
                yield return new WaitForSeconds(1.0f);
                p2dialogue.GetComponent<TextMesh>().text = "Shit.";
                StartCoroutine(deathReset());
                //break;
        //     case 1:
        //         p1dialogue.GetComponent<TextMesh>().text = "One more time...";
        //         yield return new WaitForSeconds(0.2f);
        //         p2dialogue.GetComponent<TextMesh>().text = "We will be really screwed.";
        //         StartCoroutine(deathReset());
        //         break;
        //     default:
        //         break;
        // }
    }

    public IEnumerator deathReset(){
        deathCanvas.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        deathCanvas.GetComponent<Animator>().Play("DeathResetFadeIn");
        yield return new WaitForSeconds(2.0f);

        p1dialogue.GetComponent<TextMesh>().text = "";
        p2dialogue.GetComponent<TextMesh>().text = "";

        //reset position of objects
        player1.transform.position = p1Pos;
        player1.transform.rotation = Quaternion.Euler(0, 90, 0);

        player2.transform.position = p2Pos;
        player2.transform.rotation = Quaternion.Euler(0, 90, 0);

        casket.transform.position = casPos;
        casket.transform.rotation = Quaternion.Euler(0, 268, 0);

        anchor.transform.position = anchorPos;
        anchor.transform.rotation = Quaternion.Euler(0, 180, 0);

        deadBody.transform.GetChild(1).gameObject.transform.position = bodyPos;
        deadBody.transform.GetChild(1).localRotation = Quaternion.Euler(0, 0, 0);



        deadBody.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().isKinematic = true;
        resetBodyRotation();
        //reset Player 1 rotation
        player2.transform.parent = player1.transform;
        player2.transform.localPosition = new Vector3(0.4f, 0, -11);
        yield return new WaitForSeconds(0.5f);
        deathCanvas.GetComponent<Animator>().Play("DeathResetFadeOut");
        droppedLabel.SetActive(true);
        
        deadBody.transform.GetChild(1).gameObject.GetComponent<Collider>().enabled = true;
        deadBody.transform.GetChild(1).gameObject.GetComponent<Deadbody>().enabled = true;
        //enableCasket();
        player1.GetComponent<Player1>().enabled = true;
        player2.GetComponent<Player2>().enabled = true;
        
        yield return new WaitForSeconds(0.5f);
        
        deadBody.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().isKinematic = false;
        casket.GetComponent<Rigidbody>().isKinematic = false;
    }


    public void resetBodyRotation(){
        foreach(Transform child in deadBody.transform.GetChild(1)){
            if(child.gameObject.GetComponent<Collider>()!=null){
                child.localRotation = Quaternion.Euler(0, 0, child.eulerAngles.z);
            }
        }
    }
    


}
