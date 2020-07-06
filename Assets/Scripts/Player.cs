using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // if we make the speed public, its value is adjustable in the unity object palette
    //other game objects can use its value
    //best practice says to keep variables private 

    [SerializeField] // the attribute lets the variable be adjusted in the engine
    private float speed = 3.8f;

    [SerializeField]
    private GameObject _laserprefab;

    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;

    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.FindGameObjectWithTag("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.Log("Spawn Manager failed to initialize");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > _canFire))
        {
            ShootLaser();
        }
    }

    //Cleaning up codebase
    //Write a method to do it all, its lighter on the os' resources

    void CalculateMovement()
    {

        float horizontalInput = Input.GetAxis("Horizontal"); // returns a float value
        float verticalInput = Input.GetAxis("Vertical");
        
        // Vector3(5, 0, 0) * 5 * real time => m/s^-1
        //per frame it moves by 5m/s^-1
        
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput *speed * Time.deltaTime);


        /*creating player boundaries*/

        //y-axis
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-3.8f,3.8f), 0);

        //x-axis
        if (transform.position.x >= 14.2f)
        {
            transform.position = new Vector3(-14.2f, transform.position.y, 0);
        }
        else if (transform.position.x <= -14.2f)
        {
            transform.position = new Vector3(14.2f, transform.position.y, 0);
        }

    }

    void ShootLaser()
    {
        //We will now shoot lasers
        //We spawn a game object to do that
        //Check if the space key is pressed

        //Unity reads rotation in terms of the oiler angle

       
            //FireRate is our time delay
            //Each time we fire we update our canfire which is essentially just time + rate of fire
            //we delay firing by 0.5 seconds
            _canFire = Time.time + _fireRate;
            Instantiate(_laserprefab, new Vector3(transform.position.x, transform.position.y + 0.8f, 0), Quaternion.identity); //Quaternion.identity = object rotation 
        
    }

    /*Used for damaging player*/
    public void Damage()
    {
        _lives--;

        if(_lives < 1)
        {
            _spawnManager.PlayerIsDead();
            Destroy(this.gameObject);
            
        }
    }
}
