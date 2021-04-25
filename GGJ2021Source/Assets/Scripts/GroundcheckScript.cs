using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundcheckScript : MonoBehaviour
{
    private PlayerMovement pc;

    void Start()
    {
        pc = transform.parent.GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            pc.SetIsGrounded(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pc.SetIsGrounded(false);
    }
}
