using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Player player;
    float speed = 5f;
    float dragSpeed = 0.15f;
    private Vector3 dragOrigin;
    bool canDrag;
    bool canClick = true;
    Rigidbody rb;

    public bool CanDrag { get => canDrag; set => canDrag = value; }
    public bool CanClick { get => canClick; set => canClick = value; }

    // Start is called before the first frame update
    void Start()
    {
        canDrag = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canClick)
        {
            player.ChangeStateToNormal();
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
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            transform.position += MovementZ();
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
        speed = 10;
    }
}
