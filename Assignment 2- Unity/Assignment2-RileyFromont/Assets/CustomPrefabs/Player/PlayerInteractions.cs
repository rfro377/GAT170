using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public GameObject jobpad;
    public GameObject currentPad = null;
    public bool ShowJobPad = false;

    public float PadLerpalpha = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowJobPad = !ShowJobPad;
            PadLerpalpha = 0f;
        }

        if (ShowJobPad && currentPad == null)
        {
            currentPad = Instantiate(jobpad,Camera.main.transform,false);
            
            currentPad.transform.Rotate(0, 180f, 0);
        }

        if (ShowJobPad)
        {
            currentPad.transform.localPosition = Vector3.Lerp(new Vector3(0, -0.8f, 0.5f), new Vector3(0, -0.1f, 0.5f), PadLerpalpha);
            GetComponent<PlayerLook>().LockedLook(true);
            GetComponent<PlayerMove>().LockMovement(true);
        }
        if(!ShowJobPad) {

          
            if (PadLerpalpha >= 1f)
            {
                Destroy(currentPad);
            }
            GetComponent<PlayerLook>().LockedLook(false);
            GetComponent<PlayerMove>().LockMovement(false);
            if (currentPad != null)
            {
                currentPad.transform.localPosition = Vector3.Lerp(new Vector3(0, -0.1f, 0.5f), new Vector3(0, -0.8f, 0.5f), PadLerpalpha);
            }
            }

        if(PadLerpalpha >= 1f) {  } else { PadLerpalpha += Time.deltaTime; }
    }
}
