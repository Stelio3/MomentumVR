using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class HandGameManager : MonoBehaviour
{

    [SerializeField]
    private TextMesh textMeshGestureToDo;
    [SerializeField]
    private TextMesh textMeshTime;
    [SerializeField]
    private Text currentGesture;
    [SerializeField]
    private TextMesh nivelTextMesh;
    public GameObject balon;
    public GameObject salvaVidas;
    private string[] names;
    private float time;
    private float initialTime = 40.0f;
    private float number;
    private int nivel;
    private int nextUpdate = 2;
    string pathToWrite = "/sdcard/Download/" + "resultados.txt";

    // Start is called before the first frame update
    void Start()
    {
        nivel = 0;
        time = initialTime;
        names = new string[] { "Abierta2", "PunoAbajo" };
        RandomGesture();
    }

    void RandomGesture()
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

        if (Time.time >= nextUpdate)
        {
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 2;
            // Call your fonction
            if(textMeshGestureToDo.text.Equals("-"))
                UpdateEveryXSecond();
        }

        if (time > 0 && currentGesture.text.Equals(textMeshGestureToDo.text))
        {
            NextLevel();
            //StartCoroutine(nextLevelCoroutine());
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

    void UpdateEveryXSecond()
    {       
        RandomGesture();
        nivel += 1;
        initialTime -= 1f;
        time = initialTime;
    }

    void NextLevel()
    {
        if (textMeshGestureToDo.text.Equals(names[0]))
        {
            salvaVidas.SetActive(false);
            balon.SetActive(false);
            textMeshGestureToDo.text = "-";
            currentGesture.text = "--";

        }
        else
        {
            balon.SetActive(false);
            salvaVidas.SetActive(false);
            textMeshGestureToDo.text = "-";
            currentGesture.text = "--";
        }
    }

    IEnumerator nextLevelCoroutine()
    {       

        if (textMeshGestureToDo.text.Equals(names[0]))
        {
            salvaVidas.SetActive(false);
            balon.SetActive(false);
            textMeshGestureToDo.text = "-";
            currentGesture.text = "-";
            
        }
        else
        {
            balon.SetActive(false);
            salvaVidas.SetActive(false);
            textMeshGestureToDo.text = "-";
            currentGesture.text = "-";
        }

        yield return new WaitForSeconds(5);
    }

}
