using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerEffects : MonoBehaviour
{
    public ParticleSystem[] particles;
    public bool isOn = false;

    public BoxCollider boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        isOn = boxcollider.bounds.Contains(Camera.main.transform.position);
        if (isOn)
        {
            foreach (var particle in particles)
            {
                particle.Play();
            }
        }
        else
        {
            foreach (var particle in particles)
            {
                particle.Stop();
            }
        }
    }
}
