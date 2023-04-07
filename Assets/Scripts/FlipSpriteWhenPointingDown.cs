using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSpriteWhenPointingDown : MonoBehaviour
{
    private void Update()
    {
        var signedAngle = Vector2.SignedAngle(Vector2.up, transform.up);
        var transformUpIsPointingUp = signedAngle > -90 && signedAngle < 90;
        var spriteTransform = transform;
        spriteTransform.localScale = new Vector3(
            spriteTransform.localScale.x,
            transformUpIsPointingUp ? 1 : -1,
            spriteTransform.localScale.z);
    }
}
