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
    [SerializeField, Range(0, 1)] private float _limit;

    public bool IsActualArm;

    public Arm otherArm;

    [SerializeField] private float LimitY;

    private float actualMousePosY;

    private void Start()
    {
        if (!LeftArm)
        {
            offsetX = -offsetX;
            _leftOrigin.x = Screen.width * 0.3f;
        }
        else
        {
            IsActualArm = true;
            _rightOrigin.x = Screen.width * 0.7f;
        }
    }

    void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.y > 2.5f)
        {
            actualMousePosY = 2.5f;
        }
        else
        {
            actualMousePosY = mousePosition.y;
        }

        //if (LeftArm)
        //{
        //    if (IsActualArm)
        //    {
        //        if (Input.mousePosition.x <= Screen.width * _limit)
        //        {
        //            _targetPosition = new Vector3(mousePosition.x + offsetX, actualMousePosY + offsetY,
        //                transform.position.z);
        //        }
        //        else
        //        {
        //            IsActualArm = false;
        //            otherArm.IsActualArm = true;
        //        }
        //    }
        //    else
        //    {
        //        if (Input.mousePosition.x < Screen.width * 0.01f)
        //        {
        //            _targetPosition = new Vector3(mousePosition.x + offsetX, actualMousePosY + offsetY,
        //                transform.position.z);
        //        }
        //        else
        //        {
        //            _targetPosition = _leftOrigin;
        //        }
        //    }
        //}
        //else
        //{
        //    if (IsActualArm)
        //    {
        //        if (Input.mousePosition.x >= Screen.width * (1- _limit))
        //        {
        //            _targetPosition = new Vector3(mousePosition.x + offsetX, actualMousePosY + offsetY,
        //                transform.position.z);
        //        }
        //        else
        //        {
        //            IsActualArm = false;
        //            otherArm.IsActualArm = true;
        //        }
        //    }
        //    else
        //    {
        //        if (Input.mousePosition.x > Screen.width * 1)
        //        {
        //            _targetPosition = new Vector3(mousePosition.x + offsetX, actualMousePosY + offsetY,
        //                transform.position.z);
        //        }
        //        else
        //        {
        //            _targetPosition = _rightOrigin;
        //        }
        //    }
        //}

        _targetPosition = new Vector3(mousePosition.x + offsetX, actualMousePosY + offsetY,
                    transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _targetPosition, lerpSpeed * Time.deltaTime);
    }
}