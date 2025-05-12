using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(H_PlayerStats))]
[RequireComponent(typeof(CharacterController))]

public class O_CameraBasedMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 7.0f;
    [SerializeField] private float runSpeed = 12.0f;
    private float speed;
    CharacterController cc;
    [SerializeField] private float gravity = 9.8f;

    [HideInInspector] public H_PlayerStats ps;

    public float mouseSensitivity = 100f;

    private float xRot = 0f;
    [HideInInspector] public float yRot = 180f;

    void Start()
    {
        speed = walkSpeed;

        cc = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        ps = GetComponent<H_PlayerStats>();
        //ps.fWalk = true;
        StartCoroutine(startWalkPlayer());
    }

    void Update()
    {
        if (ps.fWalk)
        {
            ForcedPlayerMovment(ps.fWalkDir);
            ForcedCameraMovement(ps.fLookDir);
        }
        else if (!ps.inKeyPad)
        {
            if (!ps.isInspecting)
            {
                CameraMovement();
            }
            ApplyGravity();
        }
    }



    public void CameraMovement()
    {
        // Camerafuncionality with a constraint on the x-angle to ensure the player doesn't fold themselves over backwards.
        float xLook = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float yLook = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= yLook;
        xRot = Mathf.Clamp(xRot, -90, 90);
        yRot += xLook;

        transform.GetChild(0).localRotation = Quaternion.Euler(xRot, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, yRot, 0f);
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

    public void SprintSwitch()
    {
        speed = speed == walkSpeed ? runSpeed : walkSpeed;
    }

    private void ForcedPlayerMovment(Vector3 walkDir)
    {
        float x = walkDir.x;
        float z = walkDir.z;

        Vector3 move = Quaternion.Euler(0, cc.transform.eulerAngles.y, 0) * new Vector3(x, 0, z);

        if (move.magnitude > 1)
        {
            move = move.normalized;
        }
        move = move * speed * Time.deltaTime;

        cc.Move(move);
    }

    public void ForcedCameraMovement(Vector2 lookDir)
    {
        // Camerafuncionality with a constraint on the x-angle to ensure the player doesn't fold themselves over backwards.
        float xLook = lookDir.x * mouseSensitivity * Time.deltaTime;
        float yLook = lookDir.y * mouseSensitivity * Time.deltaTime;

        xRot -= yLook;
        xRot = Mathf.Clamp(xRot, -90, 90);
        yRot += xLook;

        transform.GetChild(0).localRotation = Quaternion.Euler(xRot, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, yRot, 0f);
    }

    private IEnumerator startWalkPlayer()
    {
        ps.fWalkDir = new Vector3(0, 0, 1);
        yield return new WaitUntil(() => transform.position.z <= 10f);
        ps.fLookDir = new Vector2(-1, 0);
        yield return new WaitUntil(() => transform.localRotation.eulerAngles.y <= 145f);
        ps.fLookDir = Vector2.zero;
        yield return new WaitUntil(() => transform.position.z <= -5.8);
        ps.fWalkDir = Vector3.zero;
        ps.fLookDir = new Vector2(0, -1f);
        yield return new WaitUntil(() => transform.GetChild(0).localRotation.eulerAngles.x >= 35f);
        ps.fLookDir = Vector2.zero;
    }
}


