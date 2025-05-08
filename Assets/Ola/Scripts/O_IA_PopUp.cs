using System.Linq;
using TMPro;
using UnityEngine;

public class O_IA_PopUp : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;
    public TextMeshProUGUI IA_PopUp;
    public TextMeshProUGUI inspectPopUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<H_PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ps.hasItem)
        {
            inspectPopUp.text = "";
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            if (Physics.Raycast(ray, out hit, 3.0f))
            {
                
                if (hit.transform.tag == "R1_Keypad" || hit.transform.tag == "R2_Keypad")
                {
                    IA_PopUp.text = "Press (E) to activate keypad";
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
        else if (ps.hasItem)
        {
            
            
            if(!ps.isInspecting)
            {
                inspectPopUp.text = "Press (Q) to inspect item";
                IA_PopUp.text = "Press (E) to drop item";
                if (ps.Shards.Contains(gameObject.transform.GetChild(0).transform.GetChild(1).tag))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
                    if (Physics.Raycast(ray, out hit, 3.0f))
                    {
                        if (ps.ShardBoxes.Contains(hit.transform.tag))
                        {
                            IA_PopUp.text = "Press (E) to place shard";
                        }
                    }    
                }
            }
            else if (ps.isInspecting)
            {
                IA_PopUp.text = "";
                inspectPopUp.text = "Press (Q) to uninspect item";
            }
        }
    }
}
