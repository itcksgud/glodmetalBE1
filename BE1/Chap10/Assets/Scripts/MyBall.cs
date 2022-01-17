using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();   
    }

    // RigidBody 관련 코드는 FixedUpdate에 작성
    private void FixedUpdate()
    {
        //rigid.velocity = Vector3.right;

        /*if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            Debug.Log(rigid.velocity);
        }*/
    }

    // 답답해서 바꿈
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            Debug.Log(rigid.velocity);
        }
        Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rigid.AddForce(vec, ForceMode.Impulse);
        /*rigid.AddTorque(Vector3.up);*/
    }
    /*private void OnTriggerStay(Collider other)
    {
        if (other.name == "Cube")
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
    }*/

    public void Jump()
    {
        rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
    }
}
