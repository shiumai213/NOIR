using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "StoryData")]
public class StoryData : ScriptableObject
{
    // この StoryData に割り当てる BGM の配列インデックス（SoundManager.bgmclips の何番か）
    public int BgmIndex = -1;

    // ストーリーのリスト
    public List<Story> stories = new List<Story>();
}

[System.Serializable]
public class Story
{
    // 背景画像
    public Sprite Background;
    // キャラクター画像
    public Sprite CharacterImage;
    // 効果音
    public AudioClip SFX;
    // ストーリーテキスト（複数行対応）
    [TextArea]
    public string StoryText;
    // キャラクター名
    public string CharacterName;
    // 選択肢（未設定=通常通り次の行に進む）
    public List<ChoiceOption> Choices = new List<ChoiceOption>();
}

// 選択肢1件分のデータ
[System.Serializable]
public class ChoiceOption
{
    public string Text;
    public int NextStoryIndex = -1;
    public int NextTextIndex = -1;
}
