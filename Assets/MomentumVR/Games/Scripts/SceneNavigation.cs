using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigation : MonoBehaviour
{
    public static SceneNavigation instance = null;
    public GameObject[] popUps;
    public Button botonVuelo;
    public Button botonCuerda;
    public Button botonViento;
    public Button botonHandTracking;
    public Button botonEstanterias;
    public Button botonPuntuacionVuelo;
    public Button botonPuntuacionCuerda;
    public Button botonPuntuacionViento;
    public Button botonPuntuacionHandTracking;
    private string fileName, myFilePath, pathToWrite;
    private string respuestaVuelo, respuestaCuerda, respuestaViento, respuestaEstanterias, respuestaHandTracking;
    private string puntuacionVuelo = "--VUELO--", puntuacionCuerda = "--CUERDA--", puntuacionViento = "--VIENTO--", puntuacionHandTrack = "--HANDTRACKING--";
    private string[] lineas;
    //private Button[] botonesActivos;
    public List<Button> botonesActivos;

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

        botonesActivos = new List<Button>();

        if (File.Exists(myFilePath))
        {
            lineas = File.ReadAllLines(myFilePath);
        }
        if (lineas != null)
        {
            foreach (string line in lineas)
            {
                string[] words = line.Split(':');

                if (words[0] == "CUERDA")
                {
                    string[] parametros = words[1].Split('/');
                    respuestaCuerda = parametros[0];
                }
                else if (words[0] == "VUELO")
                {
                    string[] parametros = words[1].Split('/');
                    respuestaVuelo = parametros[0];
                }
                else if (words[0] == "VIENTO")
                {
                    string[] parametros = words[1].Split('/');
                    respuestaViento = parametros[0];
                }
                else if (words[0] == "ESTANTERIAS")
                {
                    string[] parametros = words[1].Split('/');
                    respuestaEstanterias = parametros[0];
                }
                else if (words[0] == "HANDTRACKING")
                {
                    string[] parametros = words[1].Split('/');
                    respuestaHandTracking = parametros[0];
                }

                if (respuestaVuelo == "SI")
                {
                    botonVuelo.gameObject.SetActive(true);
                    botonesActivos.Add(botonVuelo);                 
                }
                if (respuestaCuerda == "SI")
                {
                    botonCuerda.gameObject.SetActive(true);
                    botonesActivos.Add(botonCuerda);
                }
                if (respuestaViento == "SI")
                {
                    botonViento.gameObject.SetActive(true);
                    botonesActivos.Add(botonViento);
                }
                if (respuestaEstanterias == "SI")
                {
                    botonEstanterias.gameObject.SetActive(true);
                    botonesActivos.Add(botonEstanterias);
                }
                if (respuestaHandTracking == "SI")
                {
                    botonHandTracking.gameObject.SetActive(true);
                    botonesActivos.Add(botonHandTracking);
                }
            }
        }

        MostrarPuntuaciones();

    }
    private void Update()
    {
        print("Quiere Funcionar!!");
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            Debug.Log("Funciona!!");
        }
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void MostrarBotonesActivos()
    {
        foreach (Button button in botonesActivos) // loop through each letter in the list
        {
            button.gameObject.SetActive(true);
        }
    }

    public void MostrarPuntuaciones()
    {
        pathToWrite = "/sdcard/Download/" + "resultados.txt";

        if (File.Exists(pathToWrite))
        {
            lineas = File.ReadAllLines(pathToWrite);
        }
        if (lineas != null)
        {
            foreach (string line in lineas)
            {
                string[] words = line.Split(':');

                if (words[0] == "CUERDA")
                {
                    string[] parametros = words[1].Split('/');
                    puntuacionCuerda = puntuacionCuerda + "\n" + parametros[0];
                }
                else if (words[0] == "VUELO")
                {
                    string[] parametros = words[1].Split('/');
                    puntuacionVuelo = puntuacionVuelo + "\n" + parametros[0];
                }
                else if (words[0] == "VIENTO")
                {
                    string[] parametros = words[1].Split('/');
                    puntuacionViento = puntuacionViento + "\n" + parametros[0];
                }
                else if (words[0] == "HANDTRACKING")
                {
                    string[] parametros = words[1].Split('/');
                    puntuacionHandTrack = puntuacionHandTrack + "\n" + parametros[0];
                }

            }
        }

        botonPuntuacionCuerda.GetComponentInChildren<Text>().text = puntuacionCuerda;
        botonPuntuacionViento.GetComponentInChildren<Text>().text = puntuacionViento;
        botonPuntuacionVuelo.GetComponentInChildren<Text>().text = puntuacionVuelo;
        botonPuntuacionHandTracking.GetComponentInChildren<Text>().text = puntuacionHandTrack;

    }

    public void PopUpActive(int index)
    {
        popUps[index].SetActive(true);
    }
    public void PopUpDisactive(int index)
    {
        popUps[index].SetActive(false);
        Time.timeScale = 1;
    }

    public void ChangeScene(string s)
    {
        Time.timeScale = 1;
        Debug.Log("Cambio a la escena: " + s);
        StartCoroutine(CambioEscena(s));
    }
    IEnumerator CambioEscena(string escena)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(escena);
    }
    /*IEnumerator LoadingScene(string escena)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(escena);
        popUps[0].SetActive(true);
        while (!asyncLoad.isDone)
        {
            Debug.Log(asyncLoad.progress);
            yield return null;
        }
    }*/
}
