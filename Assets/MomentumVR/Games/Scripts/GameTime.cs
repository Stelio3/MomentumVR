using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameTime : MonoBehaviour
{
    public float time;
    public string game;
    public string prevText;
    public Text points;
    string pathToWrite = "/sdcard/Download/" + "resultados.txt";

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        int timeCorrect = (int)time;
        if (time > 0)
        {
            GetComponent<Text>().text = prevText + timeCorrect.ToString().PadLeft(2, '0');
        }
        else
        {
            time = 0;
            GetComponent<Text>().text = prevText + timeCorrect.ToString().PadLeft(2, '0');
            using (StreamWriter sw = File.AppendText(pathToWrite))
            {
                sw.WriteLine("\n" + game + System.DateTime.Now.ToString("yyyy-MM-dd  -> ") + points.text);
            }
            SceneManager.LoadScene("GameMenu");
        }
    }
}
