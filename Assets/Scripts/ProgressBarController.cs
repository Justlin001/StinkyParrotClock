using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public Animator animator;
    public Slider progressBar;

    private bool isPaused = false;

    void Start()
    {
        progressBar.minValue = 0;
        progressBar.maxValue = 1;
    }

    void Update()
    {
        if (!isPaused)
        {
            float progress = animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1;
            progressBar.value = progress;
        }
    }

    public void PauseProgressBar()
    {
        isPaused = true;
    }

    public void ResumeProgressBar()
    {
        isPaused = false;
    }
}
