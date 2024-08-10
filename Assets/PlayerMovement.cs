using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform tf;
    RaycastHit2D hit;
    public LayerMask floor;
    public float speed;
    public float slopeSpeed;
    public float slopeDetecionDistance;

    public Transform front;
    public float frontCehckDistance;


    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {   
        if(!Physics2D.Raycast(front.position, Vector2.right, frontCehckDistance, floor))
        {
            hit = Physics2D.Raycast(tf.position,Vector2.down, slopeDetecionDistance, floor);
            if (hit)
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red);
                float angle = Vector3.Angle(Vector3.up, hit.normal);
                Debug.Log(angle);
                if (angle < 40)
                    rb.AddForce(Vector3.ProjectOnPlane(new Vector3(1, 0, 0), hit.normal).normalized * (speed + slopeSpeed), ForceMode2D.Force);
            }
            else rb.AddForce(Vector3.right * speed, ForceMode2D.Force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(front.position,front.position+new Vector3(frontCehckDistance, 0,0));
    }
}
