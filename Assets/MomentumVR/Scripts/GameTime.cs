using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {

    public float time;
    private bool timeEnd = true;

    // Update is called once per frame
    void Update () {
        time -= Time.deltaTime;

        int timeCorrect= (int)time;
        if (timeCorrect > 0)
        {
            GetComponent<Text>().text = "Time to start: " + timeCorrect.ToString().PadLeft(2, '0');
        }
        else if(timeEnd)
        {
            timeEnd = false;
            time = 0;
            GetComponent<Text>().text = "Time to start: " + timeCorrect.ToString().PadLeft(2, '0');
            GameManager.Instance.GameStart();
        }
    }
}
