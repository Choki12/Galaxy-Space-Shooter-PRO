using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField]
    private float _speed = 8.0f;

    private GameObject _laserclone;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        //if laser position is > 6.5 
        //destroy object 

        
       if(transform.position.y >= 6.3f)
        {
            Destroy(gameObject);
        }
    }

  
}
