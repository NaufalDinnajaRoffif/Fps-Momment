using UnityEngine;

public class playerMomment : MonoBehaviour
{
    public float speed;
    public float cameraSensitivity;

    private float verticalModifier = 0.0f;
    private float horizontalModifier = 0.0f;

    private float cameraHorizontalModifier = 0.0f;
    private float cameraVerticalModifier = 0.0f;

    private Vector3 cameraEulerRotation;

    // Start is called before the first frame update
    private void Start()
    {
        cameraEulerRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    private void Update()
    {
        Readinput();
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        // math area
        // posisi a ke posisi b = jarak tempuh
        // jarak = kecepatan * waktu
        float newDistance = speed * Time.deltaTime;
        Vector2 newPosition = new Vector2(newDistance * horizontalModifier, newDistance * verticalModifier);

        Vector3 forward = Vector3.Normalize(new Vector3(transform.forward.x, 0, transform.forward.z));
        Vector3 right = Vector3.Normalize(new Vector3(transform.right.x, 0, transform.right.z));

        transform.localPosition += (newPosition.y * forward) + (newPosition.x * right);
    }

    private void Readinput()
    {
        verticalModifier = Input.GetAxis("Vertical");
        horizontalModifier = Input.GetAxis("Horizontal");

        cameraVerticalModifier = -Input.GetAxis("mouse_y");
        cameraHorizontalModifier = Input.GetAxis("mouse_x");
    }

    private void RotatePlayer()
    {
        float newDistance = (100 - cameraSensitivity) * Time.deltaTime;
        cameraEulerRotation += new Vector3(newDistance * cameraVerticalModifier, newDistance * cameraHorizontalModifier, 0);

        transform.localRotation = Quaternion.Euler(cameraEulerRotation.x, cameraEulerRotation.y, 0.0f);

    }
}
