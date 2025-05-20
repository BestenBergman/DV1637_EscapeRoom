using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// Controls torch that can be toggled on and off by pressing E,
/// when within a certain distance.
/// </summary>
public class T_TorchController : MonoBehaviour
{
    //Torch fire GameObject
    public GameObject torchFire;

    //Determines whether the torch is enabled.
    public bool torchIsEnabled = false;

    // Assign your player GameObject in the Inspector to get player position
    //public Transform playerPos;

    // Distance within which the player can interact with the torch.
    //public float interactionDistance = 3f;

    [Tooltip("Ljudet som spelas när facklan släcks och täds")]
    [SerializeField] private AudioClip tortchSound;
    private bool skipSound = true;


    private void Start()
    {
        // Set the torch's initial state
        ToggleLight(torchIsEnabled);
    }

    void Update()
    {
        // Calculate the distance between the player and the torch
        //float distance = Vector3.Distance(playerPos.position, gameObject.transform.position);

        //// If the player presses 'E' while within interaction range, toggle the torch
        //if (Input.GetKeyDown(KeyCode.E) && distance <= interactionDistance)
        //{
        //    torchIsEnabled = !torchIsEnabled;
        //    ToggleLight(torchIsEnabled);
        //}
    }

    /// <summary>
    /// Enables or disables the torch fire.
    /// </summary>
    /// <param name="active"></param>
    public void ToggleLight(bool active)
    {
        if (torchFire != null)
        {
            if (!skipSound)
            {
                H_SoundFXManager.instance.PlaySoundFXClip(tortchSound, transform, 1f);
            }
            else
            {
                skipSound = false;
            }
            torchFire.SetActive(active);
        }
    }
}


