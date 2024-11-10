using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float faults = 7;
    public float robits = 2;
    public GameObject t3card;

    public bool faultsfixed = false;
    public bool waterRefilled = false;
    public bool bothRobitsfixed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(faults == 0)
        {
            faultsfixed = true;
        }
        if (robits == 0)
        {
            bothRobitsfixed = true;
            
        }

        if (faultsfixed && waterRefilled && bothRobitsfixed)
        {
            t3card.SetActive(true);
        }
    }

    void End()
    {
        //SceneManager.LoadScene();
    }
}
