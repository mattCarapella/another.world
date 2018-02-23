using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 angle;

    void Update()
    {
        transform.Rotate(angle * Time.deltaTime);
    }
}