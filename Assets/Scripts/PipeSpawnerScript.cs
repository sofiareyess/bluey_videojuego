using UnityEngine;

//este script es para el movimiento de los garrafones
public class PipeSpawnerScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    // heightOffset, es para la altura de los garrafones, se puede cambiar
    private float heightOffset = 5;

    
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            timer += Time.deltaTime;
        }
        else {
            spawnPipe();
            timer = 0;
        }
    }

    //es para que los garrafones salgan a diferentes posiciones
    void spawnPipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float heighestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint),0), transform.rotation);
    }
}
