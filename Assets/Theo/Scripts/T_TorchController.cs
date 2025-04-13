using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class T_TorchController : MonoBehaviour
{
    public GameObject torchLight;
    public bool torchIsEnabled = false;

    public Transform playerPos; // Assign your player GameObject in the Inspector
    public float interactionDistance = 3f;  // How close the player has to be


    private void Start()
    {
        ToggleLight(torchIsEnabled);
    }

    void Update()
    {
        float distance = Vector3.Distance(playerPos.position, gameObject.transform.position);

        if (Input.GetKeyDown(KeyCode.E) && distance <= interactionDistance)
        {
            torchIsEnabled = !torchIsEnabled;
            ToggleLight(torchIsEnabled);
        }
    }

    private void ToggleLight(bool active)
    {
        if (torchLight != null)
        {
            torchLight.SetActive(active);
        }
    }
}


