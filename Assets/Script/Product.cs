using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Product : MonoBehaviour
    {
        [SerializeField] public GameObject ShowPart;//有商品数据
        [SerializeField] public GameObject LockPart;//无商品数据
        [SerializeField] public Image ShowBack;//整体背景
        [SerializeField] public Sprite[] BackImage;
        [SerializeField] public Text ShowTitle;
        [SerializeField] public Image ShowContainer;//商品展示区域背景
        [SerializeField] public Sprite[] ContainerImage;
        [SerializeField] public GameObject CoinImage;
        [SerializeField] public GameObject CardImage;
        [SerializeField] public Text CardNum;//卡片数量
        [SerializeField] public Text CardRarity;//卡片稀有度
        [SerializeField] public RectTransform CollectButton;
        [SerializeField] public Text CostText;
        [SerializeField] public GameObject Collected;//已购买状态

        public int cardNum;
        public int isPurchased;//已购买
        
        //有商品数据时初始化
        public void Init(ShopProduct shopProduct)
        {
            isPurchased = shopProduct.isPurchased;
            
            if (shopProduct.type == 2)//商品类型为金币
            {
                ShowBack.sprite = BackImage[0];
                ShowTitle.text = "Coins";
                ShowContainer.sprite = ContainerImage[0];
                CardImage.SetActive(false);
                CoinImage.SetActive(true);
                CollectButton.GetChild(1).gameObject.SetActive(true);//免费
                cardNum = 1;
            }
            
            if (shopProduct.type == 3)//商品类型为卡片
            {
                ShowBack.sprite = BackImage[1];
                ShowTitle.text = "Soldier";
                
                if (shopProduct.subType == 7 || shopProduct.subType == 20)//稀有
                {
                    ShowContainer.sprite = ContainerImage[1];
                    CardRarity.text = "<color=#FF7F24>Legend</color>";
                }
                else
                {
                    ShowContainer.sprite = ContainerImage[0];
                    CardRarity.text = "<color=#1E90FF>Normal</color>";
                }
               
                string imgPath = $"Assets/Resource/Card/{shopProduct.subType}.png"; //读取卡片图片
                string imageStr = SetImageToString(imgPath);
                CardImage.GetComponent<RawImage>().texture = GetTextureByString(imageStr);
                
                cardNum = shopProduct.num;
                CardNum.text = $"× {cardNum}";
                CollectButton.GetChild(0).gameObject.SetActive(true);//卡片花费
                CostText.text = $"{shopProduct.costGold}";
            }
            
        }

        //无商品数据时
        public void Lock()
        {
            ShowPart.SetActive(false);
            LockPart.SetActive(true);
        }

        public void Click()
        {
            if (cardNum > 1 && isPurchased < 0)
            {
                cardNum--;
                CardNum.text = $"× {cardNum}";
            }
            else
            {
                CardNum.gameObject.SetActive(false);
                CollectButton.gameObject.SetActive(false);
                Collected.SetActive(true);//展示已购买状态
                isPurchased = 1;
            }
        }
        
        //读取卡片图片
        private string SetImageToString(string imgPath)
        {
            FileStream fs = new FileStream(imgPath, FileMode.Open);
            byte[] imgByte = new byte[fs.Length];
            fs.Read(imgByte, 0, imgByte.Length);
            fs.Close();
            return Convert.ToBase64String(imgByte);
        }
        
        //将图片转换为纹理
        private Texture2D GetTextureByString(string textureStr)
        {
            Texture2D tex = new Texture2D(1, 1);
            byte[] arr = Convert.FromBase64String(textureStr);
            tex.LoadImage(arr);
            tex.Apply();
            return tex;
        }
    }
}