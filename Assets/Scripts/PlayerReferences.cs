/*
  Authors: Leith Merrifield
  Name: PlayerReferences.cs
  Description: Used as a general location to store important variables
  Date: 03/05/2020
  Modified: 4/05/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReferences : MonoBehaviour
{
    public Camera m_camera = null;
    public Rigidbody m_rb = null;
    public bool m_cursorLock = false;

    public Vector3 m_mouseOffset = Vector3.zero;
    private void Update()
    {
        UpdateCursorLock();
    }

    void UpdateCursorLock()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
            m_cursorLock = !m_cursorLock;

        if (m_cursorLock && Cursor.lockState != CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.Locked;
        else if (!m_cursorLock && Cursor.lockState != CursorLockMode.None)
            Cursor.lockState = CursorLockMode.None;
    }
}
