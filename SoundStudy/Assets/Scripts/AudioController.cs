using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        //NOTE: 音再生テスト
        // audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーで再生・停止をコントロール
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (audioSource.isPlaying == false) { //未再生
                audioSource.Play();
            } else { //再生実行中
                audioSource.Pause(); // 一時停止
                //audioSource.Stop(); // 完全停止
            }
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            audioSource.volume += 0.001f;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            audioSource.volume -= 0.001f;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            audioSource.pitch -= 0.001f;
            if (audioSource.pitch < 0) audioSource.pitch = 0;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            audioSource.pitch += 0.001f;
            if (audioSource.pitch > 2) audioSource.pitch = 2;
        }
    }
}
