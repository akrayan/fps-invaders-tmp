using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    private Transform m_playerTransform;
    [SerializeField] private float m_pitch = 30;
    [SerializeField] private float m_distance = 20;
    [SerializeField] private float m_cameraSpeed = 1;
    [SerializeField] private float m_rotationSpeed = 2;

    private void Start()
    {
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, CalculatePosition(), m_cameraSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, CalculateRotation(), m_rotationSpeed * Time.deltaTime);
    }

    Vector3 CalculatePosition()
    {
        Vector3 dir = Quaternion.Euler(m_pitch, m_playerTransform.rotation.eulerAngles.y, 0) * Vector3.back;

        return m_playerTransform.position + (dir * m_distance);
    }

    Quaternion CalculateRotation()
    {
        return Quaternion.Euler(0, m_playerTransform.rotation.eulerAngles.y, 0);
    }
}
