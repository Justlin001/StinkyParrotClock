using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public Animator animator;
    public ProgressBarController progressBarController;

    void Start(){

    }

    void Update(){
        
    }

    public void Trigger1()
    {
        animator.SetTrigger("Spin-Fly");
        progressBarController.PauseProgressBar();
    }

    public void Trigger2()
    {
        animator.SetTrigger("Hit-Fly");
        progressBarController.ResumeProgressBar();
    }
}
