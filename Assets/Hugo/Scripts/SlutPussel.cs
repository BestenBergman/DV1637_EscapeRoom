using UnityEngine;
using UnityEngine.UIElements;

public class SlutPussel : MonoBehaviour
{
    [System.Serializable]
    public struct ShardBoxes
    {
        [Tooltip("BlueBoxFunktion\nVill ha in scriptet som sitter p� blueBox")]
        public RightChild bBF;

        [Tooltip("RedBoxFunktion\nVill ha in scriptet som sitter p� redBox")]
        public RightChild rBF;

        [Tooltip("GreenBoxFunktion\nVill ha in scriptet som sitter p� greenBox")]
        public RightChild gBF;
    }
    [Tooltip("Variabler f�r de script som sitter p� blue-, red-, greenBox")]
    public ShardBoxes sB;

    [HideInInspector]public bool puzzleComplete = false;

    [System.Serializable]
    public struct HitWallVariables
    {
        [Tooltip("HitWall\nVill ha GameObjectet till den v�gg som ska �ndra textur")]
        public GameObject hW;

        [Tooltip("Det material som v�ggen ska ha som standard")]
        public Material m1;

        [Tooltip("Det material som v�ggen ska f� n�r alla sk�rvorna �r p� r�tt plats och ljuset �r aktiverat")]
        public Material m2;
    }
    [Tooltip("Variabler f�r den v�gg som ska byta textur n�r alla sk�rvor �r p� r�tt plats och ljuset �r aktiverat")]
    public HitWallVariables hWV;

    [Tooltip("Vill ha GameObjectet till det ljus som ska s�ttas av och p�")]
    public GameObject ljus;

    [Tooltip("Visar om ljuset �r p� eller av")]
    [SerializeField] private bool active;

    [Tooltip("Det ljud som ska spelas n�r spaken dras i")]
    [SerializeField] private AudioClip leverSound;

    private void Start()
    {
        active = false;
        ljus.SetActive(false);
    }
    private void Update()
    {
        // Om ljuset �r p� s� kollas om glassk�rvorna �r p� r�tt plats
        if (active)
        {
            CheckShards();
        }
    }

    /// <summary>
    /// T�nder eller sl�cker lampan
    /// </summary>
    public void SwitchState()
    {
        if (active)
        {
            active = false;
            H_SoundFXManager.instance.PlaySoundFXClip(leverSound, transform, 1f);
            ljus.SetActive(false);
            transform.localEulerAngles = Vector3.zero;
            hWV.hW.GetComponent<MeshRenderer>().material = hWV.m1;
        }
        else
        {
            ljus.SetActive(true);
            H_SoundFXManager.instance.PlaySoundFXClip(leverSound, transform, 1f);
            transform.localEulerAngles = new Vector3 (-90f, 0f, 0f);
            active = true;
        }
    }

    /// <summary>
    /// Kollar om glassk�rvorna �r p� r�tt plats och byter material 
    /// p� v�ggen beroende p� svaret
    /// </summary>
    public void CheckShards()
    {
        if (sB.bBF.HasRightChild() && sB.rBF.HasRightChild() && sB.gBF.HasRightChild())
        {
            hWV.hW.GetComponent<MeshRenderer>().material = hWV.m2;
            puzzleComplete = true;
        }
        else
        {
            hWV.hW.GetComponent<MeshRenderer>().material = hWV.m1;
        }
    }
}
