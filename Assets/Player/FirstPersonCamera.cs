using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
  public float sensX, sensY;
  public Transform orientation;
  public Transform playerObj;

  private float xRotation, yRotation;

  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  void Update()
  {
    float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
    float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

    yRotation += mouseX;
    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    playerObj.rotation = Quaternion.Euler(0, yRotation, 0);
  }
}
