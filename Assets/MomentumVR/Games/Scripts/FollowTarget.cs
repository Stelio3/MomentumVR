using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FollowTarget : MonoBehaviour
{
    private Vector3 direction, velocity;
    Vector3 target;
    public static FollowTarget instance = null;
    private string fileName, myFilePath, pathToWrite;
    private string amplitud, speed;
    private float range = 0;
    private string[] lineas;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    float moveSpeed;
    private void Start()
    {
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

                if (words[0] == "VIENTO")
                {
                    string[] parametros = words[1].Split('/');
                    speed = parametros[1];
                    amplitud = parametros[2];
                }

                if (speed == "BAJA")
                {
                    moveSpeed -= 1;
                }
                else if (speed == "ALTA")
                {
                    moveSpeed += 1;
                }
                if (amplitud == "BAJA")
                {
                    range = -0.5f;
                }
                else if (amplitud == "ALTA")
                {
                    range = 0.5f;
                }
            }
        }
        target = Player.Instance.gameObject.transform.position + Random.insideUnitSphere * range;
        target += new Vector3(0, 0.75f, -10f);
        transform.LookAt(Player.Instance.gameObject.transform);
    }

    private void Update()
    {
        direction = target - transform.position;
        direction = direction.normalized;
        velocity = direction * moveSpeed * Time.deltaTime;
        transform.position += velocity;
        if(transform.position.z < Player.Instance.gameObject.transform.position.z)
        {
            Destroy(gameObject, 2f);
        }
    }



}
