using UnityEngine;

public class CameraFollowCursor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float screenEdgeBuffer = 0.1f;
    public Camera mainCamera;
    [SerializeField] private float xBorder;

    private void Update()
    {
        Vector3 cursorPosition = Input.mousePosition;

        if (cursorPosition.x < screenEdgeBuffer * Screen.width && 
            transform.position.x > -xBorder)
        {
            mainCamera.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if (cursorPosition.x > (1 - screenEdgeBuffer) * Screen.width && 
                 transform.position.x < xBorder)
        {
            mainCamera.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
