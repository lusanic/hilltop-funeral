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
    public bool afterName = false;

    public File fileToRead;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        cutscene = GameObject.Find("Cutscene");
        anim = cutscene.GetComponent<Animator>();

        cutSceneLabel = transform.GetChild(0).gameObject;
        fileToRead = new File("Assets/TextFiles/IntroDialogue.txt");
        fileToRead.storeLines();
        //StartCoroutine(displayLine());
        anim.Play("cutsceneStart");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStart){
            if (Input.GetMouseButtonDown(0)){
                string line = fileToRead.getNextLine();
                if(line == ""){
                    anim.Play("cutsceneTitleTransition");
                    gameStart = false;
                }
                else{
                    cutSceneLabel.GetComponent<Text>().text = line;
                } 
            }
        }

        if(beforeName){
            cutSceneLabel.GetComponent<Text>().text = "Bonko and Slappy started a new business and they already have their first customer!";
            if (Input.GetMouseButtonDown(0)){
                anim.Play("titleToCutscene");
                beforeName = false;


            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 
            && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "titleToCutscene"){
            if(Input.GetMouseButtonDown(0) && enterName){
                cutSceneLabel.SetActive(false);
                nameInput.SetActive(true);
                nameLabel.SetActive(true);
                enterName = false;
            }
        }
        

        if(GameState.afterName){
            if(Input.GetMouseButtonDown(0)){
                transform.GetChild(3).gameObject.SetActive(false);
                cutSceneLabel.SetActive(true);
                fileToRead = new File("Assets/TextFiles/IntroEnd.txt");
                fileToRead.storeLines();
                GameState.afterName = false;
                afterName = true;
            }
        }

        if(afterName){
            if (Input.GetMouseButtonDown(0)){
                string line = fileToRead.getNextLine();
                if(line == ""){
                    anim.Play("cutsceneEnd");
                    gameStart = false;
                }
                else{
                    if(fileToRead.getLineIndex()== 0){
                        line = "Bonko and Slappy had prepared a lovely ceremony for "+GameState.name+" atop a beautiful hill.";
                    }
                    cutSceneLabel.GetComponent<Text>().text = line;
                } 
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
        yield return new WaitForSeconds(1.0f);
        cutSceneLabel.GetComponent<Text>().text = "Bonko and Slappy started a new business and they already have their first customer!";
        cutscene.GetComponent<Image>().sprite = menuPage;
        StartCoroutine(displayLine());
        yield return new WaitForSeconds(1.0f);


    }
}
