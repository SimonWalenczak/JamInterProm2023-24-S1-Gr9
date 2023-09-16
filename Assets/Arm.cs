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

    [Space(10)]
    [SerializeField] private bool LeftArm;
    [SerializeField] private Vector3 _leftOrigin;
    [SerializeField] private Vector3 _rightOrigin;

    private void Start()
    {
        if (!LeftArm)
        {
            offsetX = -offsetX;
        }
    }

    void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (LeftArm)
        {
            _targetPosition = mousePosition.x < 0
                ? new Vector3(mousePosition.x + offsetX, mousePosition.y + offsetY,
                    transform.position.z)
                : _leftOrigin;
        }
        else
        {
            _targetPosition = mousePosition.x > 0
                ? new Vector3(mousePosition.x + offsetX, mousePosition.y + offsetY, transform.position.z)
                : _rightOrigin;
        }

        transform.position = Vector3.Lerp(transform.position, _targetPosition, lerpSpeed * Time.deltaTime);
    }
}