using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject EnemyOne;
    [SerializeField] private GameObject[] spawnLocations;
    [SerializeField] private float SpawnFrequency ;

    private CameraBoundries cameraBoundries;
    void Start()
    {
        cameraBoundries = GameObject.FindAnyObjectByType<CameraBoundries>();
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
      //  CameraBoudries();
        
    }
    IEnumerator EnemySpawn()
    {
        int spawnPointIndex;
        Debug.Log("spawnyok");
        while (true)
        {
          
            spawnPointIndex = Random.Range(0, spawnLocations.Length);
            if(spawnLocations[spawnPointIndex].transform.position.x < cameraBoundries.CameraTopRight.x && spawnLocations[spawnPointIndex].transform.position.x > cameraBoundries.CameraBottomLeft.x 
                && spawnLocations[spawnPointIndex].transform.position.y < cameraBoundries.CameraTopRight.y && spawnLocations[spawnPointIndex].transform.position.y > cameraBoundries.CameraBottomLeft.y)
            {
                Debug.Log("kameraya denk geldi");
              //  StartCoroutine(EnemySpawn());
              //  break;
            }
            else
            {
                Debug.Log("spawnOluyor");
                Instantiate(EnemyOne, spawnLocations[spawnPointIndex].transform.position, Quaternion.identity);
            }
          
         

            yield return new WaitForSeconds(SpawnFrequency);
        }
      
    }

}
