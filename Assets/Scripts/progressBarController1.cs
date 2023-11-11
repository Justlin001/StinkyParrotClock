using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressBarController1 : MonoBehaviour
{
    public Material progressBarMaterial; // 引用进度条的Material
    public float fillAmount = 1f; // 进度条的填充量，范围从0到1

    void Update()
    {
        // 在Update函数中更新进度条的填充效果
        fillAmount -= Time.deltaTime * 0.1f; // 0.1f是填充速度的调整值
        fillAmount = Mathf.Clamp01(fillAmount); // 限制填充量在0到1之间

        // 将填充量传递给Shader，控制进度条的填充效果
        progressBarMaterial.SetFloat("_FillAmount", fillAmount);
    }
}