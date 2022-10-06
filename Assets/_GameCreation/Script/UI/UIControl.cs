using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Button standBtn;
    public Image standBtnImg;
    void Start()
    {
        SetupBtn();
    }

    void SetupBtn()
    {
        standBtn.onClick.AddListener(OnStandBtnClick);
    }

    public void OnStandBtnClick()
    {
        //CPlayerControl.Instance.OrderChangeStand();
    }

}
