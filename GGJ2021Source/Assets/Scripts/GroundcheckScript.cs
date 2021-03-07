using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundcheckScript : MonoBehaviour
{
    private PlayerMovement pc;

    void Start()
    {
        pc = GetComponent<PlayerMovement>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            pc.setIsGrounded(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        pc.setIsGrounded(false);
    }
}
