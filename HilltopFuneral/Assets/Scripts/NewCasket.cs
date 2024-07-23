using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewCasket : MonoBehaviour
{
    public GameObject KinematicRB;

    public float RotateVelocityRoll;
    public float RotateVelocityPitch;

    public float RollLimitation;
    public float PitchLimitation;

    public float SmoothTime;

    private float m_inputRoll;
    private float m_inputPitch;

    private Vector3 m_targetlocalEulerAngles;

    private void Start()
    {
        m_targetlocalEulerAngles = transform.localEulerAngles;
    }

    private void Update()
    {
        m_inputRoll = Input.GetAxisRaw("Horizontal");
        m_inputPitch = -Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // change targetlocalEulerAngles
        if (!Mathf.Approximately(m_inputRoll, 0.0f))
        {
            float targetRoll = Mathf.Clamp(m_targetlocalEulerAngles.z + m_inputRoll * RotateVelocityRoll * Time.fixedDeltaTime, -RollLimitation, RollLimitation);
            m_targetlocalEulerAngles = new Vector3(m_targetlocalEulerAngles.x, m_targetlocalEulerAngles.y, targetRoll);
        }
        if (!Mathf.Approximately(m_inputPitch, 0.0f))
        {
            float targetPitch = Mathf.Clamp(m_targetlocalEulerAngles.x + m_inputPitch * RotateVelocityPitch * Time.fixedDeltaTime, -PitchLimitation, PitchLimitation);
            m_targetlocalEulerAngles = new Vector3(targetPitch, m_targetlocalEulerAngles.y, m_targetlocalEulerAngles.z);
        }
        // rotating
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(m_targetlocalEulerAngles), SmoothTime);

        // sync KinematicRB
        KinematicRB.GetComponent<Rigidbody>().MovePosition(transform.position);
        KinematicRB.GetComponent<Rigidbody>().MoveRotation(transform.rotation);
    }

    public void SetlocalEulerAngles(Vector3 targetlocalEulerAngles)
    {
        m_targetlocalEulerAngles = targetlocalEulerAngles;
    }

}
