using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class FileLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject panelFileViewer; //���� ������ ����ϴ� Panel;

    [SerializeField]
    private TextMeshProUGUI textFileName; //���� �̸�
    [SerializeField]
    private TextMeshProUGUI textFileSize; //���� ũ��
    [SerializeField]
    private TextMeshProUGUI textCreationTime; // ���� ���� �ð�
    [SerializeField]
    private TextMeshProUGUI textLastWriteTime; // ���� ���� ���� �ð�
    [SerializeField]
    private TextMeshProUGUI textDirectory; // ���� ���
    [SerializeField]
    private TextMeshProUGUI textFullName; // ��ü ���(���丮 + ���� �̸�)

    private FileInfo fileInfo; //���� ������ ��Ÿ���� FileInfo

    public void OnLoad(FileInfo file)
    {
        //���� ������ ����ϴ� Panel Ȱ��ȭ
        panelFileViewer.SetActive(true);

        fileInfo = file;

        //������ ������ Text UI�� ���
        textFileName.text = $"���� �̸� : {fileInfo.Name}";
        textFileSize.text = $"���� ũ�� : {fileInfo.Length} Bytes";
        textCreationTime.text = $"���� ���� �ð� : {fileInfo.CreationTime}";
        textLastWriteTime.text = $"���� ���� ���� �ð� : {fileInfo.LastWriteTime}";
        textDirectory.text = $"���� ��� : {fileInfo.Directory}";
        textFullName.text = $"��ü ��� : {fileInfo.FullName}";
    }

    public void OpenFile()
    {
        //���� ����
        Application.OpenURL("file:///"+fileInfo.FullName);
    }

    public void OffLoad()
    {
        //���� ������ ����ϴ� Panel ��Ȱ��ȭ
        panelFileViewer.SetActive(false);
    }
}
