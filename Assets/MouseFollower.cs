using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public float offsetY;
    public float offsetX;
    public float moveSpeed = 5f; // Vitesse de déplacement du sprite

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Si la souris est à droite de l'écran, déplacez le sprite de droite
        if (mousePosition.x > 0)
        {
            transform.position = new Vector3(mousePosition.x + offsetX, mousePosition.y + offsetY, transform.position.z);
            // Déplacez le sprite vers la droite

        }
        else { 
            transform.position = new Vector3(5.3f, -2.6f, 0f); // Crée un vecteur 3D avec des valeurs x=1.0, y=2.0 et z=3.0

        }
        // Obtenez la position actuelle de la souris dans l'espace de jeu


        // Définissez la position de votre sprite sur la position de la souris

    }
}
