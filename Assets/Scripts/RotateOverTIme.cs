using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTIme : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
