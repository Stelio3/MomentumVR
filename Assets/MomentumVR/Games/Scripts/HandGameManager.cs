using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class HandGameManager : MonoBehaviour
{

    [SerializeField]
    private TextMesh textMeshGestureToDo;
    [SerializeField]
    private TextMesh textMeshTime;
    [SerializeField]
    private TextMesh currentGesture;
    [SerializeField]
    private TextMesh nivelTextMesh;
    public GameObject balon;
    public GameObject salvaVidas;
    private string[] names;
    private float time;
    private float initialTime = 20.0f;
    private float number;
    private int nivel;
    string pathToWrite = "/sdcard/Download/" + "resultados.txt";

    // Start is called before the first frame update
    void Start()
    {
        nivel = 0;
        time = 60;
        names = new string[] { "Abierta2", "PunoArriba" };
        randomGesture();
    }

    void randomGesture()
    {
        number = UnityEngine.Random.Range(0, 100);

        if (number > 50)
        {
            textMeshGestureToDo.text = names[0];
            salvaVidas.SetActive(true);
        }
        else
        {
            textMeshGestureToDo.text = names[1];
            balon.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {       
        nivelTextMesh.text = nivel.ToString();

        if (time > 0)
        {
            time = time - 1 * Time.deltaTime;
            int timeInt = (int)time;
            //time = timeZero - Time.deltaTime;
            textMeshTime.text = timeInt.ToString();
        }
        
        
        if (time > 0 && currentGesture.text.Equals(textMeshGestureToDo.text))
        {
            StartCoroutine(nextLevelCoroutine());
        }

        if (time <=0)
        {
            using (StreamWriter sw = File.AppendText(pathToWrite))
            {
                sw.WriteLine("\nHANDTRACKING:" + System.DateTime.Now.ToString("yyyy-MM-dd  -> ") + nivel);
            }
            SceneManager.LoadScene("GameMenu");
        }

    }

    IEnumerator nextLevelCoroutine()
    {
        initialTime /= 1.1f;
        time = initialTime;

        if (textMeshGestureToDo.text.Equals(names[0]))
        {
            salvaVidas.SetActive(false);
            balon.SetActive(true);
            textMeshGestureToDo.text = names[1];
        }
        else
        {
            balon.SetActive(false);
            salvaVidas.SetActive(true);
            textMeshGestureToDo.text = names[0];
        }

        nivel += 1;
        yield return new WaitForSeconds(5);
    }

}
