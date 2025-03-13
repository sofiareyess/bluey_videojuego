using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public Rigidbody2D myRigidbody;
    public float flapStrength;

    // Fuerza del salto
    public float jumpForce = 5f; 
    private Rigidbody2D rb;

    void Start()
    {
        // obtiene el Rigidbody2D de player
        rb = GetComponent<Rigidbody2D>();   
    }

    //se llama autocaticamente every single frame this script is running
    [System.Obsolete]
    private void Update()
    {
        //si se preciona la space bar o el mouse el hormigOxxo se mueve
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0)){
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        //Salta al presionar espacio
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // Resetea la velocidad antes de aplicar fuerza
            rb.velocity = Vector2.zero; 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Muestra en consola que se toco
        //es para probar que si sirve la collision 
        //Debug.Log("Colision con: " + collision.gameObject.name); 

        if (collision.gameObject.CompareTag("Pipe")) 
        {
            // Cambia a la pantalla de endGame
            SceneManager.LoadScene("EndGame_HormiOXXO"); 
        }
    }

}
