using System.Collections;
using UnityEngine;

public class SlingshotBand : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Transform leftArm;
    public Transform rightArm;

    private LineRenderer line;
    private Slingshot slingshot;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        slingshot = GetComponent<Slingshot>();
        line.positionCount = 3;
    }

    void LateUpdate()
    {
        Vector3 pouchPos = slingshot.launchPos;
        if (slingshot.aimingMode && slingshot.projectile != null)
        {
            pouchPos = slingshot.projectile.transform.position;
        }

        line.SetPosition(0, ArmTip(leftArm));
        line.SetPosition(1, pouchPos);
        line.SetPosition(2, ArmTip(rightArm));
    }

    Vector3 ArmTip(Transform arm)
    {
        return arm.position + arm.up * arm.lossyScale.y * 0.5f;
    }
}
