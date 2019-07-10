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

        // Beginnt bei 1 da der Sektor 0 nichts mit den hintergrundebnen zu tun hat.
        for ( int i = 0; i < backgroundSektoren.Length; i++ )
        {
            Material[ ] ms = backgroundSektoren[ i ].gameObject.GetComponent<Renderer>().materials;


            if ( ms != null )
            {
                List<Material> newMaterials = new List<Material>();
                foreach ( Material material in ms )
                {
                    // Beginnt bei 1 da der Sektor 0 nichts mit den hintergrundebnen zu tun hat.
                    int sektornummer = i + 1;
                    string newMaterialname = "Sektor" + sektornummer + "/" + material.name;
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
