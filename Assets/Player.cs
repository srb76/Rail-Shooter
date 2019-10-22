using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    float xThrow, yThrow;
    float xOffset, yOffset;
    float rawX, rawY;

    [Tooltip("In m/s")][SerializeField] float xSpeed = 25f;
    [SerializeField] float xRange = 15f;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 25f;
    [SerializeField] float yRange = 8f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Player collided with something!");
    }

    void OnTriggerEnter(Collider other)
    {
        print("Player triggered something!");
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
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
}
