using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float _speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyBehaviour();
    }

    void EnemyBehaviour()
    {
        //move down 4m/s2
        //if screen = bottom respawn at top with new random x position

        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -6.0f)
        {
            float randomx = Random.Range(-10.0f, 10.0f);
            transform.position = new Vector3(randomx, 6.0f, transform.position.z);
        }

    }

    //defining collision detection 
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.transform.name);

        //destroy enemy and player

        //destroy laser and player

        if(other.tag == "Player")
        {
            //damage player as well
            /*We access a gameObject component via this method, 
             * "other" only has a reference to the player gameObject if a collision happens*/

            //GetComponent<>() might throw a null reference exception

            //GOOD PRACTICE
            //Store the gameObject in a new instance 

            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }



    }
}
