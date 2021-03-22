/// <summary>
/// 玩家数据类型
/// </summary>
public struct ShopProduct
{
    public int productId;
    public int type;
    public int subType;
    public int num;
    public int costGold;
    public int isPurchased;

    public ShopProduct(int productId, int type, int subType, int num, int costGold, int isPurchased):this()
    {
        this.productId = productId;
        this.type = type;
        this.subType = subType;
        this.num = num;
        this.costGold = costGold;
        this.isPurchased = isPurchased;
    }
}
