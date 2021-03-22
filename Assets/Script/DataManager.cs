using UnityEngine;
using System.IO;
using Newtonsoft.Json;


public class DataManager : MonoBehaviour
{
    public static Data ProductData;

    //读取玩家数据
    public static void LoadData()
    {
        string jsonStr = "";
        string path = "Assets/Data/data.json";
        jsonStr = File.ReadAllText(path);
        ProductData = JsonConvert.DeserializeObject<Data>(jsonStr);
    }
}
