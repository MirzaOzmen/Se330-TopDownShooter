using UnityEngine;

public class CameraBoundries : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public Vector2 CameraTopRight;
    public Vector2 CameraBottomLeft;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraBoudries();
    }
    private void CameraBoudries()
    {
        
        CameraBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        CameraTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Debug.Log("bottom = " + CameraBottomLeft + " TopRight = " + CameraTopRight);

    }
}
