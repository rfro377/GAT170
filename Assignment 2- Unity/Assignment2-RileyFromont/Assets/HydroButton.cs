using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroButton : Interactable
{
    public FillBar FillBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact(GameObject go)
    {

        FillBar.Fill();
        
    }
}
