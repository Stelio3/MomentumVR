using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public float time;
    private bool timeEnd = true;
    public string prevText;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        int timeCorrect = (int)time;
        if (timeCorrect > 0)
        {
            GetComponent<Text>().text = prevText + timeCorrect.ToString().PadLeft(2, '0');
        }
        else if (timeEnd)
        {
            timeEnd = false;
            time = 0;
            GetComponent<Text>().text = prevText + timeCorrect.ToString().PadLeft(2, '0');
        }
    }
}
