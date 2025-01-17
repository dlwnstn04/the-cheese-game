using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBoard : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float maxEnergy;
    private bool reset;

    void Start()    //------------------------------------------------------------------------- 값 초기화
    {
        slider.maxValue = maxEnergy;    //최대에너지
        slider.value = maxEnergy;       //현재에너지
    }

    void Update()   //------------------------------------------------------------------------- 에너지 감소  &  게임 종료
    {
        if(slider.value>0)              //게임 종료 후에도 에너지를 넣어주면 재작동 초당
        {
            if(Player.energy == 1)
            {
                slider.value += 10;
                Player.energy = 0;
            }
            if(Player.hurt)
            {
                slider.value -= Time.deltaTime * 10;
            }
            slider.value -= Time.deltaTime;     //초당 1만큼 에너지 감소
            reset = true;
        }
        else if(reset)                  //reset이 true일 때만 게임 종료 코드가 실행됨
        {
            Debug.Log("You Die");               //게임 종료 코드가 들어갈 자리
            reset = false;                      //더이상 게임 종료 코드가 실행되지 않도록
        }
    }
}
