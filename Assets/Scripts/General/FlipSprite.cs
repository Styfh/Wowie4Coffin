using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{

    private SpriteRenderer sr;

    private Vector2 posPrevFrame;
    private Vector2 posCurrentFrame;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        posCurrentFrame = transform.position;

        if(posCurrentFrame.x < posPrevFrame.x)
        {
            sr.flipX = true;
        }
        else if(posCurrentFrame.x > posPrevFrame.x)
        {
            sr.flipX = false;
        }

        posPrevFrame = posCurrentFrame;
    }
}
