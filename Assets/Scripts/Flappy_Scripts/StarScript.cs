using UnityEngine;
using UnityEngine.SceneManagement;
public class StarScript : MonoBehaviour
{
        // vel a la que se mueve el garrafon a la izquierda
    public float moveSpeed = 5;
    // posicion X donde el garrafon se destruye
    public float deadZone = -45;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        // mueve el garrafon hacia la izquierda a velocidad constante
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
        //si el garrafon llega a la deadzone, se destruye el objeto
        if(transform.position.x < deadZone){
            Destroy(gameObject);
        }
        
    }
}