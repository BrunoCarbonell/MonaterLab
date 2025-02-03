using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform movePoint;
    public FixedJoystick joystick;
    private Rigidbody rb;
    public Animator anim;
    public GameObject model;
    public GameManager gm;
    public bool moving = false;

    public LayerMask canStopMovement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movePoint.parent = null;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("vertica: " + joystick.Vertical + "     horizontal:" + joystick.Horizontal);
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            
        if(transform.position != movePoint.position)
        {
            moving = true;
        }
        else
        {
            moving=false;
        }

        anim.SetBool("Moving", moving);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if(Mathf.Abs(joystick.Horizontal) >= 0.5f)
            {
                if(Physics.OverlapSphere(movePoint.position + new Vector3(joystick.Horizontal, 0f, 0f), .2f, canStopMovement).Length < 1)
                {
                    if(joystick.Horizontal > 0)
                        movePoint.position += new Vector3(1f, 0f, 0f);
                    else
                        movePoint.position += new Vector3(-1f, 0f, 0f);
                    //transform.LookAt(movePoint.position);
                }
            }
            
             if (Mathf.Abs(joystick.Vertical) >= 0.5f)
            {
                if (Physics.OverlapSphere(movePoint.position + new Vector3(0f, 0f, joystick.Vertical), .2f, canStopMovement).Length < 1)
                {
                    if(joystick.Vertical > 0)
                        movePoint.position += new Vector3(0f, 0f, 1f);
                    else
                        movePoint.position += new Vector3(0f, 0f, -1f);
                    //transform.LookAt(movePoint.position);

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            gm.EndGame();
            print("Parabens!");
        }
    }
}
