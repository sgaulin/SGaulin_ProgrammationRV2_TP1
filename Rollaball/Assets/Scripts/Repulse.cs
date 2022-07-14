using UnityEngine;

// Cette classe sert à ajouter une force sur le joueur lorsqu'il entre en collision avec la surface orange, pour le repousser.
public class Repulse : MonoBehaviour
{
    // Création d'une variable publique pour stocker la force avec laquelle repousser le joueur.
    public float repulseForce = 1000;

    // Cette methode vérifie si la colision s'est effectué avec le jouer,
    // et elle ajoute une force explosive selon la force donné, au point de collision avec le joueur.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.AddExplosionForce(repulseForce, collision.contacts[0].point, 1);
        }
    }
}
