using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    float h, v;
    Rigidbody rigid;
    Vector3 vec;
    public int jumpPower;
    bool isJump;
    public int itemCount = 0;
    AudioSource sound;
    public GameManagerLogic manager;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {

        //점프
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {
        //이동
        h = Input.GetAxisRaw("Horizontal") * 0.1f;
        v = Input.GetAxisRaw("Vertical") * 0.1f;
        vec = new Vector3(h, 0, v);
        rigid.AddForce(vec, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            sound.Play();
            itemCount++;
            manager.GetItem(itemCount);
        }
        else if (other.tag == "Goal")
        {
            Debug.Log("zz");
            if (itemCount == manager.totalItemCount)
            {
                SceneManager.LoadScene(manager.stage + 1);
            }
            else
            {
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
