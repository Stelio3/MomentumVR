using Oculus.Platform.Samples.VrHoops;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    private GameObject prefab;
    private float timeZero;
    [SerializeField]
    private OVRPlayerController controlador;
    private string pathToWrite;
    private float time;
    public int points;
    private float highPos, lowPos;
    private float lastValueRight, lastValueLeft;
    public float period = 0.05f;
    private string fileName,myFilePath, tipoAmplitud, tipoVelocidad,respuesta;
    private string[] lineas;
    public static GameManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        tipoAmplitud = "MEDIA";
        time = Time.realtimeSinceStartup;
        timeZero = Time.realtimeSinceStartup;
        if (instance == null)
            instance = this;
        highPos = 0.0f;
        lowPos = 0.0f;
        lastValueRight = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)[1];
        lastValueLeft = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch)[1];
        fileName = "ejercicios.txt";
        myFilePath = "/sdcard/Download/" + fileName; 
        //myFilePath = Application.dataPath + fileName;  //oculus link
        points = 0;

        pathToWrite = "/sdcard/Download/" + "resultados.txt";
        //pathToWrite = Application.dataPath + "resultados.txt"; //oculus link

        if (File.Exists(myFilePath))
        {
            lineas = File.ReadAllLines(myFilePath);
        }

        if (lineas!=null)
        {
            foreach (string line in lineas)
            {
                string[] words = line.Split(':');
                if (words[0] == "VUELO")
                {
                    string[] parametros = words[1].Split('/');
                    respuesta = parametros[0];
                    tipoAmplitud = parametros[1];
                    tipoVelocidad = parametros[2];
                }
                
            }
        }
        

        for (int i = 10; i < 300; i+=30)
        {
            switch (tipoAmplitud)
            {
                case "BAJA":
                    GameTime.Instance.time = 200;
                    Instantiate(prefab, new Vector3(0, Random.Range(5.0f, 10.0f), i), Quaternion.identity);
                    break;
                case "MEDIA":
                    GameTime.Instance.time = 175;
                    Instantiate(prefab, new Vector3(0, Random.Range(5.0f, 25.0f), i), Quaternion.identity);
                    break;
                case "ALTA":
                    GameTime.Instance.time = 170;
                    Instantiate(prefab, new Vector3(0, Random.Range(5.0f, 40.0f), i), Quaternion.identity);
                    break;
                default:
                    GameTime.Instance.time = 170;
                    Instantiate(prefab, new Vector3(0, Random.Range(5.0f, 30.0f), i), Quaternion.identity);
                    break;
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        time = Time.realtimeSinceStartup - timeZero;

        float amplitudeFrameRight = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)[1] - lastValueRight;
        lastValueRight = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)[1];
        
        
        float amplitudeFrameLeft = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch)[1] - lastValueLeft;
        lastValueLeft = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch)[1];

        controlador.JumpForce = ((Mathf.Abs(amplitudeFrameRight) + Mathf.Abs(amplitudeFrameLeft))/4);
        //controlador.JumpForce = Mathf.Abs(amplitudeFrameRight);
        controlador.JumpModified();

        if (OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)[1] > highPos)
            highPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)[1];
        if (OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)[1] < lowPos)
            lowPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)[1];

        //desplazamiento hacia adelante
        Vector3 position = controlador.transform.position;
        position[2] -= ((Mathf.Abs(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LHand)[1])+ Mathf.Abs(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand)[1])) * 0.05f)/4.0f;
        controlador.transform.position = position;

        //fuerza hacia abajo
        float deltaTime = -0.0005f;
        //position = controlador.transform.position;
        controlador.JumpForce = deltaTime;
        controlador.JumpModified();

        /*switch (tipoVelocidad)
        {
            case "BAJA":
                if ((Time.realtimeSinceStartup - timeZero) > 200)
                {
                    File.WriteAllText(pathToWrite, "VUELO:" + points + " / Amplitud máxima: " + highPos + " // Amplitud mínima: " + lowPos + " // Tiempo: " + (Time.realtimeSinceStartup - timeZero).ToString());
                    //Application.Quit();
                    SceneManager.LoadScene("GameMenu");
                }
                textMesh.text = "Tiempo restante: " + (int)(200 - (Time.realtimeSinceStartup - timeZero)) + " Score : " + points;
                break;
            case "MEDIA":
                if ((Time.realtimeSinceStartup - timeZero) > 175)
                {
                    File.WriteAllText(pathToWrite, "VUELO:" + points + " / Amplitud máxima: " + highPos + " // Amplitud mínima: " + lowPos + " // Tiempo: " + (Time.realtimeSinceStartup - timeZero).ToString());
                    //Application.Quit();
                    SceneManager.LoadScene("GameMenu");
                }
                textMesh.text = "Tiempo restante: " + (int)(175 - (Time.realtimeSinceStartup - timeZero)) + " Score : " + points;
                break;
            case "ALTA":
                if ((Time.realtimeSinceStartup - timeZero) > 170)
                {
                    File.WriteAllText(pathToWrite, "VUELO:" + points + " / Amplitud máxima: " + highPos + " // Amplitud mínima: " + lowPos + " // Tiempo: " + (Time.realtimeSinceStartup - timeZero).ToString());
                    //Application.Quit();
                    SceneManager.LoadScene("GameMenu");
                }
                textMesh.text = "Tiempo restante: " + (int)(170 - (Time.realtimeSinceStartup - timeZero)) + " Score : " + points;
                break;
            default:
                if ((Time.realtimeSinceStartup - timeZero) > 170)
                {
                    File.WriteAllText(pathToWrite, "VUELO:" + points + " / Amplitud máxima: " + highPos + " // Amplitud mínima: " + lowPos + " // Tiempo: " + (Time.realtimeSinceStartup - timeZero).ToString());
                    //Application.Quit();
                    SceneManager.LoadScene("GameMenu");
                }
                textMesh.text = "Tiempo restante: " + (int)(170 - (Time.realtimeSinceStartup - timeZero)) + " Score : " + points;
                break;
        }*/
        //position[2] *= Mathf.Abs(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand)[1]) * -0.05f;
        //controlador.transform.position = position;
    }
}
