using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelGame : MonoBehaviour
{
    //private static PadelGame instance;
    //private float timeZero;
    //public float points;
    //[SerializeField]
    //private TextMesh textMesh;

    public float velInicial = 30f;
    public GameObject rHand, lHand;
    public Rigidbody rBody;
    Vector3 posInicial;

    bool jugando;


    //public static PadelGame GetInstance()
    //{
     //   return instance;
    //}

    // Start is called before the first frame update
    //void Start()
    //{
     //   posInicial = transform.position;
       // timeZero = Time.realtimeSinceStartup;
        //if (instance == null)
       // {
        //    instance = this;
        //}
    //}

    public void Reset()
    {
        transform.position = posInicial;
        jugando = false;
        DetenerMov();
    }

    public void DetenerMov()
    {
        rBody.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!jugando && rHand)
        {
            jugando = true;
            rBody.AddForce(new Vector3(velInicial, velInicial, velInicial));
        }

       // if ((Time.realtimeSinceStartup - timeZero) > 0)
        //{
         //   Application.Quit();
        //}
        //textMesh.text = "Time: " + (int)(60 - Time.realtimeSinceStartup - timeZero) + "Score: " + points;
    }

}
