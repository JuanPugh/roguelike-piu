using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followedObject;

    // Update is called once per frame
    void Update()
    {
        if (followedObject != null)
        {
            Vector3 camPos = followedObject.position;
            camPos.z = -10;
            transform.position = camPos;
        }
    }
}
