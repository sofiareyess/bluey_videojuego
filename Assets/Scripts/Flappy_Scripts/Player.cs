using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public Rigidbody2D myRigidbody;
    public float flapStrength;

    // Fuerza del salto
    public float jumpForce = 5f; 
    private Rigidbody2D rb;

    public AudioSource jumpSound; // Variable para el sonido cada vez que salta

    public AudioClip crashSound; // Variable para el sonido cuando choca

    public void getCrash()  // Cuando golpea algun objeto suena un sonido
    {
        //Asegura que el sonido de choque existe antes de repoducir
        if (crashSound != null)
        {
            AudioSource.PlayClipAtPoint(crashSound,Camera.main.transform.position,0.5f);
        }
    }
    void Start()
    {
        // obtiene el Rigidbody2D de player
        rb = GetComponent<Rigidbody2D>();   
        jumpSound = GetComponent<AudioSource>();
    }

    //se llama autocaticamente every single frame this script is running
    [System.Obsolete]
    private void Update()
    {
        //si se preciona la space bar o el mouse el hormigOxxo se mueve
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0)){
            myRigidbody.velocity = Vector2.up * flapStrength;

            // Reproduce el sonido de salto
            if (jumpSound != null)
            {
                jumpSound.Play();
            }
        }

        //Salta al presionar espacio
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // Resetea la velocidad antes de aplicar fuerza
            rb.velocity = Vector2.zero; 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Reproduce el sonido de salto

            if (jumpSound != null)
            {
                jumpSound.Play();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Muestra en consola que se toco
        //es para probar que si sirve la collision 
        //Debug.Log("Colision con: " + collision.gameObject.name); 

        if (collision.gameObject.CompareTag("Pipe")) 
        {
            // Reproduce el sonido de choque antes de cambiar de escena
            getCrash();
            // Espera 0.5 segundos antes de cambiar de escena para permitir que el sonido se escuche
            Invoke("LoadEndGameScene", 0.25f); 
        }
    }

    void LoadEndGameScene()
    {
        SceneManager.LoadScene("EndGame_HormiOXXO"); 

    }

}
