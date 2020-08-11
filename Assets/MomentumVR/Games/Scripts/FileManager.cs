using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    string[] lineas;
    string myFilePath, fileName;
    
    // Start is called before the first frame update
    void Start()
    {
        fileName = "ejercicios.txt";
        myFilePath = Application.dataPath + "/" + fileName;
        ReadFromFile();
    }

    public void ReadFromFile()
    {
        lineas = File.ReadAllLines(myFilePath);

        string pathToWrite = Application.dataPath + "/resultados.txt";

        if (!File.Exists(pathToWrite))
        {
            File.WriteAllText(pathToWrite, "--RESULTADOS--\n\n");
        }

        foreach (string line in lineas)
        {          
            string[] words = line.Split(':');

            //File.AppendAllText(pathToWrite, line + "\n");
            switch (words[0])
            {
                case "AGARRE":
                    if(words[1] == "SI")
                        File.AppendAllText(pathToWrite, "Me han mandado el ejercicio de agarrar" + "\n");
                    break;
                case "COORD":
                    if (words[1] == "SI")
                        File.AppendAllText(pathToWrite, "Me han mandado el ejercicio de coordinación" + "\n");
                    break;
                case "CAMBIAROBJETOS":
                    if (words[1] == "SI")
                        File.AppendAllText(pathToWrite, "Me han mandado el ejercicio de cambiar objetos" + "\n");
                    break;
            }



        }
    }
}
