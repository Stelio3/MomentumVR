using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Vector3 direction, velocity;

    Vector3 target;

    [SerializeField]
    float moveSpeed = 5.0f;
    private void Start()
    {
        target = Player.Instance.gameObject.transform.position + Random.insideUnitSphere * 0.75f;
        target.y += 0.75f;
        transform.LookAt(Player.Instance.gameObject.transform);
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        direction = target - transform.position;
        direction = direction.normalized;
        velocity = direction * moveSpeed * Time.deltaTime;
        transform.position += velocity;
    }



}
