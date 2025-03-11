using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject EnemyOne;
    [SerializeField] GameObject MapBoundryMax, MapBoundryMin;

    [SerializeField] Camera mainCamera;
    private Vector2 CameraTopRight;
    private Vector2 CameraBottomLeft;
    void Start()
    {
        CameraBoudries();

        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        CameraBoudries();
        
    }
    IEnumerator EnemySpawn()
    {
        Vector2 SpawnPoint = Vector2.zero;
        float max_X;
        float min_X;
        float max_Y;
        float min_Y;
        Debug.Log("spawnyok");
        while (true)
        {
            Debug.Log("spawned");
           
            max_X = Random.Range(MapBoundryMax.transform.position.x, CameraTopRight.x);
            min_X = Random.Range(MapBoundryMin.transform.position.x, CameraBottomLeft.x);
            max_Y = Random.Range(MapBoundryMax.transform.position.y, CameraTopRight.y);
            min_Y = Random.Range(MapBoundryMin.transform.position.y, CameraBottomLeft.y);

            SpawnPoint = new Vector2(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y));
            Instantiate(EnemyOne, SpawnPoint, Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
        }
      
    }
    private void CameraBoudries()
    {
        CameraBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        CameraTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Debug.Log("bottom = " + CameraBottomLeft + " TopRight = " + CameraTopRight);

    }
}
