using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBoundaries : MonoBehaviour
{
    [SerializeField] private Color EditorColor = new Color(0, 160, 255, 120);
    [SerializeField] float m_minX = -40;
    [SerializeField] float m_maxX = 40;
    [SerializeField] float m_minZ = 0;
    [SerializeField] float m_maxZ = 150;

    public float minX { get{ return m_minX; } }
    public float maxX { get{ return m_maxX; } }
    public float minZ { get{ return m_minZ; } }
    public float maxZ { get{ return m_maxZ; } }

    static AreaBoundaries m_instance = null;
    public static AreaBoundaries Instance { get { return m_instance; } }

    public Vector3 GetCenter()
    {
        return new Vector3(m_minX + ((m_maxX - m_minX) / 2), 0, m_minZ);
    }

    public float GetWidth()
    {
        return m_maxX - m_minX;
    }

    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;
        else
            Destroy(this);
    }

    private void OnDrawGizmos()
    {
        Vector3 center = new Vector3((maxX + minX) / 2, 0, (maxZ + minZ) / 2);
        Vector3 size = new Vector3(maxX - minX, 1, maxZ - minZ);
        Gizmos.color = EditorColor;
        Gizmos.DrawCube(center, size);
    }
}
