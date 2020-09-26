using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixedPosition : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.Instance.gameObject.transform.position.z+10f);
    }
}
