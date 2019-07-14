using System;
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

    private int sectorToChange;

    [SerializeField]
    private float timeToLerp;
    [SerializeField]
    private AnimationCurve enableAccCurve;

    private float currentTime = 0;
    private bool enableANewSector;

    private void changeGrayAreaToColor( int seasonindex )
    {
        currentTime += Time.deltaTime;

        foreach ( Material m in allMaterials[ sectorToChange ] )
        {
            float value = enableAccCurve.Evaluate((currentTime / timeToLerp));
            m.SetFloat( Shader.PropertyToID( "_Radius" ), Mathf.Lerp( 0, 200, value ) );
            
        }
        if ( (currentTime / timeToLerp) >= 1 )
        {
            enableANewSector = false;
            currentTime = 0;
        }
    }

    void OnApplicationQuit()
    {
        foreach ( Material[] materials in allMaterials )
        {
            foreach ( Material m in materials )
            {
                m.SetFloat( Shader.PropertyToID( "_Radius" ), 0 );
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        centerMaterial = Resources.LoadAll<Material>("Sektor0") as Material[];
        sector1Material = Resources.LoadAll<Material>("Sektor1") as Material[];
        sector2Material = Resources.LoadAll<Material>("Sektor2") as Material[];
        sector3Material = Resources.LoadAll<Material>("Sektor3") as Material[];
        sector4Material = Resources.LoadAll<Material>("Sektor4") as Material[];
        sector5Material = Resources.LoadAll<Material>("Sektor5") as Material[];
        sector6Material = Resources.LoadAll<Material>("Sektor6") as Material[];



        allMaterials.Add( centerMaterial );
        allMaterials.Add( sector1Material );
        allMaterials.Add( sector2Material );
        allMaterials.Add( sector3Material );
        allMaterials.Add( sector4Material );
        allMaterials.Add( sector5Material );
        allMaterials.Add( sector6Material );

        for ( int s = 0; s < sektoren.Length; s++ )
        {
            //  string newMaterialname = "Sektor" + s + "/PolygonNature_MountainSkybox (Instance)";
            // Material newMaterial = (Material) Resources.Load( newMaterialname, typeof( Material ) );

/*
            List<Material> tempList = new List<Material>();
            foreach ( Material m in allMaterials[s] )
            {
                tempList.Add( m );
            }
            tempList.Add( newMaterial );
            allMaterials[ s ] = tempList.ToArray();*/
            changeToSektorMaterial( sektoren[ s ].transform, s );
        }


    }

    private void changeToSektorMaterial( Transform transformo, int sektorNumber )
    {
        if ( transformo.childCount < 1 ) return;
        foreach ( Transform child in transformo )
        {
            TreeSeasonBehaviour treebehaviour = child.gameObject.GetComponent<TreeSeasonBehaviour>();
            if ( treebehaviour ) changeTreeSeasonMaterialsToSektors( treebehaviour, sektorNumber );
            Renderer r = child.gameObject.GetComponent<Renderer>();
            if ( r != null )
            {
                Material[ ] ms = r.materials;
                if ( ms != null )
                {
                    List<Material> newMaterials = new List<Material>();
                    foreach ( Material material in ms )
                    {
                        string newMaterialname = "Sektor" + sektorNumber + "/" + material.name;
                        Material newMaterial = (Material) Resources.Load( newMaterialname, typeof( Material ) );
                        if ( newMaterial != null ) newMaterials.Add( newMaterial );
                        else { newMaterials.Add( material ); }
                    }
                    child.gameObject.GetComponent<Renderer>().materials = newMaterials.ToArray();
                }
            }

            if ( child.childCount < 1 ) continue;
            changeToSektorMaterial( child, sektorNumber );

        }
    }

    private void changeTreeSeasonMaterialsToSektors( TreeSeasonBehaviour treebehaviour, int sektorNumber )
    {
        Material[ ] seasonMaterials = treebehaviour.seasonMaterials;
        List<Material> newMaterials = new List<Material>();

        foreach ( Material material in seasonMaterials )
        {
            string newMaterialname = "Sektor" + sektorNumber + "/" + material.name;
            Material newMaterial = (Material) Resources.Load( newMaterialname, typeof( Material ) );
            if ( newMaterial != null ) newMaterials.Add( newMaterial );
            else { newMaterials.Add( material ); }
        }
        treebehaviour.seasonMaterials = newMaterials.ToArray();

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
    
