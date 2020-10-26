using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private PlayerReferences m_reference = null;

    [Header("Speed Related")]
    //public float m_speed = 0f;
    public float m_speedMax = 0f;
    private PlayerMovement m_movementScript = null;


    private void Awake()
    {
        m_reference = GetComponent<PlayerReferences>();
        m_movementScript = new PlayerMovement(m_reference, m_speedMax);
    }

    private void Update()
    {
        m_movementScript.OnUpdate();
    }
}
