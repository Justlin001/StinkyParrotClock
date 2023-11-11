using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotController : MonoBehaviour
{
    SceneManager SM;
    SceneManager.State parrotState;

    float lastTouchTime;
        
    // Start is called before the first frame update
    void Start()
    {
        SM = FindObjectOfType<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        parrotState = SM.timerState;

        switch (parrotState)
        {
            case SceneManager.State.notStart:
                SM.StartButtonOnClick();
                break;
            case SceneManager.State.counting:
                SM.StopButtonOnClick();
                break;
            case SceneManager.State.finish:
                break;
            case SceneManager.State.stop:
                SM.PlayButtonOnClick(); 
                break;
        }

    }
}
