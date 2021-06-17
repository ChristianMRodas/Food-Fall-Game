using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager; //so that it can use the GM script on here as well (like scores on destory
    //      *then in start, add the .Find + GetComps...

    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;

    private float xRange = 4;
    private float ySpawnPos = -2;

    public int pointValue; //go to unity to udpate values (pionts per obj

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //<GM> not G..Obj..
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //Finds the script, gets its components
        //      so that we can use them here


        //Random x, random height(y), random rotation
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        
        transform.position = RandomSpawnPos(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //overrides a unity premade mehtod
    //used to destory objects just by clicking down on the mosue
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);

            //Pos is where the current game obj is at,  sets particle rot's as the same as before
            //  *Note update on Unity
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            //updatres score (*note: use the period  //Note: method needs to be public (else cant access it)
            //5 increments

            gameManager.UpdateScore(pointValue); //comes form the GM script //Passes the point values assigned
                                                 //  from Unity, and updates correct score
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); //Des obj when falls below map

        //created a tag "Bad" for the skull item, n assigned it to it
        // so now if the gameObj IS NOT the "bad" obj, its game over (so good item falls below the map, game over)
        if(!gameObject.CompareTag("Bad"))  
        {
            gameManager.GameOver(); //displays game over
        }
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        //uses the "new" keyword bcuz we are actually creating a new Vector3 (whereas RandomForce just multiplies it
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
