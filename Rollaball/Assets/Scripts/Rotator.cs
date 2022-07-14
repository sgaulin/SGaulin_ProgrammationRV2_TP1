using UnityEngine;

// Cette classe sert a animer le pickup object.
public class Rotator : MonoBehaviour
{ 
    // A chaque frame, cette fonction fait tourner l'objet sur lui meme a partir d'un vecteur en fonction du temps.
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
