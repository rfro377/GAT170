using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlaclHole : MonoBehaviour
{
    public SphereCollider zone;
    // Start is called before the first frame update
    void Start()
    {
        zone = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zone != null)
        {
           if(zone.bounds.Contains(Camera.main.transform.position))
            {
                FindObjectOfType<SceneLoader>().SceneLoad(3);
            }
        }
    }
}
