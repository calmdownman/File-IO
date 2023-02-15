using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class FileLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject panelFileViewer; //파일 정보를 출력하는 Panel;

    [SerializeField]
    private TextMeshProUGUI textFileName; //파일 이름
    [SerializeField]
    private TextMeshProUGUI textFileSize; //파일 크기
    [SerializeField]
    private TextMeshProUGUI textCreationTime; // 파일 생성 시간
    [SerializeField]
    private TextMeshProUGUI textLastWriteTime; // 파일 최종 수정 시간
    [SerializeField]
    private TextMeshProUGUI textDirectory; // 파일 경로
    [SerializeField]
    private TextMeshProUGUI textFullName; // 전체 경로(디렉토리 + 파일 이름)

    private FileInfo fileInfo; //현재 파일을 나타내는 FileInfo

    public void OnLoad(FileInfo file)
    {
        //파일 정보를 출력하는 Panel 활성화
        panelFileViewer.SetActive(true);

        fileInfo = file;

        //파일의 정보를 Text UI에 출력
        textFileName.text = $"파일 이름 : {fileInfo.Name}";
        textFileSize.text = $"파일 크기 : {fileInfo.Length} Bytes";
        textCreationTime.text = $"파일 생성 시간 : {fileInfo.CreationTime}";
        textLastWriteTime.text = $"파일 최종 수정 시간 : {fileInfo.LastWriteTime}";
        textDirectory.text = $"파일 경로 : {fileInfo.Directory}";
        textFullName.text = $"전체 경로 : {fileInfo.FullName}";
    }

    public void OpenFile()
    {
        //파일 열기
        Application.OpenURL("file:///"+fileInfo.FullName);
    }

    public void OffLoad()
    {
        //파일 정보를 출력하는 Panel 비활성화
        panelFileViewer.SetActive(false);
    }
}
