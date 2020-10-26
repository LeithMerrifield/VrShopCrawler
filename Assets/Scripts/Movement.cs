/*
  Authors: Leith Merrifield
  Name: PlayerMovement.cs
  Description: Handles vertical and horizontal input to change the players velocity
               Rotates the camera with the player
  Date: 03/05/2020
  Modified: 4/05/2020
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private PlayerReferences m_references = null;
    private GameObject m_gameObject = null;
    private Vector3 m_velocity = new Vector3();

    float m_moveSpeed = 100.0f;
    public float m_maxSpeed = 20.0f;

    private bool m_moving = false;

    // Start is called before the first frame update
    public PlayerMovement(PlayerReferences reference, float maxspeed)
    {
        m_references = reference;
        m_gameObject = m_references.gameObject;
        m_references.m_cursorLock = true;
        m_maxSpeed = maxspeed;
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        if (!m_references.m_cursorLock)
            return;
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        // checks if there is any move input
        if (h == 0 && v == 0)
            m_moving = false;
        else
            m_moving = true;

        var newSpeed = m_moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            m_references.m_rb.velocity += newSpeed * m_gameObject.transform.forward;
        if (Input.GetKey(KeyCode.S))
            m_references.m_rb.velocity += newSpeed * m_gameObject.transform.forward * -1;
        if (Input.GetKey(KeyCode.D))
            m_references.m_rb.velocity += newSpeed * m_gameObject.transform.right;
        if (Input.GetKey(KeyCode.A))
            m_references.m_rb.velocity += newSpeed * m_gameObject.transform.right * -1;

        // Stops all velocity if no move key is pressed
        if (!m_moving)
            m_references.m_rb.velocity = new Vector3(0f, m_references.m_rb.velocity.y, 0f);

        float tempY = m_references.m_rb.velocity.y;
        // if velocity is above max then clamp it
        if (m_references.m_rb.velocity.magnitude > m_maxSpeed)
        {
            m_references.m_rb.velocity = Vector3.ClampMagnitude(m_references.m_rb.velocity, m_maxSpeed);
        }
        m_references.m_rb.velocity = new Vector3(m_references.m_rb.velocity.x, tempY, m_references.m_rb.velocity.z);

        // rotates player to the direction of the camera
        m_gameObject.transform.eulerAngles = new Vector3(m_gameObject.transform.rotation.eulerAngles.x,
                                                         m_references.m_camera.transform.rotation.eulerAngles.y,
                                                         m_gameObject.transform.rotation.eulerAngles.z);
    }
}

