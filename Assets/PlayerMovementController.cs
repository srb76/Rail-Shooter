using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementController : MonoBehaviour
{
    float xThrow, yThrow;
    float xOffset, yOffset;
    float rawX, rawY;

    [Tooltip("In m/s")][SerializeField] float xSpeed = 20f;
    [SerializeField] float xRange = 20f;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 20f;
    [SerializeField] float yRange = 12f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 2.2f;
    [SerializeField] float controlRollFactor = -20f;

    bool controlEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        float pitch, yaw, roll;

        //couple pitch to position on screen AND control throw
        float pitchPosition = transform.localPosition.y * positionPitchFactor; //couple y POSITION to pitch
        float pitchControl = yThrow * controlPitchFactor;
        pitch = pitchPosition + pitchControl;

        //couple yaw to position on screen
        yaw = transform.localPosition.x * positionYawFactor;

        //couple roll to control throw
        roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        xOffset = xThrow * xSpeed * Time.deltaTime;
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        yOffset = yThrow * ySpeed * Time.deltaTime;

        //find new x position
        rawX = transform.localPosition.x + xOffset;
        rawX = Mathf.Clamp(rawX, -xRange, xRange);

        rawY = transform.localPosition.y + yOffset;
        rawY = Mathf.Clamp(rawY, -yRange, yRange);

        transform.localPosition = new Vector3(rawX, rawY, transform.localPosition.z);
    }

    private void Death()
    {
        print("Controls disabled.");
        controlEnabled = false;
    }
}
