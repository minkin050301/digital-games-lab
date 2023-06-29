using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootPlacement : MonoBehaviour
{
    Animator anim;
    public LayerMask layerMask;
    public LayerMask movementMask;

    [Range(0, 1f)]
    public float distanceToGround;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex) {
        if (anim) {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, anim.GetFloat("IKLeftFootWeight"));
            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, anim.GetFloat("IKLeftFootWeight"));
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, anim.GetFloat("IKRightFootWeight"));
            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, anim.GetFloat("IKRightFootWeight"));

            // left foot
            RaycastHit hit;
            Ray ray = new Ray(anim.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, distanceToGround + 1f, layerMask)) {
                //if (hit.transform.tag == "Walkable") {
                    Vector3 footPosition = hit.point;
                    footPosition.y += distanceToGround;
                    anim.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
                    Vector3 forward = Vector3.ProjectOnPlane(transform.forward, hit.normal);
                    anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.TransformDirection(forward), hit.normal));
                //}
            }

            // right foot
            ray = new Ray(anim.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, distanceToGround + 1f, layerMask)) {
                //if (hit.transform.tag == "Walkable") {
                    Vector3 footPosition = hit.point;
                    footPosition.y += distanceToGround;
                    anim.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
                    Vector3 forward = Vector3.ProjectOnPlane(transform.forward, hit.normal);
                    anim.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.TransformDirection(forward), hit.normal));
                //}
            }
        }
    }
}
