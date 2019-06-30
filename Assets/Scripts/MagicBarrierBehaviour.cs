using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBarrierBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;

    [SerializeField]
    private float minDist;

    private Renderer rend;
    private Color mainColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        mainColor = rend.material.color;
    }

    private void Update()
    {
        mainColor.a = CustomClamp(
            minDist / Vector2.Distance(new Vector2(player.position.x, player.position.z), 
                new Vector2(transform.position.x, transform.position.z)), 
            0.33f,
            1f
        );
        rend.material.color = mainColor;
    }

    private float CustomClamp(float f, float min, float max){
        f = f > max ? max : f;
        f = f < min ? 0 : f;
        return f;
    }
}
