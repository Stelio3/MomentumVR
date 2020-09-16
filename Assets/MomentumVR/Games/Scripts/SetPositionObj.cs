using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SetPositionObj : MonoBehaviour
{
    public static SetPositionObj instance = null;
    private string fileName, myFilePath, pathToWrite;
    private string distance;
    private float move = 0.5f;
    public GameObject Left_go, right_go;
    private string[] lineas;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        fileName = "ejercicios.txt";
        myFilePath = "/sdcard/Download/" + fileName;
        pathToWrite = "/sdcard/Download/" + "resultados.txt";

        if (File.Exists(myFilePath))
        {
            lineas = File.ReadAllLines(myFilePath);
        }
        if (lineas != null)
        {
            foreach (string line in lineas)
            {
                string[] words = line.Split(':');

                if (words[0] == "ESTANTERIAS")
                {
                    string[] parametros = words[1].Split('/');
                    distance = parametros[1];
                }

                if (distance == "BAJA")
                {
                    Left_go.transform.position -= new Vector3(move,0,0);
                    right_go.transform.position += new Vector3(move, 0, 0);
                }
                else if (distance == "ALTA")
                {
                    Left_go.transform.position -= new Vector3(move, 0, 0);
                    right_go.transform.position += new Vector3(move, 0, 0);
                }
            }
        }
    }

}
