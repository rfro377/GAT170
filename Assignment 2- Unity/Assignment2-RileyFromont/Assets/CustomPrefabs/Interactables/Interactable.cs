using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{
    public SphereCollider InteractCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Overridden by  Child Scripts Dependant on Behaviour
    public virtual void Interact(GameObject go) { }
}
