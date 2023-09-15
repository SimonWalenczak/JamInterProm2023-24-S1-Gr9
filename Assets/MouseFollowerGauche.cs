using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowerGauche : MonoBehaviour
{
    public float offset2Y;
    public float offset2X;
    public float moveSpeed = 5f; // Vitesse de d�placement du sprite
    public float lerpSpeed = 5f; // Vitesse de l'interpolation lin�aire

    private Vector3 targetPosition; // La position vers laquelle le sprite doit se d�placer

    public Camera cam;
    void Update()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < 0)
        {
            targetPosition = new Vector3(mousePosition.x + offset2X, mousePosition.y + offset2Y, transform.position.z);
        }
        else
        {
            targetPosition = new Vector3(-4.12f, -6.28f, 0f);
        }

        // Utilisez Lerp pour d�placer le sprite vers la nouvelle position de mani�re fluide
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
