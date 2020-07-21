using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private float timeZero;
    [SerializeField]
    private TextMesh textMesh;
    private float time;

    public static GameManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        time = Time.realtimeSinceStartup;
        timeZero = Time.realtimeSinceStartup;
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.realtimeSinceStartup - timeZero;
        textMesh.text = "Time: " + (int)((Time.realtimeSinceStartup - timeZero));
    }

    public void WriteToFile()
    {
        string pathToWrite = Application.dataPath + "/resultadosConTime.txt";

        if (!File.Exists(pathToWrite))
        {
            File.WriteAllText(pathToWrite, "--RESULTADOS--\n\n");
        }

        File.AppendAllText(pathToWrite, "He terminado el ejercicio " + SceneManager.GetActiveScene().name + " con un tiempo de " + time + " segundos \n");
        Application.Quit(); //cambiar a inicio del siguiente ejercicio
    }
}
