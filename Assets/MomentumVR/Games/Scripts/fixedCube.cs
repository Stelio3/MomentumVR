using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixedCube : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Player.Instance.gameObject.transform.position.y/2, transform.position.z);
    }
}
