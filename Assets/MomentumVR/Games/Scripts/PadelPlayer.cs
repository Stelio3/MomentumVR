using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PadelPlayer : MonoBehaviour
{
    public Transform aimTarget;
    public Transform ball;
    float force = 18;
    private string fileName, myFilePath, pathToWrite;
    private string myForce;
    private string[] lineas;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fileName = "ejercicios.txt";
        myFilePath = "/sdcard/Download/" + fileName;
        pathToWrite = "/sdcard/Download/" + "resultados.txt";

        if (File.Exists(myFilePath))
        {
            lineas = File.ReadAllLines(myFilePath);
        }
        if (lineas != null)
        {
            foreach (string line in lineas)
            {
                string[] words = line.Split(':');

                if (words[0] == "PADEL")
                {
                    string[] parametros = words[1].Split('/');
                    myForce = parametros[1];
                }

                if (myForce == "BAJA")
                {
                    force -= 2;
                }
                else if (myForce == "ALTA")
                {
                    force += 2;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            audioSource.Play();
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 12, 0);

            ball.GetComponent<PadelBall>().hitter = "player";
            ball.GetComponent<PadelBall>().playing = true;
        }
    }
}

