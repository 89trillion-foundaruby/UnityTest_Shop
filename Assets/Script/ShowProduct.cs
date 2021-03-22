using UnityEngine;
using Script;


public class ShowProduct : MonoBehaviour
{
    [SerializeField] public RectTransform Container;
    [SerializeField] public Product CardPrefab;
    int ShopCapacity = 6; 
    
    public void Start()
    {
        DataManager.LoadData();
        LoadProduct();
    }

    //初始化商品
    public void LoadProduct()
    {
        for (int i = 0; i < ShopCapacity; i++)
        {
            Product CardItem = Instantiate(CardPrefab, Container);
            if (i >= DataManager.ProductData.dailyProduct.Count)//无商品数据
            {
                CardItem.Lock();
                continue;
            }
            CardItem.Init(DataManager.ProductData.dailyProduct[i]);//有商品数据
        }
    }
}
