using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MANDFRED_script : MonoBehaviour {

    public float Speed;
    public float jumpPower;
    public bool isTouchingGround;
    public GameObject[] jumpRayOrigins;
    public float distToGround;
    public float slowDownSpeed;
    public float floatPower;
    public float fallPower;
    public float debugAxis;
    public bool debug1;
    public bool debug2;
    public bool debug3;
    public bool debug4;
    


    Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        jumpRayOrigins = GameObject.FindGameObjectsWithTag("JumpRayOrigin");

    }
	
	// Update is called once per frame
	void Update () {
        //Debug
        debugAxis = Input.GetAxis("Horizontal");
        debug1 = Input.GetKey("a");
        debug2 = Input.GetKey("d");

        checkForColisions();
        Movement();
    }

    void checkForColisions()
    {
        // Vi ser på om mandfred står på jorden
        foreach (GameObject origin in jumpRayOrigins)
        {
            RaycastHit2D downDist = Physics2D.Raycast(origin.transform.position, new Vector2(0, -1));
            distToGround = downDist.distance;
            if (distToGround <= 0.02)
            {
                isTouchingGround = true;
                break;
            }
            else
            {
                isTouchingGround = false;
            }
        }
    }


    void Movement()
    {
        // Horizontal bevægelse
        if (isTouchingGround) // Hvis man ikke bevæger sig på jorden, stopper man helt.
        {
            if (Input.GetKey("a"))
            {
                rbody.velocity = new Vector2(-Speed, 0);
            }
            else if (Input.GetKey("d"))
            {
                rbody.velocity = new Vector2(Speed, 0);
            }
            else //hvis hværken a eller d trykkes, stopper man helt.
            {
                rbody.velocity = new Vector2(0, 0);
            }
        }
        else if (Input.GetKey("a")) //hvis man ikke bevæger sig i luften, så beholder man en smule horizontal inerti. 
        {
            rbody.velocity = new Vector2(-Speed, rbody.velocity.y);
        }
        else if (Input.GetKey("d")) //hvis man ikke bevæger sig i luften, så beholder man en smule horizontal inerti. 
        {
            rbody.velocity = new Vector2(Speed, rbody.velocity.y);
        }
        else //hvis man ikke bevæger sig i luften, så beholder man en smule horizontal inerti. 
        {
            rbody.velocity = new Vector2(0, rbody.velocity.y);
        }

        // Hop
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("w"))
        {
            if (isTouchingGround)
            {
                rbody.AddForce(new Vector2(0, 100 * jumpPower));
            }
        }
        if (!isTouchingGround) // forøg/forminsk faldehastighed
        {
            if (Input.GetKey("s"))
            {
                rbody.AddForce(new Vector2(0, fallPower));
            }
            else if (Input.GetKey(KeyCode.Space) || Input.GetKey("w"))
            {
                rbody.AddForce(new Vector2(0, floatPower));
            }          
        }
    }


}
