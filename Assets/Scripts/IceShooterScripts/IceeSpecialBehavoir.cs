using UnityEngine;

public class IceeSpecialBehaviour : MonoBehaviour
{
    public int puntosFinales = 100; // Puntos por destruir el Ice Especial después de 3 impactos
    private int impactosRecibidos = 0; // Contador de impactos
    public AudioClip crashSound;  // Variable para el sonido cuando choca

    public void getcoffeespecial() // Cuando golpea algún objeto, suena un sonido
    {
        if (crashSound != null)
        {
            AudioSource.PlayClipAtPoint(crashSound, Camera.main.transform.position, 0.5f);
        }
    }

    void Start()
    {
        // Cargamos los impactos previos guardados en PlayerPrefs (si los hubiera)
        impactosRecibidos = PlayerPrefs.GetInt("ImpactosRecibidosEspecial", 0);
    }

    private void Update()
    {
        // Aquí podrías agregar cualquier comportamiento adicional si es necesario.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el objeto colisiona con el proyectil
        if (collision.gameObject.CompareTag("Projectile"))
        {
            getcoffeespecial();
            // Aumentamos el contador de impactos y lo guardamos en PlayerPrefs
            impactosRecibidos++;
            PlayerPrefs.SetInt("ImpactosRecibidosEspecial", impactosRecibidos);
            PlayerPrefs.Save(); // Guardamos los cambios

            Debug.Log("Impactos de proyectil en Ice Especial: " + impactosRecibidos);

            // Si llega a 3 impactos, destruimos el objeto y otorgamos puntos
            if (impactosRecibidos >= 10)
            {
                // Otorgamos puntos al jugador
                GameControl.Instance.UIController.AddPoints(puntosFinales);

                // Destruimos el objeto Ice Especial
                Destroy(gameObject);

                // Reseteamos el contador de impactos en PlayerPrefs
                PlayerPrefs.SetInt("ImpactosRecibidosEspecial", 0);
                PlayerPrefs.Save();
            }
        }
         else if (collision.gameObject.CompareTag("Ice"))
        {
            Destroy(collision.gameObject);
            
        }
    }
}
