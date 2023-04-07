using UnityEngine;

public class ReflectCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        var contact = col.GetContact(0);
        var inVelocity = col.relativeVelocity;
        
        
        var velocity = Vector3.Reflect(inVelocity, contact.normal);
        col.rigidbody.velocity = velocity / 2f;
        col.transform.up = velocity.normalized;
    }
}
