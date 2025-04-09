using UnityEngine;

public class IceBehaviour : MonoBehaviour
{
    public float velocity; // Velocidad de la caída
    public int puntosFinales = 20; // Puntos por destruir hielo después de 5 impactos
    private int impactosRecibidos = 0;

    public AudioClip crashSound;  // Variable para el sonido cuando choca
    public AudioClip playerSound;  // Variable para el sonido cuando choca

    public void getcoffeesound() // Cuando golpea algún objeto, suena un sonido
    {
        if (crashSound != null)
        {
            AudioSource.PlayClipAtPoint(crashSound, Camera.main.transform.position, 0.5f);
        }
    }
        public void getplayerSound() // Cuando golpea algún objeto, suena un sonido
    {
        if (crashSound != null)
        {
            AudioSource.PlayClipAtPoint(playerSound, Camera.main.transform.position, 0.5f);
        }
    }

    void Start()
    {
        // Cargamos los impactos previos guardados en PlayerPrefs
        impactosRecibidos = PlayerPrefs.GetInt("ImpactosRecibidos", 0);
    }

    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * velocity;
        if (transform.position.y < -50)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            getplayerSound();
            GameControl.Instance.SpendLives();
            GameObject.Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Aumentamos y guardamos el contador de impactos
            getcoffeesound();
            int impactosRecibidos = PlayerPrefs.GetInt("ImpactosRecibidos", 0);
            impactosRecibidos++;
            PlayerPrefs.SetInt("ImpactosRecibidos", impactosRecibidos);
            PlayerPrefs.Save(); // Guardamos los cambios

            // Si llega a 5 impactos, sumamos puntos y reiniciamos el contador
            if (impactosRecibidos >= 5)
            {
                GameControl.Instance.UIController.AddPoints(puntosFinales);
                PlayerPrefs.SetInt("ImpactosRecibidos", 0); // Reseteamos
                PlayerPrefs.Save();
            }

             GameObject.Destroy(this.gameObject); 
        }
    }
}
