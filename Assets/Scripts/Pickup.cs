using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    float moveSpeed = 30;
    public UnityAction<Transform> onPickedUp;

    private Transform m_playerTransform;

    void Start()
    {
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_playerTransform);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onPickedUp?.Invoke(other.transform);
            Destroy(gameObject);
        }
    }
}
