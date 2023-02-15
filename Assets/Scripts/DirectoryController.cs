using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DirectoryController : MonoBehaviour
{
    [SerializeField]
    private FileLoaderSystem fileLoaderSystem; //Ȯ���ں� ���� ó�� �ý���(Load & Play)

    private DirectoryInfo defaultDirectory; //�⺻ ����(����ȭ��)
    private DirectoryInfo currentDirectory; //���� ����
    private DirectorySpawner directorySpawner; //���� ��ο� �ִ� ����, ���� ���� ����/���� ����

    // Start is called before the first frame update
    private void Awake()
    {
        //���α׷��� �ֻ�ܿ� Ȱ��ȭ ���°� �ƴϾ �÷���
        Application.runInBackground = true;

        directorySpawner = GetComponent<DirectorySpawner>();
        directorySpawner.SetUp(this);

        //���� ��θ� ����ȭ������ ����
        //Environment.GetFolderPath() : �����쿡 �����ϴ� ���� ��θ� ������ �޼ҵ�
        //Encironment.SpecialFolder : �����쿡 �����ϴ� Ư�� ���� ������
        string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        defaultDirectory = new DirectoryInfo(desktopFolder);
        currentDirectory = new DirectoryInfo(desktopFolder);

       //���� ������ �����ϴ� ���丮, ���� ����
        UpdateDirectory(currentDirectory);
    }

    private void Update()
    {
        //ESC Ű�� ������ �� ����ȭ�� ������ �̵�
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateDirectory(defaultDirectory);
        }
        //�齺���̽� Ű�� ������ �� ���� ������ �̵�
        if (Input.GetKeyUp(KeyCode.Backspace)) 
        {
            MoveToParentFolder(currentDirectory);
        }
    }

    // ���� ���� ���� ������Ʈ
    private void UpdateDirectory(DirectoryInfo directory)
    {
        //���� ��� ����
        currentDirectory = directory;

        //���� ������ �����ϴ� ��� ����, ���� PanelData ����
        directorySpawner.UpdateDirectory(currentDirectory);

        /*//���� ���� �̸� ���
        Debug.Log($"���� ������ : {currentDirectory.Name}");

        //���� ������ �����ϴ� ��� ���� �̸� ���
        foreach (DirectoryInfo dir in currentDirectory.GetDirectories() )
        {
            Debug.Log(dir.Name);
        }

        //���� ������ �����ϴ� ��� ���� �̸� ���
        foreach (FileInfo file in currentDirectory.GetFiles())
        {
            Debug.Log(file.Name);
        }*/
    }

    private void MoveToParentFolder(DirectoryInfo directory)
    {
        //���� ������ ������ ����
        if(directory.Parent== null) return;
        UpdateDirectory(directory.Parent);
    }

    public void UpdateInputs(string data)
    {
        //1. ������ ����� "..."�̸� ���� ������ �̵�
        if (data.Equals("..."))
        {
            MoveToParentFolder(currentDirectory);
            return;
        }

        //2. ������ ����� �����̸� ������ ���� ���η� �̵�
        foreach(DirectoryInfo directory in currentDirectory.GetDirectories())
        {
            if(data.Equals(directory.Name)) 
            {
               UpdateDirectory(directory);
               return;
            }
        }

        //3. ������ ����� �����̸� Ȯ���ڿ� ���� ó��
        foreach (FileInfo file in currentDirectory.GetFiles())
        {
            if(data.Equals(file.Name))
            {
                //Debug.Log($"������ ������ �̸� : {file.FullName}");

                fileLoaderSystem.LoadFile(file);
            }
        }
    }
}


