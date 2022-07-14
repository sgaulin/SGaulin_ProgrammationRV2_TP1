using UnityEngine;

// Cette classe sert � ouvrir le plancher pour faire tomber les murs, le joueur
// et ajouter une instance de la plateforme de jeu sour le joeur
// losque ce dernier entre en collsion avec une surface rouge
public class Opener : MonoBehaviour
{
    // Cr�ation d'une liste de GameObjet pour stocker les objets ayant le tag Wall
    // Cr�ation d'une variable pour stocker le Rigidbody du joueur
    // Cr�ation d'un GameObjet public pour assigner du prefab de la plateforme de jeu � instancier
    // Cr�ation d'une variable pour stocker le component audio qui ouvre le sol
    GameObject[] walls;
    Rigidbody rb;
    public GameObject respawnPrefab;
    private AudioSource audioData;

    // Iniation de variables pour stocker la position, la rotation et l'incr�mentation pour instancier une nouvelle plateforme de jeu.
    public Vector3 StepPos = new Vector3 (0, -35f, 0);
    public Quaternion StepRot = Quaternion.Euler(0, 0, 0);    
    private Vector3 StepY = new Vector3 (0, 0, 0);
    private Quaternion StepR = Quaternion.Euler(0, 0, 0); 

    // Cette fonction assigne la position et rotation de d�part pour l'instance.
    // et elle assigne le component audio � une variable.
    private void Start()
    {
        StepY = StepPos;
        StepR = StepRot;
        audioData = GetComponent<AudioSource>();
    }

    // Losque le joueur entre en collision avec un game object, si le tag de ce game object est "Opener", 
    // cette m�thode fait jouer le son sur ce game objet, elle assigne tout les objets avec le tag "Wall" dans la liste walls
    // pour chaque objet dans cette liste, elle d�sactive l'option isKinematic sur leurs rigidbody pour qu'ils soient influenc� par la gravit�
    // elle instancie le prefab de la plateforme de jeu, incremente la position et la rotation pour la prochaine instance.
    // et change le collider pour is Trigger pour �viter la r�p�tition.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Opener"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();

            walls = GameObject.FindGameObjectsWithTag("Wall");

            foreach (GameObject wall in walls)
            {
                wall.GetComponent<Rigidbody>().isKinematic = false;
            }
            
            Instantiate(respawnPrefab, StepY, StepR);
            StepY += StepPos;
            StepR *= StepRot;

            collision.gameObject.GetComponent<Collider>().isTrigger = true;
            
        }
    }
}
