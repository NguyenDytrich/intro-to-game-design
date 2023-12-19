using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float UnitsPerSecond = 1.0f;
    public GameObject Head;

    private float LastMoveTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        if (time - LastMoveTime >= (1.0f / UnitsPerSecond))
        {
            Head.transform.position += Vector3.up;
            LastMoveTime = time;
        }
    }
}
