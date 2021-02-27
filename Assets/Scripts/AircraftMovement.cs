using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handle player move
/// </summary>
/// 
public class AircraftMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30;
    [SerializeField][Range(0, 180)] private float angleMax = 90;
    [SerializeField][Range(0, 180)] private float tiltAngle = 15;

    float m_rotationY = 0;

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal");

        m_rotationY += rotation * rotationSpeed * Time.deltaTime;
        m_rotationY = Mathf.Clamp(m_rotationY, -angleMax, angleMax);
        transform.localRotation = Quaternion.Euler(0, m_rotationY, rotation * -tiltAngle);
    }
}
