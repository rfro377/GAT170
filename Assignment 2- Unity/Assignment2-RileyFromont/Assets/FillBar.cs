using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    public float HeightALpha = 0;
    public float maxHeight = 0.5f;
    public float filltime = 3;
    public bool isFilling= false;
        // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x,0f);
    }
    public void Fill()
    {
        isFilling = true;
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(HeightALpha, 0,1f);
        if (isFilling)
        {
            HeightALpha += Time.deltaTime / filltime;
            GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, Mathf.Lerp(0f,maxHeight,HeightALpha));
        }

        if(HeightALpha == 1)
        {
            FindObjectOfType<GameManager>().waterRefilled = true;
        }
    }
}
