using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIValue : MonoBehaviour
{
    public string value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (value != null)
        {

            switch (value)
            {
                case "T1":
                    if (Camera.main.GetComponent<PlayerInteractions>().T1access)
                    {
                        this.GetComponent<TMPro.TMP_Text>().text = "ACCESS GRANTED";
                    }
                    else { this.GetComponent<TMPro.TMP_Text>().text = "ACCESS DENIED"; }
                    break;
                default:
                    this.GetComponent<TMPro.TMP_Text>().text = "NULL EXCEPTION";
                    break;
            }
        }
    }
}
