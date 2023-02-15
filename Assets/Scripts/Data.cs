using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

//������ �Ӽ�(����,����) - ������ ��¿�(������ Ȯ���ڿ� ���� ���� ������ ��� Ÿ�� �߰�)
public enum DataType { Direcroty = 0, File}
public class Data : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler,IPointerExitHandler
{
    [SerializeField]
    private Sprite[] spriteIcons; //�����ܿ� ������ �� �ִ� Sprite �̹���

    private Image imageIcon; //������ �Ӽ��� ���� ������ ���
    private TextMeshProUGUI textDataName; //������ �̸� ���

    private DataType dataType; //������ �Ӽ�

    private string fileName; //���� �̸�
    public string FileName => fileName; //�ܺο��� Ȯ���ϱ� ���� Get ������Ƽ

    private const int maxFileNameLength = 25; //���� �̸��� �ִ� ����

    private DirectoryController directoryController;

    public void SetUp(DirectoryController controller,string fileName, DataType dataType)
    {
        directoryController= controller;

        //���� PanelData ������Ʈ�� Image ������Ʈ�� �������� �ʾ����� PanelData�� Get�ȴ�.
        imageIcon = GetComponentInChildren<Image>();
        textDataName = GetComponentInChildren<TextMeshProUGUI>();

        this.fileName = fileName;
        this.dataType = dataType;

        //������ �̹��� ����
        imageIcon.sprite = spriteIcons[(int)this.dataType];

        //���� �̸� ���
        textDataName.text = this.fileName;
        //������ �̸� �޺κ� �ڸ���
        if (fileName.Length >= maxFileNameLength)
        {
            textDataName.text = fileName.Substring(0, maxFileNameLength);
            textDataName.text += "...";
        }
        //���� �̸� ���� ���� (����:�����,����:�Ͼ��)
        SetTextColor();
    }

    //���콺�� ���� �ؽ�Ʈ UI ���� ���� �� ȣ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        textDataName.color = Color.red;
    }

    //���콺�� ���� �ؽ�Ʈ UI�� Ŭ������ �� ȣ��
    public void OnPointerClick(PointerEventData eventData)
    {
        directoryController.UpdateInputs(fileName);
    }

    //���콺�� ���� �ؽ�Ʈ UI ������ ��� �� ȣ��
    public void OnPointerExit(PointerEventData eventData)
    {
        SetTextColor();
    }

    private void SetTextColor()
    {
       if(dataType == DataType.Direcroty) {
            textDataName.color= Color.yellow;
        } else
        {
            textDataName.color= Color.white;
        }
    }

}
