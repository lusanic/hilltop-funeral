using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class File : MonoBehaviour
{
    private string filePath;
    public int index;
    public List<string> fileLines;


    public File(string path){
        filePath = path;
        index = 0;
    }

    public void storeLines(){
        fileLines = new List<string>();
        StreamReader reader = new StreamReader(filePath);
        string line;
        while((line = reader.ReadLine())!=null){
            fileLines.Add(line);
        }
        reader.Close();
    }

    public string getNextLine(){
        string line = "";
        if(index <= fileLines.Count-1){
            line = fileLines[index];
            index = index + 1;
        }
        return line;
        
    }

    public int getLineIndex(){
        return (index-1);
    }
}
