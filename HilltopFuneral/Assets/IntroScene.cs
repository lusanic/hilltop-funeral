using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour
{
    public GameObject cutSceneLabel;
    public GameObject cutscene;
    public GameObject nameInput;
    public GameObject nameLabel;

    public Sprite menuPage;
    public Sprite titlePage;

    public bool gameStart = true;
    public bool beforeName = false;
    public bool enterName = false;

    public File fileToRead;

    // Start is called before the first frame update
    void Start()
    {
        cutscene = GameObject.Find("Cutscene");

        cutSceneLabel = transform.GetChild(0).gameObject;
        fileToRead = new File("Assets/IntroDialogue.txt");
        fileToRead.storeLines();
        StartCoroutine(displayLine());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStart){
            if (Input.GetMouseButtonDown(0)){
                string line = fileToRead.getNextLine();
                if(line == ""){
                    cutSceneFadeOut();
                    StartCoroutine(cutSceneFadeIn(titlePage));
                    gameStart = false;
                }
                else{
                    cutSceneLabel.GetComponent<Text>().text = line;
                } 
            }
        }

        if(beforeName){
            if (Input.GetMouseButtonDown(0)){
                StartCoroutine(triggerEnterName());

            }
        }

        if(enterName){
            Debug.Log("at enter name");
            if(Input.GetMouseButtonDown(0)){
                cutSceneLabel.SetActive(false);
                nameInput.SetActive(true);
                nameLabel.SetActive(true);
                enterName = false;
            }
        }


        
    }


    public IEnumerator displayLine(){
        yield return new WaitForSeconds(3.0f);
        cutscene.GetComponent<Animator>().Play("cutsceneLabelFadeIn");
        if(beforeName){
            enterName = true;
            beforeName = false;
        }
    }

    public void cutSceneFadeOut(){
        cutscene.GetComponent<Animator>().Play("cutsceneFadeOut");
    }

    public void cutSceneImageFadeOut(){
        cutscene.GetComponent<Animator>().Play("cutsceneImageFadeOut");
    }

    public IEnumerator cutSceneFadeIn(Sprite img){
        yield return new WaitForSeconds(3.0f);
        cutscene.GetComponent<Image>().sprite = img;
        cutscene.GetComponent<Animator>().Play("cutsceneFadeIn");
        if(img == titlePage){
            beforeName = true;
        }
    }


    public IEnumerator triggerEnterName(){
        cutSceneImageFadeOut();
        yield return new WaitForSeconds(2.0f);
        cutSceneLabel.GetComponent<Text>().text = "Bonko and Slappy started a new business and they already have their first customer!";
        cutscene.GetComponent<Image>().sprite = menuPage;
        StartCoroutine(displayLine());
        yield return new WaitForSeconds(1.0f);


    }
}
