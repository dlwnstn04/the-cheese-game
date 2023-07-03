using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBoard : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float maxEnergy;
    private bool reset;

    void Start()    //------------------------------------------------------------------------- �� �ʱ�ȭ
    {
        slider.maxValue = maxEnergy;    //�ִ뿡����
        slider.value = maxEnergy;       //���翡����
    }

    void Update()   //------------------------------------------------------------------------- ������ ����  &  ���� ����
    {
        if(slider.value>0)              //���� ���� �Ŀ��� �������� �־��ָ� ���۵� �ʴ�
        {
            slider.value -= Time.deltaTime;     //�ʴ� 1��ŭ ������ ����
            reset = true;
        }
        else if(reset)                  //reset�� true�� ���� ���� ���� �ڵ尡 �����
        {
            Debug.Log("You Die");               //���� ���� �ڵ尡 �� �ڸ�
            reset = false;                      //���̻� ���� ���� �ڵ尡 ������� �ʵ���
        }
    }
}
