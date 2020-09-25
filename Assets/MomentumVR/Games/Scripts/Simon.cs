using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simon : MonoBehaviour
{
    public GameObject gestureDetection;
    public Image targetImg;
    public Text points, info, point;
    private int pointers;
    private Sprite newSprite;
    public Sprite[] handsSprites;
    private static int currentTarget = 0;
    private List<Sprite> sequence;
    private AudioSource audioSource;
    public AudioClip[] audioClips;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        points.text = "Cierra el puño para resetear movimientos";
        sequence = new List<Sprite>();
        newSprite = targetImg.sprite;
        SetNewPosition();
    }
    public void SetNewPosition()
    {
        newSprite = handsSprites[Random.Range(0, handsSprites.Length)];
        sequence.Add(newSprite);
        StartCoroutine(ToRepeat());
    }
    public void positionDetected(Sprite hand)
    {
        if (hand == sequence[currentTarget])
        {
            audioSource.clip = audioClips[0];
            if (currentTarget != sequence.Count-1)
            {
                info.text = "Bien!";
                currentTarget++;
            }
            else
            {
                info.text = "Perfecto!";
                currentTarget = 0;
                pointers += sequence.Count;
                point.text = "Puntuacion: " + pointers.ToString();
                SetNewPosition();
            }
        }else
        {
            audioSource.clip = audioClips[1];
            info.text = "Fallo";
            sequence.Clear();
            currentTarget = 0;
            SetNewPosition();

        }
        audioSource.Play();
    }
    IEnumerator ToRepeat()
    {
        points.text = "A repetir...";
        gestureDetection.SetActive(false);
        targetImg.gameObject.SetActive(true);
        for (int i = 0; i < sequence.Count; i++)
        {
            targetImg.sprite = sequence[i];
            yield return new WaitForSeconds(1f);
        }
        points.text = "Te toca!";
        gestureDetection.SetActive(true);
        targetImg.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        points.text = "Secuencia: " + currentTarget + " de " + sequence.Count;
    }
}
