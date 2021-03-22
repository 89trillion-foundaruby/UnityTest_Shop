using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDialogManager : MonoBehaviour
{
    [SerializeField] private GameObject ShopButtonDialog;
    
    //打开商店Dialog 隐藏入口
    public void Open()
    {
        gameObject.SetActive(true);
        ShopButtonDialog.SetActive(false);
    }

    //隐藏商店Dialog 显示入口
    public void Close()
    {
        gameObject.SetActive(false);
        ShopButtonDialog.SetActive(true);
    }
}
