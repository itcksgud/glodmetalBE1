using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float rotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Player")
        {
            
            /*Player ball = other.GetComponent<Player>();
            ball.itemCount++;
            AudioSource sound = other.GetComponent<AudioSource>();*/
            /*sound.Play();*/
            gameObject.SetActive(false);

        }
    }
}
