using UnityEngine;

// Comportamiento del hielo
public class ProjectileBehaviour : MonoBehaviour
{
    public float velocity; // Velocidad
    void Start()
    {
        
    }

    // Destruye la gota cuando se aleja del escenario
    void Update()
    {
        this.transform.position += Vector3.up * Time.deltaTime * velocity;
        if (transform.position.y > 50)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    // Destruye la gota 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si le pega al hielo se destruye
        if (collision.gameObject.CompareTag("Ice"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
