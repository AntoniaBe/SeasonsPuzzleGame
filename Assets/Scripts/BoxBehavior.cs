using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    [SerializeField]

    private void Start(){
        
    }

    private void Update(){
        
    }

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Key")
        {
            gameObject.transform.Find("SM_Prop_Chest_Wood_Lid").GetComponent<Animator>().Play("Open");
        }
    }
}