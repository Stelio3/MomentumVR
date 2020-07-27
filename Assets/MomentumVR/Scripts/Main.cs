using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Main : MonoBehaviour
{
    void CreateText()
    {
        string path = Application.dataPath + "/Log.txt";

        //Create File if it does not exists
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "--RESULTADOS--\n\n");
        }
        //Add text
        string content1 = "-- Ejercicio 1 --\n";
        string content2 = "-- Ejercicio 2 --\n";
        string content3 = "-- Ejercicio 3 --\n";
        
        File.AppendAllText(path, content1);
        File.AppendAllText(path, content2);
        File.AppendAllText(path, content3);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
