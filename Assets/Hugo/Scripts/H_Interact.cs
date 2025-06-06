using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;


[RequireComponent(typeof(H_PlayerStats))]

public class H_Interact : MonoBehaviour
{
    [Tooltip("GameObjectet som har T_HourglassTimer p� sig")]
    public GameObject UI; //Theo


    [HideInInspector] public H_PlayerStats ps;
    
    void Start()
    {
        ps = GetComponent<H_PlayerStats>();
    }

    /// <summary>
    /// Kollar ifall man kan interagera med n�got eller droppa 
    /// det man har i handen
    /// </summary>
    public void Interact()
    {
        if (ps.isInspecting)
        {
            if (ps.hasItem)
            {
                Cursor.lockState = CursorLockMode.Locked;
                ps.isInspecting = false;
                DropItem();
            }
        }
        else
        {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out hit, 3f))
            {
                if (hit.transform.tag == "R1_Keypad" || hit.transform.tag == "R2_Keypad")
                {
                    hit.transform.gameObject.GetComponent<O_KeyPadActivate>().KeyPadSwitch();
                }
                else if (hit.transform.tag == "R3_Torch")
                {
                    T_TorchController torch = hit.transform.gameObject.GetComponent<T_TorchController>();
                    torch.torchIsEnabled = !torch.torchIsEnabled;
                    torch.ToggleLight(torch.torchIsEnabled);
                }
                else if (hit.transform.tag == "R2_PuzzleLever")
                {
                    hit.transform.gameObject.GetComponent<O_R2P1>().SwitchLever();
                }
                else if (ps.ItemTags.Contains(hit.transform.tag))
                {
                    PickUpItem(hit.transform.gameObject);
                }
                else if (hit.transform.tag == "Lever")
                {
                    hit.transform.gameObject.GetComponent<SlutPussel>().SwitchState();
                }
                else if (hit.transform.tag == "R4_Button")
                {
                    InteractWithButtons(hit.transform.gameObject);
                }
                else if (ps.ShardBoxes.Contains(hit.transform.tag))
                {
                    if (ps.hasItem)
                    {
                        if (ps.Shards.Contains(gameObject.transform.GetChild(0).transform.GetChild(1).tag))
                        {
                            if (hit.transform.childCount > 0)
                            {
                                PlaceShard(hit.transform.gameObject);
                                PickUpShard(hit.transform.gameObject);
                            }
                            else
                            {
                                PlaceShard(hit.transform.gameObject);
                            }
                        }
                        else
                        {
                            DropItem();
                        }
                    }
                    else if (hit.transform.childCount > 0)
                    {
                        PickUpShard(hit.transform.gameObject);
                    }
                }
                else if (ps.hasItem)
                {
                    DropItem();
                }
                else if (hit.transform.tag == "R1_Chest")
                {
                    UI.transform.gameObject.GetComponent<T_HourglassTimer>().startTimer = true;
                    hit.transform.parent.gameObject.GetComponent<O_StartAnim>().Started();
                    ps.fWalk = false;
                    ps.hasOpenedChest = true;
                    UI.transform.GetChild(3).gameObject.SetActive(true);
                }
            }
            else if (ps.hasItem)
            {
                DropItem();
            }
        }
    }

    /// <summary>
    /// Plockar upp ett GameObject
    /// </summary>
    /// <param name="item">Det GameObject man vill plocka upp</param>
    public void PickUpItem(GameObject item)
    {
        if (ps.hasItem)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<BoxCollider>().isTrigger = false;
            gameObject.transform.GetChild(0).GetChild(1).parent = gameObject.transform.parent;
        }

        ps.hasItem = true;
        item.transform.parent = gameObject.transform.GetChild(0);
        item.transform.localRotation = Quaternion.identity;
        item.transform.localPosition = ps.HoldPos;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<BoxCollider>().isTrigger = true;
    }

    /// <summary>
    /// Sl�ppa det GameObject man h�ller i
    /// </summary>
    public void DropItem()
    {
        gameObject.transform.GetChild(0).GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.GetChild(0).GetChild(1).GetComponent<BoxCollider>().isTrigger = false;
        gameObject.transform.GetChild(0).GetChild(1).parent = gameObject.transform.parent;
        ps.hasItem = false;
    }

    /// <summary>
    /// Uppdaterar knapparna och kollar ifall koden �r l�st
    /// </summary>
    /// <param name="button">GameObjectet f�r knappen man hartryckt p�</param>
    public void InteractWithButtons(GameObject button)
    {
        button.transform.parent.GetComponent<ButtonKontroler>().UpdateButtons(button);
        if (button.transform.parent.parent.GetComponent<KontrolerKontrol>().CheckersAreRight())
        {
            button.transform.parent.parent.GetComponent<KontrolerKontrol>().ActivateStairs();
        }
    }

    /// <summary>
    /// Placerar den shard man har i handen p� shardBox
    /// </summary>
    /// <param name="shardBox">Den pedestal man har interagerat med</param>
    public void PlaceShard(GameObject shardBox)
    {
        GameObject shard = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        shard.transform.parent = shardBox.transform;
        shard.transform.localPosition = new Vector3(0,0,0);
        shard.transform.localRotation = Quaternion.identity;
        ps.hasItem = false;
    }

    /// <summary>
    /// Plocka upp den shard som finns p� shardBox
    /// </summary>
    /// <param name="shardBox">Den pedestal man har interagerat med</param>
    public void PickUpShard(GameObject shardBox)
    {
        ps.hasItem = true;
        GameObject shard = shardBox.transform.GetChild(0).gameObject;
        shard.GetComponent<BoxCollider>().isTrigger = true;
        shard.transform.parent = gameObject.transform.GetChild(0);
        shard.transform.localRotation = Quaternion.identity;
        shard.transform.localPosition = ps.HoldPos;
    }
}
