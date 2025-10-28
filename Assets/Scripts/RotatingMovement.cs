using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private Transform rotateAround;

    private bool autoRotate = false;




    private void Update()
    {
        if (autoRotate)
        {
            transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}






