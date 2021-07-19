using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScaleController : MonoBehaviour
{
    public AudioClip do1;
    public AudioClip re;
    public AudioClip mi;
    public AudioClip fa;
    public AudioClip so;
    public AudioClip ra;
    public AudioClip si;
    public AudioClip do2;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        // テスト
        // PlayDo1();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            PlayScale(do1);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            PlayScale(re);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            PlayScale(mi);
        }else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            PlayScale(fa);
        }else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            PlayScale(so);
        }else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            PlayScale(ra);
        }else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            PlayScale(si);
        }else if (Input.GetKeyDown(KeyCode.Alpha8)) {
            PlayScale(do2);
        }
    }

    /// <summary>
    /// 渡したaudio clipがなる
    /// </summary>
    /// <param name="audioClip"></param>
    void PlayScale(AudioClip audioClip) {
        // 音を管理する
        // audioSource.clip = audioClip;
        // audioSource.playOnAwake = false;
        // audioSource.Play();

        // 1回鳴らしてあとは管理しない
        audioSource.PlayOneShot(audioClip);
    }

    /// <summary>
    /// サンプル
    /// </summary>
    void PlayDo1() {
        audioSource.clip = do1;
        audioSource.playOnAwake = false;
        audioSource.Play();
    }

}
