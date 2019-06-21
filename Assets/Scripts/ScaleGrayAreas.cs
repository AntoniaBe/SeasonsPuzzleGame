using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGrayAreas : MonoBehaviour
{

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

    private List<Material[]> allMaterials = new List<Material[]>();

    public int sectorToChange;

    [SerializeField]
    private float timeToLerp;
    private float currentTime=0;
    private bool enableANewSector;

    public void changeGrayAreaToColor(int seasonindex )
    {
        currentTime += Time.deltaTime;
        foreach ( Material m in allMaterials[sectorToChange] )
        {
            m.SetFloat( Shader.PropertyToID( "_Radius"), Mathf.Lerp( 0, 100, currentTime / timeToLerp ));
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

    }

    public void enableSector( int sectorindex ) {
        enableANewSector = true;
        sectorToChange = sectorindex;

    }

    // Update is called once per frame
    void Update()
    {
        if ( enableANewSector ) changeGrayAreaToColor( sectorToChange );
        else { currentTime = 0; }
    }
}
