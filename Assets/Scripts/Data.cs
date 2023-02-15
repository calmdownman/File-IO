using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

//파일의 속성(폴더,파일) - 아이콘 출력용(파일의 확장자에 따라 세부 구분할 경우 타입 추가)
public enum DataType { Direcroty = 0, File}
public class Data : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler,IPointerExitHandler
{
    [SerializeField]
    private Sprite[] spriteIcons; //아이콘에 적용할 수 있는 Sprite 이미지

    private Image imageIcon; //파일의 속성에 따라 아이콘 출력
    private TextMeshProUGUI textDataName; //파일의 이름 출력

    private DataType dataType; //파일의 속성

    private string fileName; //파일 이름
    public string FileName => fileName; //외부에서 확인하기 위한 Get 프로퍼티

    private const int maxFileNameLength = 25; //파일 이름의 최대 길이

    private DirectoryController directoryController;

    public void SetUp(DirectoryController controller,string fileName, DataType dataType)
    {
        directoryController= controller;

        //만약 PanelData 오브젝트의 Image 컴포넌트를 삭제하지 않았으면 PanelData가 Get된다.
        imageIcon = GetComponentInChildren<Image>();
        textDataName = GetComponentInChildren<TextMeshProUGUI>();

        this.fileName = fileName;
        this.dataType = dataType;

        //아이콘 이미지 설정
        imageIcon.sprite = spriteIcons[(int)this.dataType];

        //파일 이름 출력
        textDataName.text = this.fileName;
        //파일의 이름 뒷부분 자르기
        if (fileName.Length >= maxFileNameLength)
        {
            textDataName.text = fileName.Substring(0, maxFileNameLength);
            textDataName.text += "...";
        }
        //파일 이름 색상 설졍 (폴더:노란색,파일:하얀색)
        SetTextColor();
    }

    //마우스가 현재 텍스트 UI 위에 있을 때 호출
    public void OnPointerEnter(PointerEventData eventData)
    {
        textDataName.color = Color.red;
    }

    //마우스가 현재 텍스트 UI를 클릭했을 때 호출
    public void OnPointerClick(PointerEventData eventData)
    {
        directoryController.UpdateInputs(fileName);
    }

    //마우스가 현재 텍스트 UI 위에서 벗어날 때 호출
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
