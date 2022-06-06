
using UnityEngine;

public class BaseCharacterRotation : MonoBehaviour
{
    [SerializeField]
    protected float sens = 1.5f;
    [SerializeField]
    protected float smooth = 10f;
    [SerializeField]
    protected  Transform cahr;
    protected float xRotation;
    protected float yRotation;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        xRotation -= Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    protected void RotateCharacter()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(xRotation, yRotation, 0), smooth * Time.deltaTime);
        cahr.rotation = Quaternion.Lerp(cahr.rotation, Quaternion.Euler(0, yRotation, 0), smooth * Time.deltaTime);
    }
}

