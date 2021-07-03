using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreanKibodeu
{
    class KanaConvertClass
    {
        public KanaConvertClass()
        {
        }

        public string Convert(string msg, bool isHiragana)
        {
            if (isHiragana)
            {
                //Hiragana

                msg = msg.Replace("shi", "si");
                msg = msg.Replace("chi", "ti");
                msg = msg.Replace("tsu", "tu");
                msg = msg.Replace("fu", "hu");
                msg = msg.Replace("ji", "zi");
                msg = msg.Replace("dji", "di");
                msg = msg.Replace("dzu", "du");

                string abcJpC = "wrymhntskbdzgp";
                string abcJpV = "aiueo";

                List<string> hiraganaABC = new List<string>();
                hiraganaABC.Add("わらやまはなたさかばだざがぱ");
                hiraganaABC.Add(" り みひにちしきびぢじぎぴ");
                hiraganaABC.Add(" るゆむふぬつすくぶづずぐぷ");
                hiraganaABC.Add(" れ めへねてせけべでぜげぺ");
                hiraganaABC.Add("をろよもほのとそこぼどぞごぽ");

                for (int v = 0; v < abcJpV.Length; v++)
                {
                    for (int c = 0; c < abcJpC.Length; c++)
                    {
                        if (hiraganaABC[v][c].ToString() != " ")
                            msg = msg.Replace(abcJpC[c].ToString() + abcJpV[v].ToString(), hiraganaABC[v][c].ToString());
                    }
                }

                string hiraganaN = "なにぬねの";

                for (int i = 0; i < hiraganaN.Length; i++)
                {
                    msg = msg.Replace("ん" + abcJpV[i].ToString(), hiraganaN[i].ToString());
                }

                string hiraganaA = "あいうえお";

                for (int a = 0; a < hiraganaA.Length; a++)
                {
                    msg = msg.Replace(abcJpV[a], hiraganaA[a]);
                }

                msg = msg.Replace("n", "ん");

                //Sutegana
                msg = msg.Replace("YA", "ゃ");
                msg = msg.Replace("YU", "ゅ");
                msg = msg.Replace("YO", "ょ");

                msg = msg.Replace("TSU", "TU");
                msg = msg.Replace("TU", "っ");

                string suteganaABCa = "ぁぃぅぇぉ";

                for (int i = 0; i < suteganaABCa.Length; i++)
                {
                    msg = msg.Replace(abcJpV[i].ToString().ToUpper(), suteganaABCa[i].ToString());
                }

                msg = msg.Replace("v", "ゔ");
            }
            //Katakana   

            //wrymhntskbdzgp
            string hiraganaABC2
                = "わらやまはなたさかばだざがぱ" //a
                + "りみひにちしきびぢじぎぴ" //i
                + "るゆむふぬつすくぶづずぐぷ" //u
                + "れめへねてせけべでぜげぺ" //e
                + "をろよもほのとそこぼどぞごぽ" //o
                + "あいうえお" //A
                + "ん" //N
                + "ゔ" //v
                + "ゃゅょっぁぃぅぇぉ"; //Sutegana

            //wrymhntskbdzgp     
            string katakanaABC
                = "ワラヤマハナタサカバダザガパ" //a
                + "リミヒニチシキビヂジギピ" //i
                + "ルユムフヌツスクブヅズグプ" //u
                + "レメヘネテセケベデゼゲペ" //e
                + "ヲロヨモホノトソコボドゾゴポ" //o
                + "アイウエオ" //A
                + "ン" //N
                + "ヴ" //v
                + "ャュョッァィゥェォ"; //Sutegana

            for (int i = 0; i < hiraganaABC2.Length; i++)
            {
                if(isHiragana)
                    msg = msg.Replace(katakanaABC[i], hiraganaABC2[i]);
                else
                    msg = msg.Replace(hiraganaABC2[i], katakanaABC[i]);
            }

            string katakanaN = "アイウエオ";
            string katakanaNX = "ナニヌネノ";

            for (int i = 0; i < katakanaN.Length; i++)
            {
                msg = msg.Replace("ン" + katakanaN[i].ToString(), katakanaNX[i].ToString());
            }

            return msg;
        }
    }
}
