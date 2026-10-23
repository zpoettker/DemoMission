using System.Collections;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;
    static public bool cleanShot = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (!Goal.goalMet)
            {
                Goal.cleanShot = !other.GetComponent<Projectile>().hitGround;
            }
            Goal.goalMet = true;
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}
