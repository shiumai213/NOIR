using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource bgmAudioSource;
    [SerializeField] private AudioClip[] bgmclips;

    [SerializeField] public AudioSource seAudioSource;

    // 今流しているBGMのインデックス（未再生は -1）
    private int currentBgmIndex = -1;

    // ===== BGM =====
    public void PlayBGMByIndex(int index)
    {
        if (bgmAudioSource == null)
        {
            Debug.LogError("PlayBGMByIndex: bgmAudioSource が未アサインです。インスペクタで設定してね。");
            return;
        }

        if (index < 0 || bgmclips == null || index >= bgmclips.Length)
        {
            Debug.LogWarning($"PlayBGMByIndex: index {index} が範囲外。BGM停止します。");
            StopBGM();
            return;
        }

        var clip = bgmclips[index];
        if (clip == null)
        {
            Debug.LogWarning($"PlayBGMByIndex: bgmclips[{index}] が null。BGM停止します。");
            StopBGM();
            return;
        }

        // すでに同じ曲を再生中なら何もしない
        if (currentBgmIndex == index && bgmAudioSource.isPlaying)
        {
            return;
        }

        bgmAudioSource.Stop();
        bgmAudioSource.clip = clip;
        bgmAudioSource.loop = true; // ループでOK
        bgmAudioSource.Play();

        currentBgmIndex = index;
    }

    public void StopBGM()
    {
        if (bgmAudioSource == null) return;
        bgmAudioSource.Stop();
        bgmAudioSource.clip = null;
        currentBgmIndex = -1;
    }

    // ===== SE =====
    public void PlaySE(AudioClip clip)
    {
        if (clip == null) return;
        if (seAudioSource == null)
        {
            Debug.LogError("PlaySE: seAudioSource が未アサインです。インスペクタで設定してね。");
            return;
        }
        seAudioSource.PlayOneShot(clip);
    }

    public void StopSE()
    {
        if (seAudioSource == null) return;
        seAudioSource.Stop();
    }
}
