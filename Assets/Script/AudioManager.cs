using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("��������")]
    public AudioClip[] musicClip;//����
    [Header("������Ч")]
    public AudioClip[] WakeStepClips;
    public AudioClip Jumplip;

    public AudioClip f;
    public AudioClip l;

    AudioSource AmbientSource;
    AudioSource MusicSource;
    AudioSource FxSource;
    AudioSource PlayerSource;
    AudioSource VoiceSource;
    [Header("������Ч")]
    public AudioClip deadClip;
    [Header("�ռ���Ч")]
    public AudioClip catchClip;
    public AudioClip throwClip;
    public AudioClip WinLevelClip;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;//����
        }
        instance = this;
        DontDestroyOnLoad(gameObject);//��������ģ��

    }
    private void Start()
    {
        AmbientSource = gameObject.AddComponent<AudioSource>();
        MusicSource = gameObject.AddComponent<AudioSource>();
        FxSource = gameObject.AddComponent<AudioSource>();
        PlayerSource = gameObject.AddComponent<AudioSource>();
        VoiceSource = gameObject.AddComponent<AudioSource>();
        instance.SourceAudio();
    }
    public void PlayWakeStep()
    {
        int index = Random.Range(0, WakeStepClips.Length);
        PlayerSource.clip = WakeStepClips[index];
        PlayerSource.Play();

    }

    public void PlayJumpStep()
    {
        PlayerSource.clip = Jumplip;
        PlayerSource.Play();
    }
    void SourceAudio()
    {

        AmbientSource.Play();
        AmbientSource.loop = true;
        int index = Random.Range(0, musicClip.Length);
        MusicSource.clip = musicClip[index];
        MusicSource.Play();
        MusicSource.loop = true;

        FxSource.Play();
    }
    public void PlaydeathAudio()
    {
        VoiceSource.clip = deadClip;
        VoiceSource.Play();

    }
    public void CatchAudio()
    {
        PlayerSource.clip = catchClip;
        PlayerSource.Play();
        PlayerSource.Stop();

    }
    public void ChangeF()
    {
        PlayerSource.clip = f;
        PlayerSource.Play();
        PlayerSource.Stop();

    }
    public void ChangeL()
    {
        PlayerSource.clip = l;
        PlayerSource.Play();
        PlayerSource.Stop();

    }
    public void ThrowAudio()
    {
        PlayerSource.clip = throwClip;
        PlayerSource.Play();
        PlayerSource.Stop();

    }

    public void WintheAudio()
    {
        PlayerSource.clip = WinLevelClip;
        PlayerSource.Play();
        PlayerSource.Stop();

    }

}
