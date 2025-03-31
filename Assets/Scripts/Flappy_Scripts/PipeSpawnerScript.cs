using UnityEngine;

//este script es para el movimiento de los garrafones
public class PipeSpawnerScript : MonoBehaviour
{
    //prefab del garrafon 
    public GameObject pipe;
    //tiempo en lo que aparece cada garrafon
    public float spawnRate = 2;
    // temporizador para controlar el tiempo entre los spawns
    private float timer = 0;
    // heightOffset, es para la altura de los garrafones, se puede cambiar
    public float heightOffset = 3;

    
    void Start()
    {
        //genera un garrafon al iniciar el juego
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        //funcion para checar el tiempo para generar garrafones
        if (timer < spawnRate){
            // aumenta el temporizador con el tiempo transcurrido en cada frame
            timer += Time.deltaTime;
        }
        else {
            //genera unnuevo garrafon y reinicia el timer
            spawnPipe();
            timer = 0;
        }
    }

    //es para que los garrafones salgan a diferentes posiciones
    void spawnPipe(){
        //calcula los limites inferior y superior de la altura de los garrafones
        float lowestPoint = transform.position.y - heightOffset;
        float heighestPoint = transform.position.y + heightOffset;

        // produce un nuevo garrafon en una posición aleatoria 
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint),0), transform.rotation);
    }
}
