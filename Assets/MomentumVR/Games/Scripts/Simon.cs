using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simon : MonoBehaviour
{
    public Image targetImg;
    public Text points;
    private int pointers;
    private Sprite lastSprite;
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
        lastSprite = targetImg.sprite;
        targetImg.sprite = handsSprites[Random.Range(0, handsSprites.Length)];
        while(lastSprite == targetImg.sprite)
        {
            targetImg.sprite = handsSprites[Random.Range(0, handsSprites.Length)];
        }
        sequence.Add(targetImg.sprite);
    }
    public void positionDetected(Sprite hand)
    {
        Debug.Log(sequence.Count);
        if (hand == targetImg.sprite)
        {
            pointers++;
            points.text = "Puntuación: " + pointers.ToString();
            if (currentTarget != sequence.Count-1)
            {
                targetImg.sprite = sequence[currentTarget];
                currentTarget++;
            }
            else
            {
                currentTarget = 0;
                SetNewPosition();
            }
        }else
        {
            points.text = "Fallo";
            sequence.Clear();
            currentTarget = 0;
            SetNewPosition();

        }
    }
}
