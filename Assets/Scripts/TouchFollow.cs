using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFollow : MonoBehaviour
{
    public GameObject[] pivot;
    public float springRange;
    private float velLine = 1.0f;

    public float maxVel;

    Vector3 dis;
    Vector3 newDis;
    Rigidbody2D rb;

    private bool inRope = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
        //newDis = dis;
        //pivot.position = transform.position;
    }

    private void OnMouseDrag()
    {
        if (rb.velocity.x == 0.0f)
        {
            rb.gravityScale = 0f;
        }

        if (transform.position.x <= 20 || transform.position.x >= 430)
        {
            transform.position = transform.position;
        }

        if (transform.position.y <= 230 || transform.position.y >= 20)
        {
            transform.position = transform.position;
        }

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dis = pos;
        dis.z = 0;
        newDis = dis;

        if (transform.position.x <=50  && transform.position.x >= 40)
        {
            inRope = true;
            pivot[0].transform.position = transform.position;
            dis = pos - pivot[0].transform.position;
            if (dis.magnitude > springRange)
            {
                dis = dis.normalized * springRange;
            }
            newDis = dis + pivot[0].transform.position;
            Debug.Log(pivot);
        }
        else if (transform.position.x >= 400 && transform.position.x <= 410)
        {
            inRope = true;
            pivot[1].transform.position = transform.position;
            dis = pos - pivot[1].transform.position;
            if (dis.magnitude > springRange)
            {
                dis = dis.normalized * springRange;
            }
            newDis = dis + pivot[1].transform.position;
            Debug.Log(pivot);
        }
        else
        {
            dis = pos;
            dis.z = 0;
            newDis = dis;
        }
        transform.position = newDis;
    }

    private void OnMouseUp()
    {
        if (inRope == true)
        {
            rb.gravityScale = 5;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = -dis.normalized * maxVel / (springRange / 20); // se va hacia el 0,0,0 con una velocidad moderada
        }
        
        inRope = false;
        //rb.velocity = Vector3.zero;
    }

}

/*Para el drag en cualquier parte. 
 * IDEA: decirle que cuando el objeto llegue a cierta posicion en  "X" 
 * (Vector3 newPositionDrag = GetTransform.position) 
 * hacer el drag apartir de esa posicion*/
