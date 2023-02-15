using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ImageLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject panelImageViewer; //�̹��� ������ ����ϴ� Panel

    [SerializeField]
    private Image imageDrawTexture; //������ ��Ÿ���� �̹��� ���
    [SerializeField]
    private TextMeshProUGUI textFileData; //���� �̸�, �ػ�, �뷮

    private float maxWidth = 1180; //Image UI �ִ� ũ��
    private float maxHeight = 800;

    public void OnLoad(FileInfo file)
    {
        //�̹��������� ����ϴ� Panel Ȱ��ȭ
        panelImageViewer.SetActive(true);
        
        //���Ϸκ��� Bytes �����͸� �ҷ��´�
        byte[] byteTexture = File.ReadAllBytes(file.FullName);
       
        //byteTexture�� �ִ� byte �迭 ������ �������� Texture2D �̹��� ���� ������ ����
        Texture2D texture2D = new Texture2D(0, 0);
        if( byteTexture.Length > 0)
        {
            texture2D.LoadImage(byteTexture);
        }

        //�̹����� ����ϴ� Image UI�� ũ�� ����
        if (texture2D.width > maxWidth)
        {
            imageDrawTexture.rectTransform.sizeDelta = new Vector2(maxWidth, maxWidth/texture2D.width*texture2D.height);
        } 
        else if(texture2D.height > maxHeight)
        {
            imageDrawTexture.rectTransform.sizeDelta = new Vector2(maxHeight/texture2D.height*texture2D.width, maxHeight);
        } 
        else
        {
            imageDrawTexture.rectTransform.sizeDelta = new Vector2(texture2D.width, texture2D.height);
        }

        //Texture2D -> Sprite ��ȯ : (Texture2D,Rect(x,y,with,height),�����¿�����)
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
        //ImageDrawTexture Image UI�� �������� �̹�� sprite�� ����
        imageDrawTexture.sprite = sprite;
        //�̹��� ���� ���� ���
        textFileData.text = $"{file.Name} ({texture2D.width} x {texture2D.height} / {file.Length.ToString("N0")} Bytes)";
    }

    public void OffLoad()
    {
        //�̹��� ������ ����ϴ� Panel ��Ȱ��ȭ
        panelImageViewer.SetActive(false);
    }
}
