using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    public Button botonEstanterias;
    private string fileName, myFilePath, pathToWrite;
    private string respuestaVuelo, respuestaCuerda, respuestaViento, respuestaEstanterias;
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

                if (respuestaVuelo == "SI")
                {
                    botonVuelo.gameObject.SetActive(true);
                }
                if (respuestaCuerda == "SI")
                {
                    botonCuerda.gameObject.SetActive(true);
                }
                if (respuestaViento == "SI")
                {
                    botonViento.gameObject.SetActive(true);
                }
                if (respuestaEstanterias == "SI")
                {
                    botonEstanterias.gameObject.SetActive(true);
                }
            }
        }
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
