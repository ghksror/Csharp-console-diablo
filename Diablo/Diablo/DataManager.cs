using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using static System.Console;
namespace Diablo
{
    class DataManager
    {

        private static DataManager instance;
        private const string DATA_PATH = "./Datas";
        private Dictionary<int, Characterdata> dicCharacterDatas;
        private Dictionary<int, Weapondata> dicWeaponDatas;
        private Dictionary<int, Monsterdata> dicMonsterDatas;
        private DataManager()
        {
            this.dicCharacterDatas = new Dictionary<int, Characterdata>();
            this.dicWeaponDatas = new Dictionary<int, Weapondata>();
            this.dicMonsterDatas = new Dictionary<int, Monsterdata>();
        }

        public static DataManager GetInstance()
        {
            if (DataManager.instance == null) DataManager.instance = new DataManager();
            return DataManager.instance;
        }

        public void LoadAllDatas()
        {
            string path = string.Format("{0}/{1}", DATA_PATH, "Character_data.json");
            string json = File.ReadAllText(path);
            this.dicCharacterDatas = JsonConvert.DeserializeObject<Characterdata[]>(json).ToDictionary(x => x.id);

            path = string.Format("{0}/{1}", DATA_PATH, "Weapon_data.json");
            json = File.ReadAllText(path);
            this.dicWeaponDatas = JsonConvert.DeserializeObject<Weapondata[]>(json).ToDictionary(x => x.id);

            path = string.Format("{0}/{1}", DATA_PATH, "Monster_data.json");
            json = File.ReadAllText(path);
            this.dicMonsterDatas = JsonConvert.DeserializeObject<Monsterdata[]>(json).ToDictionary(x => x.id);

            WriteLine("모든 데이터를 로드 했습니다.");
            WriteLine("캐릭터 데이터 : {0}개", this.dicCharacterDatas.Count);
            WriteLine("무기 데이터 : {0}개", this.dicWeaponDatas.Count);
            WriteLine("몬스터 데이터 : {0}개", this.dicMonsterDatas.Count);

            /*Characterdata[] characterdatas = JsonConvert.DeserializeObject<Characterdata[]>(json);
            foreach (Characterdata characterdata in characterdatas)
            {
                this.dicCharacterDatas
            }*/


        }

        public Characterdata[] GetCharacterDatas()
        {
            /*Characterdata[] arr = new Characterdata[this.dicCharacterDatas.Values.Count];
            int i = 0;
            foreach(var val in this.dicCharacterDatas.Values)
            {
                arr[i++] = val;
            }
            return arr;*/

            return this.dicCharacterDatas.Values.ToArray();
        }

        public Weapondata GetWeaponData(int characterid)
        {
            var characterDate = this.dicCharacterDatas[characterid];
            var weaponData = this.dicWeaponDatas[characterDate.defaultWeaponid];
            return weaponData;
        }

    }
}
