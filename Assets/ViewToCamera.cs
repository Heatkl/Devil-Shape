using UnityEngine;

public class ViewToCamera : MonoBehaviour
{
    Transform cam;
    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void Update()
    {
        if (cam != null)
        {
            transform.LookAt(cam.position);
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        }
    }
}
