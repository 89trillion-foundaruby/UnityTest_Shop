using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace Script
{
    public class CountDown : MonoBehaviour
    {
        public int totalTime = 10000;
        [SerializeField] public Text CountDownTime;

        public void Awake()
        {
            CountDownTime.text = string.Format("Refresh time : {0:D0}:{1:D1}:{2:D2}", totalTime / 3600, totalTime % 3600 / 60,
                totalTime % 3600 % 60);
            StartCoroutine(CountDownStart());
        }

        //开始倒计时
        public IEnumerator CountDownStart()
        {
            while (totalTime > 0)
            {
                yield return new WaitForSeconds(1);
                totalTime--;
                CountDownTime.text = string.Format("Refresh time : {0:D0}:{1:D1}:{2:D2}", totalTime / 3600, totalTime % 3600 / 60,
                    totalTime % 3600 % 60);
            }
        }
    }
    
}