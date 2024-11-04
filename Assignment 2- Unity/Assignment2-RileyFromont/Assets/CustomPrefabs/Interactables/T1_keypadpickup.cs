using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1_keypadpickup : Pickup
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact(GameObject g)
    {
        Camera.main.gameObject.GetComponent<PlayerInteractions>().T1access = true;
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
