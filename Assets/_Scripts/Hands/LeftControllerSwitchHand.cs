using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftControllerSwitchHand : MonoBehaviour
{

    public GameObject[] handModels;
    int currentModel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchHand()
    {
        handModels[currentModel].SetActive(true);
        currentModel++;
        if (currentModel > handModels.Length)
        {
            currentModel = 0;
        }
        handModels[currentModel].SetActive(true);
    }
}
