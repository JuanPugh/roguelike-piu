using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followedObject;
    public int DistanceY = 10;
    public int DistanceZ = 15;

    // Update is called once per frame
    void Update()
    {
        if (followedObject != null)
        {
            Vector3 camPos = followedObject.position;
            camPos.y = DistanceY;
            camPos.z -= DistanceZ;
            transform.position = camPos;
        }
    }
}
