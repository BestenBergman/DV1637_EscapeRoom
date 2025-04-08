using UnityEngine;

public class O_CameraBasedMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    CharacterController cc;
    [SerializeField] private float gravity = 9.8f;

    public float mouseSensitivity = 100f;

    private float xRot = 0f;
    private float yRot = 0f;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        CameraMovement();
        ApplyGravity();
    }



    public void CameraMovement()
    {
        // Camerafuncionality with a constraint on the x-angle to ensure the player doesn't fold themselves over backwards.
        float xLook = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float yLook = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= yLook;
        xRot = Mathf.Clamp(xRot, -90, 90);
        yRot += xLook;

        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
    }
    
    public void PlayerMovement()
    {
        

        //Movementfunctionality with normalized vectors to ensure the player moves in uniform speed in all directions.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Quaternion.Euler(0, cc.transform.eulerAngles.y, 0) * new Vector3(x, 0, z);

        if (move.magnitude > 1)
        {
            move = move.normalized;
        }
        move = move * speed * Time.deltaTime;

        cc.Move(move);
    }

    public void ApplyGravity()
    {
        cc.Move(new Vector3(0, -gravity * Time.deltaTime, 0));
    }
}


