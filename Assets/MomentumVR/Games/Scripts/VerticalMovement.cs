using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalMovement : MonoBehaviour
{

    [SerializeField]
    private OVRPlayerController controlador;
    private string pathToWrite;

    [SerializeField] Text timeGame;
    [SerializeField] Text timeGame2;
    private float time;
    private float highPos, lowPos;
    private float lastValueRight, lastValueLeft;
    public float period = 0.05f;
    private string fileName, myFilePath, tipoAmplitud, tipoVelocidad, respuesta;
    private string[] lineas;
    private float timeZero;
    public bool subiendo;
    public bool bajando;
    public bool touchingRope;
    private static VerticalMovement instance;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.realtimeSinceStartup;
        timeZero = Time.realtimeSinceStartup;
        bajando = false;
        subiendo = true;
        touchingRope = false;
    }

    public static VerticalMovement GetInstance()
    {
        return instance;
    }
    // Update is called once per frame
    void Update()
    {
        time = Time.realtimeSinceStartup - timeZero;
        timeGame.text = "Tiempo: " + time;
        timeGame2.text = "Tiempo: " + time;

        float amplitudeFrameRight = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)[1] - lastValueRight;
        lastValueRight = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)[1];


        float amplitudeFrameLeft = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch)[1] - lastValueLeft;
        lastValueLeft = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch)[1];

        //controlador.JumpForce = ((Mathf.Abs(amplitudeFrameRight) + Mathf.Abs(amplitudeFrameLeft)) / 4);

        if (subiendo)
        {
            
            if (amplitudeFrameLeft < 0 && amplitudeFrameRight < 0)
            {
                controlador.JumpForce = ((Mathf.Abs(amplitudeFrameRight) + Mathf.Abs(amplitudeFrameLeft)) / 4);
            }
            else if (amplitudeFrameRight < 0 && amplitudeFrameLeft > 0)
            {
                controlador.JumpForce = (Mathf.Abs(amplitudeFrameRight) / 4);
            }
            else if(amplitudeFrameRight>0 && amplitudeFrameLeft <0)
            {
                controlador.JumpForce = Mathf.Abs(amplitudeFrameLeft / 4);
            }
            else
            {
                controlador.JumpForce = 0.0f;
            }
        }

        
        if (bajando)
        {
            if (amplitudeFrameLeft > 0 && amplitudeFrameRight > 0)
            {
                controlador.JumpForce = -((Mathf.Abs(amplitudeFrameRight) + Mathf.Abs(amplitudeFrameLeft)) / 4);
            }
            else if (amplitudeFrameRight > 0 && amplitudeFrameLeft < 0)
            {
                controlador.JumpForce = -(Mathf.Abs(amplitudeFrameRight) / 4);
            }
            else if (amplitudeFrameRight < 0 && amplitudeFrameLeft > 0)
            {
                controlador.JumpForce = -Mathf.Abs(amplitudeFrameLeft / 4);
            }
            else
            {
                controlador.JumpForce = 0.0f;
            }
            controlador.JumpForce = controlador.JumpForce * 0.01f;
        }
        //controlador.JumpForce = Mathf.Abs(amplitudeFrameRight);
        
        controlador.JumpModified();
        touchingRope = false;
    }
}
