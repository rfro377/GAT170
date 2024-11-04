using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class Gravity : MonoBehaviour
{
    public BoxCollider gravfield;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
   
        if(other.gameObject.GetComponent<Rigidbody>() != null)
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if (other.gameObject.GetComponent<PlayerMove>() != null)
        {
            other.gameObject.GetComponent<PlayerMove>().Gravity_coeff = -1f;
        }

    }

    private void OnCollisionExit(Collision other)
    {
      
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        if (other.gameObject.GetComponent<PlayerMove>() != null)
        {
            other.gameObject.GetComponent<PlayerMove>().Gravity_coeff = -9.81f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Camera.main.GetComponent<PlayerMove>() != null)
        {
            if (gravfield.bounds.Contains(Camera.main.transform.position))
            {
                Camera.main.gameObject.GetComponent<PlayerMove>().Gravity_coeff = -1f;
                Camera.main.gameObject.GetComponent<PlayerMove>().jump_height = 5f;
            }
            else {
                Camera.main.gameObject.GetComponent<PlayerMove>().Gravity_coeff = -9.81f;
                Camera.main.gameObject.GetComponent<PlayerMove>().jump_height = 1f;
            }
        }
    }
}
