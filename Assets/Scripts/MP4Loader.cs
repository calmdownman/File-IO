using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class MP4Loader : MonoBehaviour
{
    [Header("MP4 Player Panel, File Name")]
    [SerializeField]
    private GameObject panelMP4Player; //���� ��� ��� ���� Panel
    [SerializeField]
    private TextMeshProUGUI txetFileName; //���� �̸�

    [Header("MP4 Play Time (Slider, Text)")]
    [SerializeField]
    private Slider sliderPlaybar; //����ð��� ��Ÿ���� Slider
    [SerializeField]
    private TextMeshProUGUI textCurrentPlaytime; //���� ����ð�
    [SerializeField]
    private TextMeshProUGUI textMaxPlaytime; //�� ����ð�

    [Header("Play Video & Audio")]
    [SerializeField]
    private RawImage rawImageDrawVideo; //���� ����� ���� RawImage
    [SerializeField]
    private VideoPlayer videoPlayer; //���� ����� VideoPlayer
    [SerializeField]
    private AudioSource audioSource; //���� ����� AudioSource

    public void OnLoad(System.IO.FileInfo file)
    {
        panelMP4Player.SetActive(true); //Panel Ȱ��ȭ

        txetFileName.text = file.Name; //MP4 ���� �̸� ���

        ResetPlaytimeUI(); //����ð� ǥ�ÿ� ���Ǵ� Slider, Text �ʱ�ȭ

        StartCoroutine(LoadVideo(file.FullName)); //MP4 ������ �ҷ��ͼ� ���
    }

    private IEnumerator LoadVideo(string fullPath)
    {
        videoPlayer.url = "file://" + fullPath;

        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        audioSource.clip = null;

        rawImageDrawVideo.texture = videoPlayer.targetTexture;

        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Play();
    }

    public void OffLoad()
    {
        Stop();
        //Panel ��Ȱ��ȭ
        panelMP4Player.SetActive(false);
    }

    public void Play()
    {
        videoPlayer.Play(); //������,���� ���
        audioSource.Play();
        //Slider, Text�� ����ð� ���� ������Ʈ
        StartCoroutine("OnPlaytimeUI");
    }

    public void Pause()
    {
        videoPlayer.Pause(); 
        audioSource.Pause();
    }

    public void Stop()
    {
        videoPlayer.Stop();
        audioSource.Stop();
        //Slider, Text�� ����ð� ���� ������Ʈ ����
        StopCoroutine("OnPlaytimeUI");
        //Slider, Text�� ����ð� ���� ������Ʈ ����
        ResetPlaytimeUI();
    }

    private void ResetPlaytimeUI()
    {
        sliderPlaybar.value = 0;
        textCurrentPlaytime.text = "00:00:00";
        textMaxPlaytime.text = "00:00:00";
    }

    private IEnumerator OnPlaytimeUI()
    {
        int hour = 0;
        int minutes = 0;
        int seconds = 0;

        while (true)
        {
            //���� ����ð� ǥ��
            hour = (int)videoPlayer.time / 3600;
            minutes = (int)(videoPlayer.time % 3600) / 60;
            seconds = (int)(videoPlayer.time % 3600) % 60;
            textCurrentPlaytime.text = $"{hour:D2}:{minutes:D2}:{seconds:D2}";

            //�� ����ð� ǥ��
            hour = (int)videoPlayer.length / 3600;
            minutes = (int)(videoPlayer.length % 3600) / 60;
            seconds = (int)(videoPlayer.length % 3600) % 60;
            textMaxPlaytime.text = $"{hour:D2}:{minutes:D2}:{seconds:D2}";

            //Slider�� ǥ�õǴ� ��� �ð� ����
            sliderPlaybar.value = (float)(videoPlayer.time / videoPlayer.length);

            yield return new WaitForSeconds(1);
        }
    }
}
