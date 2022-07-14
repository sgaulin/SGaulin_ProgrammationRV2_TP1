using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cette classe sert à animer les lumieres et déclancher un son lorsque le joueur ramasse un pickup object.
public class PickFX : MonoBehaviour
{
    // Creation de deux variable pour stocker les components d'animation du joueur et des pickups objects
    // Creation d'une variable pour stocker le component audio du joueur
    private Animation anim;
    private Animation animPickUp;
    private AudioSource audioData;

    // Cette methode initialise les variables aux components du joueur
    void Start()
    {
        anim = GetComponent<Animation>();
        audioData = GetComponent<AudioSource>();
    }

    // Losque le joueur entre en collision avec un game object dont le collider est en mode Trigger, si le tag de ce game object est "PickUp",
    // cette methode declanche une animation sur la lumiere du pickup object et sur le joueur.
    // Elle declanche un clip audio et incremente le pitch de ce son.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            animPickUp = other.gameObject.GetComponent<Animation>();
            animPickUp.Play();                      
            anim.Play();

            audioData.Play();
            audioData.pitch = audioData.pitch + 0.05f;           
        }

    }
}
