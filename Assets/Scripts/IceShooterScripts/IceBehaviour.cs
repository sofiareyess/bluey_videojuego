using UnityEngine;

// Comportamiento del hielo
public class IceBehaviour : MonoBehaviour
{
    public float velocity; // Velocidad de la caida
    public int points = 100; // Puntos por destruir hielo
    void Start()
    {
        
    }

    // Destruye el hielo cuando se aleja del escenario
    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * velocity;
        if (transform.position.y < -50)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    // Destruye el hielo 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con Hormigoxxo le quita una vida
        if (collision.gameObject.CompareTag("Player")) 
        {
            GameControl.Instance.SpendLives();
            GameObject.Destroy(this.gameObject);
        }
        // Si le pega el café se suman puntos
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameControl.Instance.UIController.AddPoints(points);
            GameObject.Destroy(this.gameObject);
        }
    }
}
