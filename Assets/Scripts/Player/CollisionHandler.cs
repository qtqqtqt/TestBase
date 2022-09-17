using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    bool inBase;
    public bool InBase { get {  return inBase; } }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BaseGround"))
        {
            inBase = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BaseGround"))
        {
            inBase = false;
        }
    }
}
