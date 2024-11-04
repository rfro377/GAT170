using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public bool is_activated = false;
    public Interactable target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void  Interact(GameObject g)
    {
        is_activated = !is_activated;
        target.Activate(is_activated);
    }
}
