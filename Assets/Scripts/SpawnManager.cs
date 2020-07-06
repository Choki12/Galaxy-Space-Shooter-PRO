using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    IEnumerator coroutine;

    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private GameObject _enemyContainer;
    void Start()
    {
        // check that enemies have started spawning
        Debug.Log("Wait: " + Time.time);

        coroutine = SpawnRoutine(5.0f);
        StartCoroutine(coroutine); //spawn a new enemy
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn an enemy every 5 seconds
    IEnumerator SpawnRoutine(float waitTime)
    {
        while(true)
        {
            Vector3 SpawnPos = new Vector3(Random.Range(-10.0f, 10.0f), 8, 0);
            GameObject newEnemy = Instantiate(_enemyprefab, SpawnPos, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
