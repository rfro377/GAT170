using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Vector3 init_pos;
    public Vector3 target_pos;

    float LerpAlpha = 0;
    public bool isActivated= false;
    // Start is called before the first frame update
    public override void Activate(bool activated)
    {
        isActivated = activated;
        LerpAlpha = 0;
        GetComponentInChildren<AudioSource>().Play();
    }
    void Start()
    {
        init_pos = this.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        LerpAlpha += Time.deltaTime;

        if(LerpAlpha > 1f) { LerpAlpha = 1f; }
        if (isActivated)
        {
            this.gameObject.transform.localPosition = Vector3.Lerp(init_pos, init_pos +target_pos, LerpAlpha);
        }
        else 
        { 
            this.gameObject.transform.localPosition = Vector3.Lerp(init_pos + target_pos, init_pos, LerpAlpha); 
        }
    }
}
