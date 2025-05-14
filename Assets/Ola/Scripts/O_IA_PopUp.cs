using System.Linq;
using TMPro;
using UnityEngine;

public class O_IA_PopUp : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;
    public TextMeshProUGUI IA_PopUp;
    public TextMeshProUGUI inspectPopUp;
    

    
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<H_PlayerStats>();
    }

    
    void Update()
    {
        inspectPopUp.text = "";
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        if (!ps.hasItem)
        {
            if (Physics.Raycast(ray, out hit, 3.0f))
            {
                
                if (hit.transform.tag == "R1_Keypad" || hit.transform.tag == "R2_Keypad")
                {
                    if (!ps.inKeyPad)
                    {
                        IA_PopUp.text = "Press (E) to activate keypad";
                    }
                    else
                    {
                        IA_PopUp.text = "Press (E) to leave keypad";
                    }
                }
                else if (hit.transform.tag == "R2_PuzzleLever" || hit.transform.tag == "Lever")
                {
                    IA_PopUp.text = "Press (E) to toggle lever";
                }
                else if (hit.transform.tag == "R3_Torch")
                {
                    IA_PopUp.text = "Press (E) to light torch";
                }
                else if (hit.transform.tag == "R4_Button")
                {
                    IA_PopUp.text = "Press (E) to press button";
                }
                else if (ps.ItemTags.Contains(hit.transform.tag))
                {
                    IA_PopUp.text = "Press (E) to pick up item";
                }
                else if (hit.transform.tag == "R1_Chest" && !ps.hasOpenedChest)
                {
                    IA_PopUp.text = "Press (E) to open chest";
                }
                else if (ps.ShardBoxes.Contains(hit.transform.tag))
                {
                    if (hit.transform.childCount > 0)
                    {
                        IA_PopUp.text = "Press (E) to pick up shard";
                    }
                    else
                    {
                        IA_PopUp.text = "";
                    }
                }
                else
                {
                    IA_PopUp.text = "";
                }
            }
            else
            {
                IA_PopUp.text = "";
            }
        }
        else
        {
            if(!ps.isInspecting)
            {
                if (!ps.inKeyPad)
                {
                    inspectPopUp.text = "Press (Q) to inspect item";
                }

                if (Physics.Raycast(ray, out hit, 3.0f))
                {
                    if (hit.transform.tag == "R1_Keypad" || hit.transform.tag == "R2_Keypad")
                    {
                        if (!ps.inKeyPad)
                        {
                            IA_PopUp.text = "Press (E) to activate keypad";
                        }
                        else
                        {
                            IA_PopUp.text = "Press (E) to leave keypad";
                        }
                    }
                    else if (hit.transform.tag == "R2_PuzzleLever" || hit.transform.tag == "Lever")
                    {
                        IA_PopUp.text = "Press (E) to toggle lever";
                    }
                    else if (hit.transform.tag == "R3_Torch")
                    {
                        IA_PopUp.text = "Press (E) to light torch";
                    }
                    else if (hit.transform.tag == "R4_Button")
                    {
                        IA_PopUp.text = "Press (E) to press button";
                    }
                    else if (ps.ItemTags.Contains(hit.transform.tag))
                    {
                        IA_PopUp.text = "Press (E) to pick up item";
                    }
                    else if (ps.ShardBoxes.Contains(hit.transform.tag))
                    {
                        if (ps.Shards.Contains(gameObject.transform.GetChild(0).transform.GetChild(1).tag))
                        {
                            IA_PopUp.text = "Press (E) to place shard";
                        }
                        else
                        {
                            IA_PopUp.text = "Press (E) to drop item";
                        }
                    }
                    else
                    {
                        IA_PopUp.text = "Press (E) to drop item";
                    }
                }
                else
                {
                    IA_PopUp.text = "Press (E) to drop item";
                }
            }
            else if (ps.isInspecting)
            {
                IA_PopUp.text = "Use mouse to grab and rotate item\n\nPress (E) to drop item";
                inspectPopUp.text = "Press (Q) to uninspect item";
            }
        }
    }
}

