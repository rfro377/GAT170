using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public ParticleSystem hit_effect;   
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

        hit_effect = Instantiate(hit_effect);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position,this.transform.forward,out hit,2f);

        if (hit.collider != null)
        {
           hit_effect.transform.position = hit.point;
            hit_effect.Play();

            if(hit.transform.GetComponent<Weldpoint>() != null)
            {
                hit.transform.GetComponent<Weldpoint>().health -= 10;
            }
        }

    }
}
