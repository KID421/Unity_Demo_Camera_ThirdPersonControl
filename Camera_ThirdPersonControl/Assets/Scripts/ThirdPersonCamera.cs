using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float speed;
    public float turn;
    
    private Transform target;
    private float y;

    private void Start()
    {
        Cursor.visible = false;

        target = GameObject.Find("柴柴").transform;
    }

    private void LateUpdate()
    {
        Track();
    }

    private void Track()
    {
        Vector3 posA = target.position;
        posA -= target.forward * 3.5f;
        posA.y = 2f;

        Vector3 posB = transform.position;

        posB = Vector3.Lerp(posB, posA, Time.deltaTime * speed);

        transform.position = posB;

        Quaternion tar = Quaternion.LookRotation(target.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, tar, Time.deltaTime * turn);

        //transform.GetChild(0).Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * -turn, 0, 0);

        //Vector3 eul = transform.GetChild(0).localEulerAngles;
        //eul.x = Mathf.Clamp(transform.GetChild(0).localEulerAngles.x, -10, 10);
        //transform.GetChild(0).localEulerAngles = eul;
    }
}
