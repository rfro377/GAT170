using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    T1,
    T2,
    T3
};

public class T1_keypadpickup : PickUp
{
    public CardType cardtype = CardType.T1;

    public Mesh t1;
    public Mesh t2;
    public Mesh t3;
    // Start is called before the first frame update
    void Start()
    {
        Mesh result = t1;
        switch (cardtype)
        {
            
            case CardType.T1:
            result = t1;
                
            break;
            case CardType.T2:
            result = t2;
                this.GetComponentInChildren<MeshFilter>().transform.localScale = new Vector3(2.44504094f, 4.4295001f, 0.328372627f);
                break;
            case CardType.T3: 
            result = t3;
                this.GetComponentInChildren<MeshFilter>().transform.localScale = new Vector3(2.44504094f, 4.4295001f, 0.328372627f);
                break;
        }
        
        this.GetComponentInChildren<MeshFilter>().mesh = result;
        this.GetComponentInChildren<MeshCollider>().sharedMesh = result;

    }

    public override void Interact(GameObject g)
    {

        switch (cardtype)
        {
            case CardType.T1:
                Camera.main.gameObject.GetComponent<PlayerInteractions>().T1access = true;
                
                break;
            case CardType.T2:
                Camera.main.gameObject.GetComponent<PlayerInteractions>().T2access = true;
                
                break;
            case CardType.T3:
                Camera.main.gameObject.GetComponent<PlayerInteractions>().T3access = true;
                
                break;

        }

        Destroy(this.gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
