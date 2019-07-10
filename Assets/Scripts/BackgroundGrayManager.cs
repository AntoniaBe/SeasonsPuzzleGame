using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGrayManager : MonoBehaviour
{

    public GameObject[ ] backgroundSektoren;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        changeToSektorMaterial();
    }


    private void changeToSektorMaterial()
    {
        for ( int i = 0; i < backgroundSektoren.Length; i++ )
        {
            Material[ ] ms = backgroundSektoren[ i ].gameObject.GetComponent<Renderer>().materials;


            if ( ms != null )
            {
                List<Material> newMaterials = new List<Material>();
                foreach ( Material material in ms )
                {
                    string newMaterialname = "Sektor" + i + "/" + material.name;
                    Material newMaterial = (Material) Resources.Load( newMaterialname, typeof( Material ) );
                    if ( newMaterial != null ) newMaterials.Add( newMaterial );
                    else { newMaterials.Add( material ); }
                }
                backgroundSektoren[ i ].gameObject.GetComponent<Renderer>().materials = newMaterials.ToArray();
            }
        }
    }


    public void changeTextureOnBackground( Texture txt ) {
        foreach ( GameObject sektor in backgroundSektoren )
       {
            sektor.GetComponent<Renderer>().material.mainTexture = txt;
        }


    }

}
