using UnityEngine;
using UnityEngine.UIElements;

public class SlutPussel : MonoBehaviour
{
    [System.Serializable]
    public struct ShardBoxes
    {
        [Tooltip("BlueBoxFunktion\nVill ha in scriptet som sitter på blueBox")]
        public RightChild bBF;

        [Tooltip("RedBoxFunktion\nVill ha in scriptet som sitter på redBox")]
        public RightChild rBF;

        [Tooltip("GreenBoxFunktion\nVill ha in scriptet som sitter på greenBox")]
        public RightChild gBF;
    }
    [Tooltip("Variabler för de script som sitter på blue-, red-, greenBox")]
    public ShardBoxes sB;

    [System.Serializable]
    public struct HitWallVariables
    {
        [Tooltip("HitWall\nVill ha GameObjectet till den vägg som ska ändra textur")]
        public GameObject hW;

        [Tooltip("Det material som väggen ska ha som standard")]
        public Material m1;

        [Tooltip("Det material som väggen ska få när alla skärvorna är på rätt plats och ljuset är aktiverat")]
        public Material m2;
    }
    [Tooltip("Variabler för den vägg som ska byta textur när alla skärvor är på rätt plats och ljuset är aktiverat")]
    public HitWallVariables hWV;

    [Tooltip("Vill ha GameObjectet till det ljus som ska sättas av och på")]
    public GameObject ljus;

    [Tooltip("Visar om ljuset är på eller av")]
    [SerializeField] private bool active;

    private void Start()
    {
        active = false;
        ljus.SetActive(false);
    }
    private void Update()
    {
        // Om ljuset är på kollas om glasskärvorna är på rätt plats
        if (active)
        {
            CheckShards();
        }
    }

    /// <summary>
    /// Tänder eller släcker lampan
    /// </summary>
    public void SwitchState()
    {
        if (active)
        {
            active = false;
            ljus.SetActive(false);
            hWV.hW.GetComponent<MeshRenderer>().material = hWV.m1;
        }
        else
        {
            ljus.SetActive(true);
            active = true;
        }
    }

    /// <summary>
    /// Kollar om glasskärvorna är på rätt plats och byter material 
    /// på väggen beroende på svaret
    /// </summary>
    public void CheckShards()
    {
        if (sB.bBF.HasRightChild() && sB.rBF.HasRightChild() && sB.gBF.HasRightChild())
        {
            hWV.hW.GetComponent<MeshRenderer>().material = hWV.m2;
        }
        else
        {
            hWV.hW.GetComponent<MeshRenderer>().material = hWV.m1;
        }
    }
}
