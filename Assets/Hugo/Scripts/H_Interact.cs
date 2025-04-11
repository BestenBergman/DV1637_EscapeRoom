using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using static SlutPussel;
using static UnityEditor.Progress;

[RequireComponent(typeof(H_PlayerStats))]

public class H_Interact : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps = GetComponent<H_PlayerStats>();
    }

    /// <summary>
    /// Kollar ifall man kan interagera med något eller droppa 
    /// det man har i handen
    /// </summary>
    public void Interact()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f));
        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.transform.tag == "R1_Keypad")
            {
                hit.transform.gameObject.GetComponent<O_KeyPadActivate>().KeyPadSwitch();
            }
            else if (hit.transform.tag == "R2_PuzzleLever")
            {
                hit.transform.gameObject.GetComponent<O_R2P1>().SwitchLever(hit.transform.gameObject);
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
                            PickUpShard(hit.transform.gameObject);
                            PlaceShard(hit.transform.gameObject);
                        }
                        else
                        {
                            PlaceShard(hit.transform.gameObject);
                            ps.hasItem = false;
                        }
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
        }
        else if (ps.hasItem)
        {
            DropItem();
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
            gameObject.transform.GetChild(0).GetChild(1).parent = gameObject.transform.parent;
        }

        ps.hasItem = true;
        item.transform.parent = gameObject.transform.GetChild(0);
        item.transform.localRotation = Quaternion.identity;
        item.transform.localPosition = ps.HoldPos;
        item.GetComponent<Rigidbody>().isKinematic = true;
    }

    /// <summary>
    /// Släppa det GameObject man håller i
    /// </summary>
    public void DropItem()
    {
        gameObject.transform.GetChild(0).GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.GetChild(0).GetChild(1).parent = gameObject.transform.parent;
        ps.hasItem = false;
    }

    /// <summary>
    /// Uppdaterar knapparna och kollar ifall koden är löst
    /// </summary>
    /// <param name="button">GameObjectet för knappen man hartryckt på</param>
    public void InteractWithButtons(GameObject button)
    {
        button.transform.parent.GetComponent<ButtonKontroler>().UpdateButtons(button);
        if (button.transform.parent.parent.GetComponent<KontrolerKontrol>().CheckersAreRight())
        {
            button.transform.parent.parent.GetComponent<KontrolerKontrol>().ActivateStairs();
        }
    }

    public void PlaceShard(GameObject shardBox)
    {
        GameObject shard = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        shard.transform.parent = shardBox.transform;
        shard.transform.localRotation = Quaternion.identity;
        shard.transform.localPosition = new Vector3(0,1,0);
    }

    public void PickUpShard(GameObject shardBox)
    {
        ps.hasItem = true;
        GameObject shard = shardBox.transform.GetChild(0).gameObject;
        shard.transform.parent = gameObject.transform.GetChild(0);
        shard.transform.localRotation = Quaternion.identity;
        shard.transform.localPosition = ps.HoldPos;
    }
}
