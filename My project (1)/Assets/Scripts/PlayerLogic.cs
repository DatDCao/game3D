using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    CharacterController m_charecterController;

    float m_movementSpeed = 5f;

    float m_horizontalInput, m_VerticalInput;

    Vector3 m_movement;
    Vector3 m_movementInput;

    float m_jumpHeight = 0.5f;
    float m_gravity = 0.2f;
    bool m_jump = false;
    // Start is called before the first frame update
    void Start()
    {
        m_charecterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_VerticalInput = Input.GetAxis("Vertical");

        m_movementInput = new Vector3(m_horizontalInput, 0, m_VerticalInput);

        if (!m_jump && Input.GetButton("Jump"))
        {
            m_jump = true;
        }
        //Debug.Log("horizontal"+ m_horizontalInput);
        //Debug.Log("vetical" + m_VerticalInput);
    }

    void RotateChacracterTowardMouseCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePos - playerPos;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }

    private void FixedUpdate()
    {
        m_movement = m_movementInput * m_movementSpeed * Time.deltaTime;

        RotateChacracterTowardMouseCursor();

        if(m_movementInput != Vector3.zero)
        {
            transform.forward = Quaternion.Euler(0, -90, 0) * m_movement.normalized;
        }

        // Apply gravity
        if (!m_charecterController.isGrounded)
        {
            if (m_movement.y > 0)
            {
                m_movement.y -= m_gravity;
            }
            else
            {
                m_movement.y -= m_gravity;
            }
        }
        else
        {
            m_movement.y = 0;
        }
        // Setting jumphight to movement y 
        if (m_jump)
        {
            m_movement.y = m_jumpHeight;
            m_jump = false;
        }
        if (m_charecterController)
        {
            m_charecterController.Move(m_movement);
        }
    }
}
