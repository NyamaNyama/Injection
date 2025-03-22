using UnityEngine;

public class CameraFollowCursor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float screenEdgeBuffer = 0.1f;
    public Camera mainCamera;

    void Update()
    {
        Vector3 cursorPosition = Input.mousePosition;
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        if (cursorPosition.x < screenEdgeBuffer * Screen.width)
        {
            mainCamera.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if (cursorPosition.x > (1 - screenEdgeBuffer) * Screen.width)
        {
            mainCamera.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
