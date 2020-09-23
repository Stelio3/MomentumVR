using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simon : MonoBehaviour
{
    public Image targetImg;
    public Text points;
    private int pointers, a;
    public Sprite[] handsSprites;
    private static int currentTarget = 0;
    private List<Sprite> sequence;
    private void Start()
    {
        sequence = new List<Sprite>();
        SetNewPosition();
    }
    public void SetNewPosition()
    {
        a = Random.Range(0, handsSprites.Length);
        print(a);
        targetImg.sprite = handsSprites[a];
        sequence.Add(targetImg.sprite);
    }
    public void positionDetected(Sprite hand)
    {
        if (hand == handsSprites[currentTarget])
        {
            print("SIIII");
            pointers++;
            points.text = pointers.ToString();
            if (handsSprites[currentTarget + 1] != null)
            {
                currentTarget++;
                targetImg.sprite = handsSprites[currentTarget];
            }
            else
            {
                SetNewPosition();
                currentTarget = 0;
            }
        }else
        {
            print("FAILLLL");
            sequence.Clear();
            SetNewPosition();
            points.text = "0";

        }
    }
}
