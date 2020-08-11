using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAgility : MonoBehaviour
{
    private Vector3 direction, velocity;

    [SerializeField]
    float moveSpeed = 5.0f;

    private void Update()
    {
        direction = Player.Instance.gameObject.transform.position - transform.position;
        direction = direction.normalized;
        velocity = direction * moveSpeed * Time.deltaTime;
        transform.position += velocity;
    }



}
