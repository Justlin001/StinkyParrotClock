using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Slider progressBar;
    public Text subtitleText;
    public Image imageComponent;


    public Animator animator;
    private int triggerIndex = 0;
    private string[] triggerNames = { "Attack-Spin", "Fly-Clicked", "Hit-Fly" }; // 存储trigger名称的数组

    // timer
    public float duration = 30;

    float countTime = 0;



    public enum State{
        notStart,
        counting,
        finish,
        stop
    }

    public State timerState = State.notStart;



    private void Start()
    {
    }

    void Update(){

        switch(timerState){
                case State.notStart:
                break;
                case State.counting:
                countTime += Time.deltaTime;

                // 更新进度条的值
                float progress = countTime / (duration * 60f);
                progressBar.value = progress;

                // 检查是否时间到达30
                if (countTime >= duration*60f){
                    EndButtonOnClick();
                }
                break;
                case State.finish:
                timerState = State.notStart;
                countTime = 0;
                break;
                case State.stop:
                break;
            }
    }

    public void StartButtonOnClick(){
        // animator trigger:
        animator.SetTrigger("Attack-Spin");

        // 设置字幕文本
        // subtitleText.text = "开始攻击动画！";

        // 切换图片为动画1对应的图片
        imageComponent.sprite = Resources.Load<Sprite>("Sprites/002");

        // change state
        timerState = State.counting;
    }

    public void StopButtonOnClick(){
        if(timerState == State.counting){
            Debug.Log("Stop！");
        // animator trigger:
        animator.SetTrigger("Fly-Clicked");
        // 切换图片为动画2对应的图片
        imageComponent.sprite = Resources.Load<Sprite>("Sprites/003");
        // change state
        timerState = State.stop;
        }
    }

    public void PlayButtonOnClick(){
       switch(timerState){
                case State.notStart:
                break;
                case State.counting:
                break;
                case State.finish:
                break;
                case State.stop:
                    Debug.Log("Play!");
                    // 切换图片为动画1对应的图片
                    imageComponent.sprite = Resources.Load<Sprite>("Sprites/002");

                    animator.SetTrigger("Hit-Fly");
                    timerState = State.counting;
                break;
            }
    }

    public void EndButtonOnClick(){
        // trigger end animation: 
        animator.SetTrigger("Fly-Roll");
        // change state:
        timerState = State.finish;
    }



    public void OnButtonClick()
    {
        // 获取当前索引对应的trigger名称
        string currentTriggerName = triggerNames[triggerIndex];

        // 触发当前索引对应的trigger
        animator.SetTrigger(currentTriggerName);
        // animator.SetTrigger("Idle-Spin");

        // 增加trigger索引
        triggerIndex++;

        // 如果触发索引超过trigger的数量，重置为0
        if (triggerIndex >= triggerNames.Length)
        {
            triggerIndex = 0;
        }
    }
}