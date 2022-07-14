using UnityEngine;

// Cette classe sert � faire bouger la cam�ra pour suivre le joueur.
public class CameraController : MonoBehaviour
{
    // Creation d'un GameObject Public pour lui assigner le game object du joueur dans l'editeur.
    // Creation d'une variable pour stocker un vecteur d'offset pour placer la camera par rapport au joueur.
    public GameObject player;
    private Vector3 offset;

    // Cette fonction soustrait la position du joueur par rapport � la cam�ra et stock la distance dans une variable.
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // � chaque frame, cette fonction repositionne la camera sur le joueur et lui ajoute une distance d'offset pour le cadrer.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
