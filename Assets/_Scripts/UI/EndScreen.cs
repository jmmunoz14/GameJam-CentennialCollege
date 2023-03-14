using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    void Awake()
    {
        GameState.Instance.OnGameLose += ShowUI;
    }

    private void ShowUI()
    {
        enabled = true;
    }

}
