using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float speed=100;

    private float l_border = -1200;
    private float r_border = 1200;


    void Start ()
    {
        int scl = Random.Range(3, 5);
        transform.localScale = new Vector3(scl, scl, 1);

        speed = Random.Range(50f, 150f);
    }

    void FixedUpdate ()
    {
        transform.localPosition += transform.right * speed * Time.deltaTime;

        if(transform.localPosition.x > r_border)
        {
            int scl = Random.Range(3, 5);
            transform.localScale = new Vector3(scl, scl, 1);

            transform.localPosition = new Vector3(l_border, Random.Range(85, 500),0);

        }
    }
}
