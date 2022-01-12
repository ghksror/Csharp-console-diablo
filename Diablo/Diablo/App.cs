using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Diablo
{
    class App
    {
        public enum eCharacterType
        {
           NONE, BARBARIAN, AMAZON, SOSURISE, PALADIN
        }
        public App()
        {
            DataManager.GetInstance().LoadAllDatas();

            WriteLine("*************************");
            WriteLine("*******Diablo************");
            WriteLine("*******Game Start********");
            WriteLine("*************************");

            Characterdata[] characterdatas = DataManager.GetInstance().GetCharacterDatas();
            for (int i = 0; i < characterdatas.Length; i++)
            {
                var data = characterdatas[i];
                int idx = i + 1;
                WriteLine("{0},{1}", idx,data.name);
            }
            WriteLine("캐릭터를 선택해주세요(숫자 1~4) : ");
            string input = ReadLine();
            int num = int.Parse(input);
            Characterdata selecteCharacterData = characterdatas[num - 1];
            WriteLine("어서오시게나 {0} 용사여...", selecteCharacterData.name);
            WriteLine("무기를 주겠네...");

            eCharacterType characterType = (eCharacterType)num;

            Weapondata weapondata = DataManager.GetInstance().GetWeaponData(selecteCharacterData.id);

            Weapon defaultWeapon = new Weapon(weapondata.id);

            // Test colors with blue background, white foreground. (무기이름 색 변경해보기)
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Write(weapondata.name);
            ResetColor();

            Write("을(를) 획득 했습니다.");
            WriteLine();

            if (characterType == eCharacterType.PALADIN)
            {
                WriteLine("단검을 획득했습니다.");
                WriteLine("앗");
                WriteLine("난 팔라딘인데...");
                WriteLine("단검밖에 준비가 되지 않았네 미안하네...");
            }

            /*switch (characterType)
            {
                case eCharacterType.BARBARIAN:
                    WriteLine("장검을 획득했습니다.");
                    break;
                case eCharacterType.AMAZON:
                    WriteLine("활을 획득했습니다.");
                    break;
                case eCharacterType.SOSURISE:
                    WriteLine("지팡이를 획득했습니다.");
                    break;
                case eCharacterType.PALADIN:
                    WriteLine("단검을 획득했습니다.");
                    WriteLine("앗");
                    WriteLine("난 팔라딘인데...");
                    break;
            }*/

        }
    }
}
