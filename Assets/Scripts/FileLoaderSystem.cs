using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileLoaderSystem : MonoBehaviour
{
    //Ȯ���ں� ���� ó��(Load & Play)
    private FileLoader fileLoader; //����, �Ϲ� ����
    private ImageLoader imageLoader; //�̹��� ����
    private MP3Loader mp3Loader; //MP3 ����
    private MP4Loader mp4Loader; //MP4 ����

    void Awake()
    {
        fileLoader= GetComponent<FileLoader>();
        imageLoader= GetComponent<ImageLoader>();
        mp3Loader= GetComponent<MP3Loader>();
        mp4Loader = GetComponent<MP4Loader>();
    }

    public void LoadFile(FileInfo file)
    {
        OffAllPanel();

        //������ ������ ���� ������ ��� ���� ���α׷� ����
        if (file.FullName.Contains(".pdf") || file.FullName.Contains(".xlsx") || file.FullName.Contains(".doc") ||
            file.FullName.Contains(".pptx") || file.FullName.Contains(".hwp") || file.FullName.Contains(".txt"))
        {
            fileLoader.OnLoad(file);
        }//������ ������ �̹��� ������ ��� ȭ�鿡 �̹��� ���
        else if (file.FullName.Contains(".jpg") || file.FullName.Contains(".png") || file.FullName.Contains(".JPG") || file.FullName.Contains(".PNG"))
        {
            imageLoader.OnLoad(file);
        }//������ ������ ���� ������ ��� ���� ���
        else if (file.FullName.Contains(".mp3")) 
        {
            mp3Loader.OnLoad(file);
        }
        else if (file.FullName.Contains(".mp4")|| file.FullName.Contains(".mov"))
        {
            mp4Loader.OnLoad(file);
        }
        else //������ ��� Ȯ���ڴ� ������ �����ϰ� ���� ���� ���
        {
            fileLoader.OnLoad(file);
        }
    }

    private void OffAllPanel()
    {
        fileLoader.OffLoad();
        imageLoader.OffLoad();
        mp3Loader.OffLoad();
        mp4Loader.OffLoad();
    }
}
