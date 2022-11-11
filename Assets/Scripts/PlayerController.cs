using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float speed = 5;
    [SerializeField] float dragSpeed = 2;
    private Vector3 dragOrigin;
    bool canDrag;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        canDrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(canDrag);
        if(Input.GetMouseButtonDown(0))
        {
            player.PlayerState = PlayerStates.normal;
            canDrag = true;
            dragOrigin = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canDrag = false;
        }
    }

    void FixedUpdate()
    {
        if (player.PlayerState == PlayerStates.normal)
        {
            DragMovementX();

            transform.position += MovementZ();
        }
        
        if(player.PlayerState == PlayerStates.bonusRampJump)
        {
            //jumping speed
        }
    }

    

    Vector3 MovementZ()
    {
        return speed * Time.fixedDeltaTime * Vector3.forward;
    }

    void DragMovementX()
    {
        if (canDrag)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, 0, 0);
            transform.Translate(move, Space.World);

           
        }       
    }

    void RampingUpSpeed()
    {

    }
}
