using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed;
    public float turn;

    private Rigidbody rig;
    private Animator ani;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Turn();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 move = transform.forward * v + transform.right * h;
        rig.MovePosition(transform.position + move * speed * Time.fixedDeltaTime);
        ani.SetFloat("移動", Mathf.Abs(v) + Mathf.Abs(h));
    }

    private void Turn()
    {
        float x = Input.GetAxis("Mouse X");
        transform.Rotate(transform.up * x * turn * Time.deltaTime);
    }
}
