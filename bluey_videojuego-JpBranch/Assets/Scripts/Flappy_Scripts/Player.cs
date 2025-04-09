using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    private PreguntasController preguntacontroller;
    private PausaBehaviour pauseBehaviour; // Referencia a PauseBehaviour

    // Fuerza del salto
    public float jumpForce = 5f; 
    private Rigidbody2D rb;

    public AudioSource jumpSound; // Variable para el sonido cada vez que salta
    public AudioClip crashSound;  // Variable para el sonido cuando choca

    public void getCrash() // Cuando golpea algún objeto, suena un sonido
    {
        if (crashSound != null)
        {
            AudioSource.PlayClipAtPoint(crashSound, Camera.main.transform.position, 0.5f);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        jumpSound = GetComponent<AudioSource>();

        preguntacontroller = FindFirstObjectByType<PreguntasController>();
        pauseBehaviour = FindFirstObjectByType<PausaBehaviour>(); // Obtiene el script de pausa
        if (pauseBehaviour == null){
    }

    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            if (jumpSound != null) jumpSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.velocity = Vector2.zero; 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (jumpSound != null) jumpSound.Play();
        }
    }
private void OnCollisionEnter2D(Collision2D collision)
{

    if (collision.gameObject.CompareTag("Pipe")) 
    {


        getCrash();
        Invoke("LoadEndGameScene", 0.25f);
    }
    else if (collision.gameObject.CompareTag("star")) {

         Destroy(collision.gameObject);

        pauseBehaviour.PauseGame(); // Pausa el juego al chocar con la estrella
}

}

void LoadEndGameScene()
{
    // Despausa el juego antes de cargar la escena de Game Over
    Time.timeScale = 1; 
    SceneManager.LoadScene("EndGame_HormiOXXO"); 
}

}
