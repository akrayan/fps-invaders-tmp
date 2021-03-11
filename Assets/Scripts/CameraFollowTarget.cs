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

        //transform.position = CalculatePosition();
        //transform.rotation = CalculateRotation();
    }

    void LateUpdate()
    {
        //Quaternion playerRot = m_playerTransform.rotation;
        //Vector3 dir = Quaternion.Euler(m_pitch, playerRot.eulerAngles.y, 0) * Vector3.back;//Quaternion.AngleAxis(pitch, Vector3.right) * Vector3.back;
        /*
        transform.position = Vector3.Lerp(transform.position, m_playerTransform.position + (dir * m_distance), m_cameraSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, playerRot.eulerAngles.y, 0), m_rotationSpeed * Time.deltaTime);
    */
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
