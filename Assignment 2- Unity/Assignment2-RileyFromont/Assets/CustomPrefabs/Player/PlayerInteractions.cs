using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{

    public GameObject jobpad;
    public GameObject repairtool;
    private GameObject currentPad = null;
    public bool ShowJobPad = false;
    public float maxInteractDistance=2f;
    public float PadLerpalpha = 0;

    public LayerMask interactionlayer;

    public InputActionReference interact;
    public InputActionReference tab;
    public InputActionReference attack;

    public bool T1access = false;
    public bool T2access = false;
    public bool T3access = false;
    public bool hasRepairTool = false;
    // Start is called before the first frame update
    void Start()
    {
      repairtool =  GetComponentInChildren<WeaponScript>(true).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        JobPadHandle();
        InteractHandle();
        RepairToolHandle();
    }


    private void InteractHandle()
    {
        if (interact.action.triggered)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, maxInteractDistance, interactionlayer))
            {
                
                Collider hitobj = hit.collider;
                if (hitobj.GetComponent<Interactable>() != null)
                {
                    hitobj.GetComponent<Interactable>().Interact(this.gameObject);
                }
            }
        }
    }
    private void JobPadHandle()
    {
        if (tab.action.triggered)
        {
            ShowJobPad = !ShowJobPad;
            PadLerpalpha = 0f;
        }

        if (ShowJobPad && currentPad == null)
        {
            currentPad = Instantiate(jobpad, Camera.main.transform, false);

            currentPad.transform.Rotate(0, 180f, 0);
        }

        if (ShowJobPad)
        {
            currentPad.transform.localPosition = Vector3.Lerp(new Vector3(0, -0.8f, 0.5f), new Vector3(0, -0.1f, 0.5f), PadLerpalpha);
            GetComponent<PlayerLook>().LockedLook(true);
            GetComponent<PlayerMove>().LockMovement(true);
        }
        if (!ShowJobPad)
        {


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

        if (PadLerpalpha >= 1f) { } else { PadLerpalpha += Time.deltaTime; }
    }

    public void RepairToolHandle()
    {
        if (hasRepairTool)
        {
            if (attack.action.IsPressed())
            {
                //Activate RepairTool
                repairtool.GetComponentInChildren<ParticleSystem>(true).gameObject.SetActive(true);
                repairtool.GetComponent<WeaponScript>().Shoot();
            }
            else
            {
                //Deactivate RepairTool
                repairtool.GetComponentInChildren<ParticleSystem>(true).gameObject.SetActive(false);
            }
        }
    }
    public bool hasAccess(string reqaccess)
    {
        switch (reqaccess)
        {
            case "T1":
                return T1access;
            case "T2":
                return T2access;
            case"T3":
                    return T3access;
            default:
                return false;
        }
    }
}
