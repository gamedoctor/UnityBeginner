using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Setsuna
{
    public class Sample : MonoBehaviour
    {
        public void Start()
        {
            // 課題:
            // キャラクターは以下が存在している
            var characters = new List<Character>
            {
                new Character {name = "セシル", level = 1},
                new Character {name = "バッツ", level = 3},
                new Character {name = "ティナ", level = 2},
            };

            // アイテムは以下が存在している
            var items = new List<Item>
            {
                new Item {id = 1, name = "眠りの剣", type = 1, value = 10},
                new Item {id = 2, name = "伝説の剣", type = 1, value = 11},
                new Item {id = 3, name = "古代の剣", type = 1, value = 12},
                new Item {id = 4, name = "珊瑚の剣", type = 1, value = 13},
                new Item {id = 5, name = "斬鉄剣",   type = 1, value = 14},
                new Item {id = 6, name = "英雄の盾", type = 2, value = 10},
                new Item {id = 7, name = "源氏の盾", type = 2, value = 11},
            };

            // それぞれのタイプ毎にキャラに装備を行う
            // レベルが低い順にvalueが高いものを装備させよ
            // 新規で変数を追加して実装することは禁止、クラスに手を加えるのも禁止

            // キャラ達の装備品にアイテムのIDが一致しているか
            // 無かったらそのまま代入でおｋ
            // 有ったらどうすればいいのかが分からん
            //　
            characters = characters.OrderBy(x => x.level).ToList();
            //思考用の一時変数
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].equipmentType1 =      
                items.Where(x => x.type == 1 && !characters.Any(X => X.equipmentType1 == x.id))
                .OrderByDescending(x => x.value)    
                .Select(x => x.id)                  
                .FirstOrDefault();                  

                characters[i].equipmentType2 =      //キャラの装備2に
                items.Where(x => x.type == 2 && !characters.Any(X => X.equipmentType2 == x.id))       //アイテムのタイプ[2]でソート
                .OrderByDescending(x => x.value)    //valueの降順で並べ替え
                .Select(x => x.id)                  //アイテムのIDのみの配列に書き換え
                .FirstOrDefault();                  //先頭の配列を取得する
            }
            

            // --------------------------------------------------------------------------------------
            // 以下は触ってはいけない　※出力結果にバグがあれば触ってください
            // --------------------------------------------------------------------------------------

            // 以下出力用
            // 期待値
            // --------------------------
            // セシル Lv.1 武器: 斬鉄剣, 防具: 源氏の盾
            // バッツ Lv.3 武器: 古代の剣, 防具: なし
            // ティナ Lv.2 武器: 珊瑚の剣, 防具: 英雄の盾
            foreach (var character in characters)
            {
                var item1 = items.FirstOrDefault(v => v.id == character.equipmentType1);
                var item2 = items.FirstOrDefault(v => v.id == character.equipmentType2);
                var label1 = item1 != null ? item1.name : "なし";
                var label2 = item2 != null ? item2.name : "なし";
                Debug.Log($"{character.name} Lv.{character.level} 武器: {label1}, 防具: {label2}");
            }

            // 以下出力用
            // 期待値
            // --------------------------
            // 眠りの剣 値: 10
            // 伝説の剣 値: 11
            // 古代の剣 値: 12 バッツが装備中
            // 珊瑚の剣 値: 13 ティナが装備中
            // 斬鉄剣 値: 14 セシルが装備中
            // 英雄の盾 値: 10 ティナが装備中
            // 源氏の盾 値: 11 セシルが装備中
            foreach (var item in items)
            {
                var character = characters
                    .FirstOrDefault(v => v.equipmentType1 == item.id || v.equipmentType2 == item.id);
                var label = character != null ? $"{character.name}が装備中" : "";
                Debug.Log($"{item.name} 値: {item.value} {label}");
            }
        }
    }



    public class Character
    {
        public string name;
        public int level;
        public int equipmentType1;
        public int equipmentType2;
    }

    public class Item
    {
        public int id;
        public string name;
        public int type;
        public int value;
    }
}