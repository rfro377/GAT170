using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hitinfo;
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitinfo,100f);

            if(hitinfo.transform != null)
            {
                //if (hitinfo.transform.gameObject.GetComponent<Break>() != null)
              //  {
                    //shoot;
             //   }
            }


            
        }
    }
}
