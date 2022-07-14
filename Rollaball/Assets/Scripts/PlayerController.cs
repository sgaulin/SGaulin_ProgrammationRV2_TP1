using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

// Cette classe sert a deplacer le joueur avec les inputs clavier du joueur
// et elle gere l'interaction du joueur avec les pickups objects et le UI
public class PlayerController : MonoBehaviour
{
    // Initiation d'une variable publique pour stocker la vitesse de deplacement du joueur.
    // Creation d'une variable pour stocker le rigidbody du joueur
    // Creation de deux variables pour stocker le vecteur de l'input clavier du joueur.
    public float speed = 0;  
    private Rigidbody rb;    
    private float movementX;
    private float movementY;

    // Creation d'un objet TextMesh public pour lui assigner le component TexMeshPro de l'objet du compte, du temps et de victoire,
    // Creation d'un GameObject Public pour lui assigner le game object du texte de victoire.
    // Creation d'une variable pour stocker le nombre de pickup object ramasser par le joueur.
    // Creation d'une variable pour stocker le temps restant au jeu.
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI winText;
    public GameObject winTextObject;
    private int count;
    public float time = 60;

    // Cette methode stock le rigidbody du joueur dans une variable,
    // set le compteur de depart et desactive le message de victoire
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // A chaque frame fix, cette methode ajoute un force sur le joueur pour le deplacer en fonction du vecteur de son input clavier et de la vitesse.
    // si le temps restant est plus grand que zero, elle met a jour le temps a l'ecran,
    // sinon, elle set la variable du temps a zero, elle active et met à jour le message de victoire
    // et elle supprime ce script pour enlever les controle au joueur.
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (time > 0)
        {
            time -= Time.deltaTime;
            SetTimeText(time);
        }
        else
        {            
            time = 0;            
            winTextObject.SetActive(true);
            SetWinText();
            Destroy(this);
        }
        
    }

    // Cette methode stock l'input clavier du joueur dans une variable de type vecteur 2 et elle assigne chacune des valeurs a une variable.
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Losque le joueur entre en collision avec un game object dont le collider est en mode Trigger, si le tag de ce game object est "PickUp",
    // cette methode efface le game object apres un delai, elle incremente de 1 le compte de picuk objet ramasser
    // et appel la fonction SetCountText pour afficher le nouveau compte.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject, 0.05f);
            count++;

            SetCountText();
        }

    }

    // Cette méthode assigne le compte des pickups objects ramassés, en string, à la variable du component TextMeshPro qui affiche le texte a l'ecran
    void SetCountText()
    {
        countText.text = "COUNT: " + count.ToString();        
    }

    // Cette méthode prends la différence du temps de départ avec le temps écoulé,
    // Elle converti cette différence en secondes pour l'afficher à l'écran.
    void SetTimeText(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = "TIME: " + seconds.ToString();
        
    }

    // Cette méthode assigne le compte des pickups objets ramassé, pour afficher le compte final à la fin du jeu.
    void SetWinText()
    {
        winText.text = "SCORE: " + count.ToString();
    }
}
