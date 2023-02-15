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
    private GameObject panelMP4Player; //영상 재생 제어를 위한 Panel
    [SerializeField]
    private TextMeshProUGUI txetFileName; //파일 이름

    [Header("MP4 Play Time (Slider, Text)")]
    [SerializeField]
    private Slider sliderPlaybar; //재생시간을 나타내는 Slider
    [SerializeField]
    private TextMeshProUGUI textCurrentPlaytime; //현재 재생시간
    [SerializeField]
    private TextMeshProUGUI textMaxPlaytime; //총 재생시간

    [Header("Play Video & Audio")]
    [SerializeField]
    private RawImage rawImageDrawVideo; //영상 출력을 위한 RawImage
    [SerializeField]
    private VideoPlayer videoPlayer; //영상 재생용 VideoPlayer
    [SerializeField]
    private AudioSource audioSource; //사운드 재생용 AudioSource

    public void OnLoad(System.IO.FileInfo file)
    {
        panelMP4Player.SetActive(true); //Panel 활성화

        txetFileName.text = file.Name; //MP4 파일 이름 출력

        ResetPlaytimeUI(); //재생시간 표시에 사용되는 Slider, Text 초기화

        StartCoroutine(LoadVideo(file.FullName)); //MP4 파일을 불러와서 재생
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
        //Panel 비활성화
        panelMP4Player.SetActive(false);
    }

    public void Play()
    {
        videoPlayer.Play(); //동영상,사운드 재생
        audioSource.Play();
        //Slider, Text에 재생시간 정보 업데이트
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
        //Slider, Text에 재생시간 정보 업데이트 중지
        StopCoroutine("OnPlaytimeUI");
        //Slider, Text에 재생시간 정보 업데이트 중지
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
            //현재 재생시간 표시
            hour = (int)videoPlayer.time / 3600;
            minutes = (int)(videoPlayer.time % 3600) / 60;
            seconds = (int)(videoPlayer.time % 3600) % 60;
            textCurrentPlaytime.text = $"{hour:D2}:{minutes:D2}:{seconds:D2}";

            //총 재생시간 표시
            hour = (int)videoPlayer.length / 3600;
            minutes = (int)(videoPlayer.length % 3600) / 60;
            seconds = (int)(videoPlayer.length % 3600) % 60;
            textMaxPlaytime.text = $"{hour:D2}:{minutes:D2}:{seconds:D2}";

            //Slider에 표시되는 재생 시간 설정
            sliderPlaybar.value = (float)(videoPlayer.time / videoPlayer.length);

            yield return new WaitForSeconds(1);
        }
    }
}
