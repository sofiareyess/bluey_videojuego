using UnityEngine;

//este codigo es para el movimiento de los garrafones
public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);

        if(transform.position.x < deadZone){

            Destroy(gameObject);
        }
        
    }
}
