using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Ball;

    // Update is called once per frame
    void Update()
    {

        if (Ball.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
        }


        if (Ball.transform.position.y < transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z);
        }
    }
}
