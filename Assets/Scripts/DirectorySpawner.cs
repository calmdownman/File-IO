using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class DirectorySpawner : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDirectoryName; //���� ��� �̸��� ��Ÿ���� Text UI
    [SerializeField]
    private Scrollbar verticalScrollbar; //����, ���ϵ��� ��ġ�Ǵ� ScrollView�� ��ũ�ѹ�

    [SerializeField]
    private GameObject panelDataPrefab; //���� ������ �����ϴ� ����, ������ ���ϸ�(Icon)�� ��Ÿ���� ������
    [SerializeField]
    private Transform parentContent; //�����Ǵ� Text UI�� ����Ǵ� �θ� ������Ʈ (ScrollView�� Content)

    private DirectoryController directoryController; // DirectoryController �ּ� ����. Data Ŭ������ ����

    private List<Data> fileList; //���� ������ �����ϴ� ���� ����Ʈ

    public void SetUp(DirectoryController controller)
    {
        directoryController = controller;

        //���� ������ �����ϴ� ���丮, ���� ������Ʈ ����Ʈ
        fileList = new List<Data>();
    }

    public void UpdateDirectory(DirectoryInfo currentDirectory)
    {
        //������ �����Ǿ� �ִ� ������ ���� ����
        for (int i = 0; i < fileList.Count; i++)
        {
            Destroy(fileList[i].gameObject);
        }
        fileList.Clear();

        //���� ���� �̸� ���
        textDirectoryName.text = currentDirectory.Name;

        //Scrollbar value�� 1�� �����ؼ� ����� ���� ���� �̵�
        verticalScrollbar.value = 1;

        //���� ������ �̵��ϱ� ���� "..." ����
        SpawnData("...", DataType.Direcroty);

        //���� ������ �����ϴ� ��� ���� Text UI ���� 
        foreach(DirectoryInfo directory in currentDirectory.GetDirectories() )
        {
            SpawnData(directory.Name, DataType.Direcroty);
        }

        //���� ������ �����ϴ� ��� ���� Text UI ����
        foreach (FileInfo file in currentDirectory.GetFiles() )
        {
            SpawnData(file.Name, DataType.File);
        }

        //����, ���� ������ ����Ǿ� �ִ� ����Ʈ�� FileName ������������ ����
        fileList.Sort((a,b) => a.FileName.CompareTo(b.FileName));

        //������ �Ϸ�� fileList�� �������� ȭ�鿡 ��ġ�� ������Ʈ�� ������
        //���� ������ �̵��ϴ� "..."�� ���� ���� ��ġ
        for (int i =0; i<fileList.Count; i++)
        {
            fileList[i].transform.SetSiblingIndex(i); //���̶���Ű ����

            if (fileList[i].FileName.Equals("..."))
            {
                fileList[i].transform.SetAsFirstSibling();
            }
        }
    }

    public void SpawnData(string fileName, DataType type)
    {
        GameObject clone = Instantiate(panelDataPrefab);

        // ������ Panel UI�� Content �ڽ����� ��ġ�ϰ�, ũ�⸦ 1�� ����
        clone.transform.SetParent(parentContent);
        clone.transform.localPosition = Vector3.one;

        Data data= clone.GetComponent<Data>();
        data.SetUp(directoryController,fileName, type);

        //���� ����, ������ ���� ����Ʈ�� ����
        fileList.Add(data);
    }
}
