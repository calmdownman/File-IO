using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class MP3Loader : MonoBehaviour
{
    [Header("MP3 Player Panel, File Name")]
    [SerializeField]
    private GameObject panelMP3Player; //���� ��� ��� ���� Panel
    [SerializeField]
    private TextMeshProUGUI textFileName; //���� �̸� Text

    [Header("MP3 Play Time (Slider, Text)")]
    [SerializeField]
    private Slider sliderPlaybar; //����ð��� ��Ÿ���� Slider
    [SerializeField]
    private TextMeshProUGUI textCurrentPlaytime; //���� ����ð� Text
    [SerializeField]
    private TextMeshProUGUI textMaxPlaytime; //�� ����ð� Text

    [Header("Play Audio")]
    [SerializeField]
    private AudioSource audioSource; //���� ����� AudioSource
   
    public void OnLoad(System.IO.FileInfo file)
    {
        panelMP3Player.SetActive(true); //Panel Ȱ��ȭ

        textFileName.text = file.Name; //MP3 ���� �̸� ���

        ResetPlaytimeUI(); //����ð� ǥ�ÿ� ���Ǵ� Slider, Text �ʱ�ȭ

        StartCoroutine(LoadAudio(file.FullName)); //MP3 ������ �ҷ��ͼ� ���
    }

    private IEnumerator LoadAudio(string fileName)
    {
        AudioClip clip = null;
      
        fileName = "file://" + fileName;
        
        //fileName ������ MP3 AudioClip ���·� �޾ƿͼ� audioData�� ����
        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(fileName, AudioType.MPEG);
        //requet�� �����͸� ���������� ��� �ε��� �� ���� ���
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Load Succes : {fileName}");

            clip = DownloadHandlerAudioClip.GetContent(request);

            audioSource.clip = clip;
            
            Play();
        } else
        {
            Debug.Log("Load Failed");
        }
    }

    public void OffLoad()
    {
        Stop();
        //Panel ��Ȱ��ȭ
        panelMP3Player.SetActive(false);
    }

    public void Play()
    {
        audioSource.Play();
        //Slider, Text�� ����ð� ���� ������Ʈ
        StartCoroutine("OnPlaytimeUI");
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void Stop()
    {
        audioSource.Stop();
        //Slider, Text�� ����ð� ���� ������Ʈ ����
        StopCoroutine("OnPlaytimeUI");
        //����ð� ǥ�ÿ� ���Ǵ� Slider, Text �ʱ�ȭ
        ResetPlaytimeUI();
    }

    private void ResetPlaytimeUI()
    {
        sliderPlaybar.value = 0;
        textCurrentPlaytime.text= "00:00:00";
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
            hour = (int)audioSource.time/3600;
            minutes = (int)(audioSource.time%3600)/60;
            seconds = (int)(audioSource.time % 3600) % 60;
            textCurrentPlaytime.text = $"{hour:D2}:{minutes:D2}:{seconds:D2}";

            //�� ����ð� ǥ��
            hour = (int)audioSource.clip.length / 3600;
            minutes = (int)(audioSource.clip.length % 3600) / 60;
            seconds = (int)(audioSource.clip.length % 3600) % 60;
            textMaxPlaytime.text = $"{hour:D2}:{minutes:D2}:{seconds:D2}";

            //Slider�� ǥ�õǴ� ��� �ð� ����
            sliderPlaybar.value = audioSource.time / audioSource.clip.length;

            yield return new WaitForSeconds(1);
        }
    }

}
