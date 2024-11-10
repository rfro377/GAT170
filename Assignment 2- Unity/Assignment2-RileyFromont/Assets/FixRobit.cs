using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FixRobit : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Interact(GameObject go)
    {
        if (!this.GetComponent<Wandering>().isFixed)
        {
            this.GetComponent<Wandering>().isFixed = true;
            FindObjectOfType<GameManager>().robits--;
        }
    }
}
