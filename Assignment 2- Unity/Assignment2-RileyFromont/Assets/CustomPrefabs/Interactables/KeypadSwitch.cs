using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            this.GetComponentInChildren<Image>().color = Color.green;
        }
        else
        {
            //Play denied noise
            this.GetComponentInChildren<Image>().color = Color.red;
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
