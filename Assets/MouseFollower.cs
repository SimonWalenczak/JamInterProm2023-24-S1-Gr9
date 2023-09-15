using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public float offset2Y;
    public float offset2X;
    public float moveSpeed = 5f; // Vitesse de déplacement du sprite
    public float lerpSpeed = 5f; // Vitesse de l'interpolation linéaire

    private Vector3 targetPosition; // La position vers laquelle le sprite doit se déplacer

    public Camera cam;
    void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x > 0)
        {
            targetPosition = new Vector3(mousePosition.x + offset2X, mousePosition.y + offset2Y, transform.position.z);
        }
        else
        {
            targetPosition = new Vector3(3.85f, -6.26f, 0f);
        }

        // Utilisez Lerp pour déplacer le sprite vers la nouvelle position de manière fluide
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
