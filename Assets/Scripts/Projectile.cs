using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Set Dynamically")]
    public bool hitGround = false;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            hitGround = true;
        }
    }
}
