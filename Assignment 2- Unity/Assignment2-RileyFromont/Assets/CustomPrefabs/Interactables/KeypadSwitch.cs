using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadSwitch : Switch
{
    public string requiredAccess;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact(GameObject g)
    {
        if (CheckAccess()) {
            base.Interact(g);
        }
        else
        {
            //Play denied noise
        }
    }

    public bool CheckAccess()
    {
        return Camera.main.gameObject.GetComponent<PlayerInteractions>().hasAccess(requiredAccess);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
