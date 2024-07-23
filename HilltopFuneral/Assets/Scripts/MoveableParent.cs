using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableParent : MonoBehaviour
{
    public float MoveSpeed;
    public float TurnSpeed;

    public Animator AnimatorPlayer1;
    public Animator AnimatorPlayer2;

    private float m_inputX;
    private float m_inputY;
    private Rigidbody m_rigidbody;
    private Vector3 m_moveAmount;
    private Vector3 m_smoothMoveVelocity;
    private Quaternion m_targetRotation;

    private bool m_isMoving;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        m_inputX = Input.GetAxisRaw("Horizontal2");
        m_inputY = Input.GetAxisRaw("Vertical2");

        if (m_isMoving)
        {
            AnimatorPlayer1.enabled = true;
            AnimatorPlayer2.enabled = true;
        }
        else
        {
            AnimatorPlayer1.enabled = false;
            AnimatorPlayer2.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        bool isMoving = false;
        // move Forward and backward
        if (!Mathf.Approximately(m_inputY, 0.0f) || m_moveAmount != Vector3.zero)
        {
            Vector3 targetMoveAmount;
            if (Mathf.Approximately(m_inputY, 0.0f)) targetMoveAmount = Vector3.zero;
            else
            {
                Vector3 moveDir = new Vector3(m_inputY, 0, 0).normalized;
                targetMoveAmount = moveDir * MoveSpeed;
            }
            m_moveAmount = Vector3.SmoothDamp(m_moveAmount, targetMoveAmount, ref m_smoothMoveVelocity, .3f);
            Vector3 localMove = transform.TransformDirection(m_moveAmount) * Time.fixedDeltaTime;
            m_rigidbody.MovePosition(GetComponent<Rigidbody>().position + localMove);
            if (m_moveAmount.magnitude > MoveSpeed * 0.2f) isMoving = true;
        }

        // turn
        if (!Mathf.Approximately(m_inputX, 0.0f) || m_rigidbody.rotation != m_targetRotation)
        {
            m_targetRotation = Quaternion.Euler(0, m_rigidbody.rotation.eulerAngles.y + m_inputX * TurnSpeed * Time.fixedDeltaTime, m_rigidbody.rotation.eulerAngles.z);
            m_rigidbody.MoveRotation(m_targetRotation);
            isMoving = true;
        }

        // keep upright
        if (!Mathf.Approximately(transform.eulerAngles.x, 0.0f))
        {
            Quaternion tagetRotation = Quaternion.Euler(0, m_rigidbody.rotation.eulerAngles.y, m_rigidbody.rotation.eulerAngles.z);
            m_rigidbody.MoveRotation(tagetRotation);
        }

        m_isMoving = isMoving;
    }
}
