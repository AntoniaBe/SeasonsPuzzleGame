using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGrayAreas : MonoBehaviour
{

    [SerializeField]
    private GameObject[ ] sektoren;

    [SerializeField]
    private Material[ ] centerMaterial;

    [SerializeField]
    private Material[ ] sector1Material;

    [SerializeField]
    private Material[ ] sector2Material;

    [SerializeField]
    private Material[ ] sector3Material;

    [SerializeField]
    private Material[ ] sector4Material;

    [SerializeField]
    private Material[ ] sector5Material;

    [SerializeField]
    private Material[ ] sector6Material;

    private List<Material[ ]> allMaterials = new List<Material[ ]>();

    public int sectorToChange;

    [SerializeField]
    private float timeToLerp;
    private float currentTime = 0;
    private bool enableANewSector;

    public void changeGrayAreaToColor( int seasonindex )
    {
        currentTime += Time.deltaTime;
        foreach ( Material m in allMaterials[ sectorToChange ] )
        {
            m.SetFloat( Shader.PropertyToID( "_Radius" ), Mathf.Lerp( 100, 0, currentTime / timeToLerp ) );
        }
        if ( currentTime / timeToLerp >= 1 ) enableANewSector = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        allMaterials.Add( centerMaterial );
        allMaterials.Add( sector1Material );
        allMaterials.Add( sector2Material );
        allMaterials.Add( sector3Material );
        allMaterials.Add( sector4Material );
        allMaterials.Add( sector5Material );
        allMaterials.Add( sector6Material );

        for ( int s = 0; s < sektoren.Length; s++ )
        {
            changeToSektorMaterial( sektoren[ s ].transform, s );
        }


    }

    private void changeToSektorMaterial( Transform transformo, int sektorenNummer )
    {
        if ( transformo.childCount < 1 ) return;
        foreach ( Transform child in transformo )
        {
            Renderer r = child.gameObject.GetComponent<Renderer>();
            if ( r != null )
            {
                Material[ ] ms = r.materials;
                if ( sektorenNummer == 1 )
                    Debug.Log( "h" );
                string name = child.gameObject.name;
                if ( ms != null )
                {
                    List<Material> newMaterials = new List<Material>();
                    foreach ( Material material in ms )
                    {
                        string newMaterialname = "Sektor" + sektorenNummer + "/" + material.name;
                        Material newMaterial = (Material) Resources.Load( newMaterialname, typeof( Material ) );
                        if ( newMaterial != null ) newMaterials.Add( newMaterial );
                    }
                    child.gameObject.GetComponent<Renderer>().materials = newMaterials.ToArray();
                }
            }

            if ( child.childCount < 1 ) continue;
            changeToSektorMaterial( child, sektorenNummer );

        }
    }

    public void enableSector( int sectorindex )
    {
        enableANewSector = true;
        sectorToChange = sectorindex;

    }

    // Update is called once per frame
    void Update()
    {
        enableSectorOnClick();
        if ( enableANewSector ) changeGrayAreaToColor( sectorToChange );
        else { currentTime = 0; }
    }

    void enableSectorOnClick()
    {
        if ( Input.GetKey( KeyCode.F1 ) ) enableSector( 0 );
        if ( Input.GetKey( KeyCode.F2 ) ) enableSector( 1 );
        if ( Input.GetKey( KeyCode.F3 ) ) enableSector( 2 );
        if ( Input.GetKey( KeyCode.F4 ) ) enableSector( 3 );
        if ( Input.GetKey( KeyCode.F5 ) ) enableSector( 4 );
        if ( Input.GetKey( KeyCode.F6 ) ) enableSector( 5 );
        if ( Input.GetKey( KeyCode.F7 ) ) enableSector( 6 );

    }
}
    
