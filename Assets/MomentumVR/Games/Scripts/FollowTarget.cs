using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Vector3 direction, velocity;
    Vector3 target;

    [SerializeField]
    float moveSpeed;
    private void Start()
    {
        target = Player.Instance.gameObject.transform.position + Random.insideUnitSphere;
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
