using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicController : MonoBehaviour
{
    AudioSource audioSource; //再生したりするためのソース
    AudioClip audioClip; //マイクの情報を設定するためのクリップ
    int minFreq, maxFreq; //周波数
    int recTime = 10; //sec
    string deviceName; // デバイス名

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        //マイクのデバイス名取得
        if (Microphone.devices.Length>0) {
            deviceName = Microphone.devices[0];
            Debug.Log($"deviceName={deviceName}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            RecCheck();
        } else if (Input.GetKeyDown(KeyCode.P)) {
            AudioPlay();
        }
    }
    
    /// <summary>
    /// 録音チェック
    /// </summary>
    void RecCheck() {
        //録音中か確認
        if (Microphone.IsRecording(deviceName)) {
            // 録音中なので停止
            RecEnd();
        } else {
            // 停止中なので録音開始
            RecStart();
        }
    }

    /// <summary>
    /// 録音開始
    /// </summary>
    void RecStart() {
        Debug.Log("---- 録音開始 -----");
        // 音が再生されてれば停止
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }

        // 最大・最小周波数を取得
        Microphone.GetDeviceCaps(deviceName, out minFreq, out maxFreq);
        Debug.Log($"------minFreq = {minFreq}, maxFreq = {maxFreq}");

        // オーディオクリップにマイク情報をセット
        audioClip = Microphone.Start(deviceName, true, recTime, maxFreq);
    }

    /// <summary>
    /// 録音停止
    /// </summary>
    void RecEnd() {
        Debug.Log("---- 録音停止 -----");
        Microphone.End(deviceName);
    }


    /// <summary>
    /// オーディオ再生
    /// </summary>
    void AudioPlay() {
        Debug.Log("---- オーディオ再生 -----");

        // 録音中なら停止
        if (Microphone.IsRecording(deviceName)) {
            RecEnd();
        }

        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
