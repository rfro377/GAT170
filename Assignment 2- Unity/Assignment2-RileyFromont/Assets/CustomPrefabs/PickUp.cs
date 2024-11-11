using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact(GameObject go)
    {
        
        Camera.main.GetComponent<PlayerInteractions>().hasRepairTool = true;
        Camera.main.GetComponentInChildren<WeaponScript>(true).gameObject.SetActive(true);

        Destroy(this.gameObject);
        

    }
    

}
