using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moto : Singleton<Moto>
{
    private AudioSource audioSource;
    private float leftRotation, rightRotation;
    public Text velocity;
    public static bool leftGrab, rightGrab;
    public GameObject leftHand, rightHand;
    [SerializeField]
    float moveSpeed;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            audioSource.Play();
            StartCoroutine(ActiveCoin(other.gameObject));
            ScreenManager.Instance.points += 1;
            GameTime.Instance.time += 2;
        }
    }
    IEnumerator ActiveCoin(GameObject go)
    {
        go.SetActive(false);
        yield return new WaitForSeconds(3f);
        go.SetActive(true);
    }
    void Update()
    {
        if (leftGrab)
        {
            leftRotation = -leftHand.transform.localRotation.x;
        }
        else
        {
            leftRotation = 0;
        }
        if (rightGrab)
        {
            rightRotation = -rightHand.transform.localRotation.x;
        }
        else
        {
            rightRotation = 0;
        }
        if (rightGrab || leftGrab)
        {
            if (rightGrab && !leftGrab)
            {
                transform.Rotate(0, 30f * Time.deltaTime, 0, Space.Self);
            }
            else if (!rightGrab && leftGrab)
            {
                transform.Rotate(0, -30f * Time.deltaTime, 0, Space.Self);
            }

            if(moveSpeed < 15)
            {
                moveSpeed += leftRotation * 0.3f + rightRotation * 0.3f;
            }else if (moveSpeed < 30)
            {
                moveSpeed += leftRotation * 0.1f + rightRotation * 0.1f;
            }else if (moveSpeed < 40)
            {
                moveSpeed += leftRotation * -0.1f + rightRotation * -0.1f;
            }
            else
            {
                moveSpeed = 40;
            }

            velocity.text = (int)moveSpeed + "km/h";

            transform.localPosition += -transform.right * moveSpeed * Time.deltaTime;
        }
        else if(moveSpeed > 0)
        {
            moveSpeed -= Time.deltaTime * 0.1f;
        }
    }
    public void Grab(GameObject go, bool value)
    {
        if (go.tag == "Right")
        {
            rightGrab = value;
        }
        else if (go.tag == "Left")
        {
            leftGrab = value;
        }
    }
}
