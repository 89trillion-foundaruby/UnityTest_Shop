# UnityTest_Shop
Use for UnityTest 
Unity2019.4.17f1c1

requirement document

新建项目，一个空场景，只有一个按钮，点击按钮弹出弹窗，该弹窗展示标注图中的每日精选，6个商品位，读取json控制6个商品item的多种状态样式。

要求：
1，商品数据从json数据源内读取并展示
2，点击商品可以实现购买，并刷新为购买状态
3，商店内6个商品位，数据没有则显示未解锁状态；数据源只包含金币和卡牌两种类型

json数据含义说明：
{
    "productId": 1,//商品id，从0开始
    "type": 3,//商品类型,具体定于见RewardType.cs
    "subType": 7,//商品子类型，。具体定于见RewardType.cs
    "num": 25,//商品数量
    "costGold": 2000,//需花费金币
    "costGem": 2000,//需花费的钻石
    "isPurchased": -1//商品是否已购买，-1和1
}
