using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Exercise : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        /*
        //���� 1. 1~10���� ���� �߿��� 3���� ������ �������� �ʴ� ���� ����ϰ�, �� �� ���� ���� ���
        int tot = 0;
        for(int i=1; i<=10;i++)
           {
               if (i % 3 != 0)
               {
                   Debug.Log($"{i}");
                   tot += i;
               }
           }
           Debug.Log($"1~10���� 3���� ������ �������� �ʴ� ���� �� : {tot}");*/

        //���� 2. ���� ���� �ﰢ������ �� ����

        const string lineConst = "===================";
        for (int y = 0; y < 5; y++)
        {
            string starRow = "";
            for (int x = 0; x <= y; x++)
            {
                starRow += "��";
            }

            for (int x = y + 1; x < 5; x++)
            {
                starRow += "��";
            }
            Debug.Log(starRow);
        }

        Debug.Log(lineConst + "2");

        //���� 3. ���� ���� ���ﰢ������ �� ����
        for (int y = 0; y < 5; y++)
        {
            string starRow = string.Empty;
            for (int x = 5; x > y; x--)
            {
                starRow += "��";
            }

            for (int x = 0; x < y; x++)
            {
                starRow += "��";
            }
            Debug.Log(starRow);
        }

        Debug.Log(lineConst + "3");

        //���� 4. ������ ���� �ﰢ������ �� ����
        for (int y = 0; y < 5; y++)
        {
            string starRow = string.Empty;

            for (int x = 0; x < 5 - (y + 1); x++)
            {
                starRow += "��";
            }

            for (int x = 0; x <= y; x++)
            {
                starRow += "��";
            }

            Debug.Log(starRow);
        }

        Debug.Log(lineConst + "4");
        //���� 5. ������ ���� ���ﰢ������ �� ����
        for (int y = 0; y < 5; y++)
        {
            string starRow = string.Empty;

            for (int x = 0; x < y; x++)
            {
                starRow += "��";
            }

            for (int x = y; x < 5; x++)
            {
                starRow += "��";
            }

            Debug.Log(starRow);
        }

        Debug.Log(lineConst + "5");

        //���� 6. ǳ��
        for (int y = 0; y < 5; y++)
        {
            string starRow = string.Empty;
            for (int x = 0; x <= y; x++)
            {
                starRow += "��";
            }

            for (int x = y + 1; x < 5; x++)
            {
                starRow += "��";
            }

            for (int x = y; x < 5; x++)
            {
                starRow += "��";
            }

            for (int x = 0; x<y; x++)
            {
                starRow += "��";
            }

            Debug.Log(starRow);
        }

        for (int y = 0; y < 5; y++)
        {
            string starRow = string.Empty;
            for (int x = 0; x < 5-(y+1); x++)
            {
                starRow += "��";
                
            }

            for (int x = 0; x <= y; x++)
            {
                starRow += "��";
            }

            for (int x = 0; x < y; x++)
            {
                
                starRow += "��";
            }

            for (int x = y; x < 5; x++)
            {
                starRow += "��";
            }

            Debug.Log(starRow);
        }

        Debug.Log(lineConst + "6");

        for (int y = 0; y < 5; y++)
        {
            string starRow = string.Empty;
           
            for (int x = 0; x< 4-y;x++)
            {
                starRow += "��";
            }

            for (int x = 0; x< 2*y+1;x++)
            {
                starRow += "��";
            }

            for (int x = y; x <4; x++)
            {
                starRow += "��";
            }

            Debug.Log(starRow);
        }

        Debug.Log(lineConst + "7");

        for (int y = 0; y < 4; y++)
        {
            string starRow = string.Empty;

            for (int x = 0; x < y+1; x++)
            {
                starRow += "��";
            }

            for (int x = 0; x < 2 * (3-y) + 1; x++)
            {
                starRow += "��";
            }

            for (int x = 0; x < y+1; x++)
            {
                starRow += "��";
            }

            Debug.Log(starRow);
        }

        Debug.Log(lineConst + "8");

        for (int y = 0; y < 4; y++)
        {
            string starRow = string.Empty;

            for (int x = 0; x < y + 1; x++)
            {
                starRow += "��";
            }

            for (int x = 0; x < 2 * (3 - y) + 1; x++)
            {
                starRow += "��";
            }

            for (int x = 0; x < y + 1; x++)
            {
                starRow += "��";
            }

            Debug.Log(starRow);
        }

        Debug.Log(lineConst + "9");

        for (int y = 0; y < 26; y++)
        {
            string alphabet = string.Empty;
           for (int x =0; x<=y; x++)
            {
                alphabet += (char)(65 + x);
            }
            Debug.Log(alphabet);
        }

        Debug.Log(lineConst + "10");


        for (int y = 0; y < 26; y++)
        {
            string alphabet = string.Empty;
            for (int x = 0; x <= y; x++)
            {
                alphabet += (char)(65 + y);
            }
            Debug.Log(alphabet);
        }

        Debug.Log(lineConst + "11");

        for (int y = 0; y < 26; y++)
        {
            string alphabet = string.Empty;

            for (int x = 0; x <= y; x++)
            {
                alphabet += " "; 
            }

            for (int x = 0; x <= y; x++)
            {
                alphabet += (char)(65 + x);
            }
            Debug.Log(alphabet);
        }

        Debug.Log(lineConst + "12");

        for (int y = 0; y < 26; y++)
        {
            string alphabet = string.Empty;

            alphabet += (char)(65+y) + "\t"; ;

            for (int x = 0; x <= y; x++)
            {
                alphabet += " ";
            }

            for (int x = y; x < 26; x++)
            {
                alphabet += (char)(65 + x);
            }
            Debug.Log(alphabet);
        }

        Debug.Log(lineConst + "14");

        for (int y = 0; y < 26; y++)
        {
            string alphabet = string.Empty;

            alphabet += (char)(65 + y) + "\t"; ;

            for (int x = 0; x < 26; x++)
            {
                alphabet += (char)(65 + x);
                
                if (x==y)
                {
                alphabet += (char)(65 + x);
                }
            }

            Debug.Log(alphabet);
        }

        Debug.Log(lineConst + "15");


        for (int y = 0; y < 26; y++)
        {
            string alphabet = string.Empty;

            alphabet += (char)(65 + y) + "\t"; ;

            for (int x = 0; x < y+1 ; x++)
            {
                alphabet += "  ";
            }

            for (int x = y; x < 26 - y;x++)
            {
                alphabet += (char)(65 + x);
            }

            Debug.Log(alphabet);
        }

        Debug.Log(lineConst + "16");

        for (int y = 0; y < 26; y++)
        {
            string alphabet = string.Empty;

            alphabet += (char)(65 + y) + "\t"; ;

            for (int x =0; x < 26 - y; x++)
            {
                alphabet += (char)(65 + x/3);
            }

            Debug.Log(alphabet);
        }

        Debug.Log(lineConst + "17");

        for (int y = 0; y < 26; y++)
        {
            string alphabet = string.Empty;

            alphabet += (char)(65 + y) + "\t";

            for (int x = 0; x < 26 - y; x++)
            {
                alphabet += (char)(65 + x / 3);
            }

            alphabet += " ";

            for (int x = y; x < 26; x++)
            {
                alphabet += (char)(65 + x);
            }

            Debug.Log(alphabet);
        }

        Debug.Log(lineConst + "18");

        for (int y = 0; y < 26; y++)
        {
            string alphabet = string.Empty;

            alphabet += (char)(65 + y) + "\t";

            for (int x = 0; x < y; x++)
            {
                alphabet += "  ";
            }

            int count = y * 3;
            for (int x = y; x < 26 ; x++)
            {
                alphabet += (char)(65 + count/3);
                count++;
            }

            Debug.Log(alphabet);
        }

        Debug.Log(lineConst + "19");
    }


}
