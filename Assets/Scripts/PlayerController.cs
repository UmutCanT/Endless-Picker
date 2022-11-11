using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float speed = 5;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            player.PlayerState = PlayerStates.normal;
        }
    }

    void FixedUpdate()
    {
        if (player.PlayerState == PlayerStates.normal)
        {
            //DragMovementX();

            transform.position += MovementZ();
        }
        
        if(player.PlayerState == PlayerStates.bonusRampJump)
        {
            //jumping speed
        }
    }

    private void OnMouseDrag()
    {
        
    }

    Vector3 MovementZ()
    {
        return speed * Time.fixedDeltaTime * Vector3.forward;
    }

    void DragMovementX()
    {
        
    }

    void RampingUpSpeed()
    {

    }
}
