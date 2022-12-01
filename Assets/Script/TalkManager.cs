using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(11, new string[] { "...zzZ:0", "...zzZ?:0" });
        talkData.Add(12, new string[] { "Ah...?:1", "Ahchoo!!:0" });
        talkData.Add(14, new string[] { "¹»ºÁ?:0", "¸»ÇÏ´Â °í¾çÀÌ Ã³À½ º¸³ª?:0", "±ÍÂú°Ô ±¼Áö ¸»Áö?:0" });
        talkData.Add(101, new string[] { "Warning / Dungeon Trap" });
        talkData.Add(602, new string[] { "Scene2 ¿­¼è È¹µæ!" });
        talkData.Add(603, new string[] { "Scene3 ¿­¼è È¹µæ!" });
        talkData.Add(604, new string[] { "Scene4 ¿­¼è È¹µæ!" });
        talkData.Add(702, new string[] { "Ã¹¹øÂ° ¹®ÀÌ ¿­·È´Ù!" });
        talkData.Add(703, new string[] { "µÎ¹øÂ° ¹®ÀÌ ¿­·È´Ù!" });
        talkData.Add(704, new string[] { "¸¶Áö¸· ¹®ÀÌ ¿­·È´Ù!" });
        talkData.Add(705, new string[] { "¸Â´Â ¿­¼è°¡ ¾ø½À´Ï´Ù." });

        portraitData.Add(11 + 0, portraitArr[0]);
        portraitData.Add(12 + 0, portraitArr[1]);
        portraitData.Add(12 + 1, portraitArr[2]);
        portraitData.Add(14 + 0, portraitArr[3]);

    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
