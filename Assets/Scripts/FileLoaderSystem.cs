using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileLoaderSystem : MonoBehaviour
{
    //확장자별 파일 처리(Load & Play)
    private FileLoader fileLoader; //문서, 일반 파일
    private ImageLoader imageLoader; //이미지 파일
    private MP3Loader mp3Loader; //MP3 파일
    private MP4Loader mp4Loader; //MP4 파일

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

        //선택한 파일이 문서 파일일 경우 문서 프로그램 실행
        if (file.FullName.Contains(".pdf") || file.FullName.Contains(".xlsx") || file.FullName.Contains(".doc") ||
            file.FullName.Contains(".pptx") || file.FullName.Contains(".hwp") || file.FullName.Contains(".txt"))
        {
            fileLoader.OnLoad(file);
        }//선택한 파일이 이미지 파일일 경우 화면에 이미지 출력
        else if (file.FullName.Contains(".jpg") || file.FullName.Contains(".png") || file.FullName.Contains(".JPG") || file.FullName.Contains(".PNG"))
        {
            imageLoader.OnLoad(file);
        }//선택한 파일이 음악 파일일 경우 음악 재생
        else if (file.FullName.Contains(".mp3")) 
        {
            mp3Loader.OnLoad(file);
        }
        else if (file.FullName.Contains(".mp4")|| file.FullName.Contains(".mov"))
        {
            mp4Loader.OnLoad(file);
        }
        else //나머지 모든 확장자는 문서와 동일하게 파일 정보 출력
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
