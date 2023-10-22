using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class FollowingCamera : MonoBehaviour
// {
//     [SerializeField] private Camera camera;

//     void LateUpdate()
//     {
//         camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
//     }
// }

// 2й вариант
public class FollowingCamera : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;

    void LateUpdate()
    {
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y, cameraTransform.position.z);
    }
}