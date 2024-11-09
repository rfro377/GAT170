using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weldpoint : MonoBehaviour
{
    public float health = 60;
    private SphereCollider weldcollider;
    // Start is called before the first frame update
    void Start()
    {
        weldcollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(health < 0) { Fix(); };
    }
    public void Fix()
    {
        FindObjectOfType<GameManager>().faults--;
        this.gameObject.SetActive(false);
    }

}
