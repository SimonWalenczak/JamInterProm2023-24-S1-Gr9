using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Arm : MonoBehaviour
{
    public Camera cam;

    public float offsetX;
    public float offsetY;
    public float lerpSpeed = 10f;

    private Vector3 _targetPosition;

    [Space(10)] [SerializeField] private bool LeftArm;
    [SerializeField] private Vector3 _leftOrigin;
    [SerializeField] private Vector3 _rightOrigin;

    public bool IsActualArm;

    public Arm otherArm;
    
    private void Start()
    {
        if (!LeftArm)
        {
            offsetX = -offsetX;
            IsActualArm = true;
            _leftOrigin.x = Screen.width * 0.3f;
        }
        else
        {
            _rightOrigin.x = Screen.width * 0.7f;
        }
        
    }

    void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (LeftArm)
        {
            if (IsActualArm && Input.mousePosition.x < Screen.width * 0.75f)
            {
                _targetPosition = new Vector3(mousePosition.x + offsetX, mousePosition.y + offsetY,
                    transform.position.z);
            }
            else
            {
                _targetPosition = _leftOrigin;
                IsActualArm = false;
                otherArm.IsActualArm = true;
            }
        }
        else
        {
            if (IsActualArm && Input.mousePosition.x > Screen.width * 0.25f)
            {
                _targetPosition = new Vector3(mousePosition.x + offsetX, mousePosition.y + offsetY,
                    transform.position.z);
            }
            else
            {
                _targetPosition = _rightOrigin;
                IsActualArm = false;
                otherArm.IsActualArm = true;
            }
        }

        transform.position = Vector3.Lerp(transform.position, _targetPosition, lerpSpeed * Time.deltaTime);
    }
}