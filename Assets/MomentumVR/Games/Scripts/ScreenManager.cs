using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : Singleton<ScreenManager>
{
    //public Text tittleTxt;
    public Text pointsTxt;

    [HideInInspector]
    public float points;
    void Start()
    {
        //tittleTxt.text = "Wind Game";
        points = 0;
    }
    private void Update()
    {
        pointsTxt.text = "Puntuación: " + points;
    }

}
