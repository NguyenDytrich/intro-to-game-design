using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float UnitsPerSecond = 1.0f;
    public GameObject Head;

    public GameObject SegmentPrefab;
    public List<GameObject> Segments;

    private float LastMoveTime = 0.0f;
    private Vector3 Direction = Vector3.up;


    // Start is called before the first frame update
    void Start()
    {
        Segments.Add(Head);
        for (int i = 0; i < 5; i++)
        {
            GameObject segment = Instantiate(SegmentPrefab);
            Segments.Add(segment);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Direction = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Direction = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Direction = Vector3.right;
        }

        float time = Time.time;
        if (time - LastMoveTime >= (1.0f / UnitsPerSecond))
        {

            // Move all the other segments!
            for (int i = Segments.Count - 1; i > 0; i--)
            {
                Segments[i].transform.position = new Vector3(
                    Segments[i - 1].transform.position.x,
                    Segments[i - 1].transform.position.y,
                    Segments[i - 1].transform.position.z
                );
            }

            Head.transform.position += Direction;
            LastMoveTime = time;
        }
    }
}
