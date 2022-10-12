using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator bodyAnimator;

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    public float moveSpeed = 2.0f;
    private RaycastHit2D hit;
    private string[] raycastLayers;
    private LayerMask raycastMask;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        raycastLayers = new string[] { "Blocking", "Actor" };
        raycastMask = LayerMask.GetMask(raycastLayers);
        
    }


    private void FixedUpdate()
    {
        RaycastHit2D hit_x;
        RaycastHit2D hit_y;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(h != 0 || v != 0)
        {
            bodyAnimator.SetBool("isMoving", true);
        }
        else
        {
            bodyAnimator.SetBool("isMoving", false);
        }
            

        moveDelta = new Vector3(h, v, 0);
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if(moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        hit_x = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Vector2.right*h, 0.3f, raycastMask);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), new Vector2(moveDelta.x, 0) * 2, Color.green);
        if (hit_x.transform == null)
        {
            transform.Translate(moveSpeed * moveDelta.x * Time.deltaTime, 0, 0);
        }


        hit_y = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Vector2.up*v, 0.15f, raycastMask);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), new Vector2(moveDelta.y, 0) * 2, Color.green);
        if (hit_y.transform == null)
        {
        transform.Translate(0, moveSpeed * moveDelta.y * Time.deltaTime, 0);
        }
    }
}
