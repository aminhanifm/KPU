using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState
{
    public LevelState.moreStates _moreStates;
    public LevelState(
        LevelState.moreStates moreStates)
    {
        _moreStates = moreStates;
    }

    public readonly Dictionary<States, string> stateMap = new Dictionary<States, string>
    {
        { States.antri, "antri"},
        { States.coblos, "coblos"},
        { States.masukinkertas, "masukinkertas"},
        { States.celup, "celup"},
        { States.selesai, "selesai"},
    };
    
    public States current { get; set; }
    public States previous { get; set; }

    public ISegment currentSegment { get; set; }

    public bool Compare(string name)
    {
        Debug.Log(stateMap[current] + " " + name);
        if (stateMap[current] != name)
            return false;
        return true;
    }

    public class moreStates
    {
        public bool moveAllowed { get; set; }
        public bool selectAllowed { get; set; }
        public List<int> machineSelects { get; set; }
        public List<int> playerSelects { get; set; }

        public int kotakId { get; set; }

        public List<string> DPR { get; set; }
        public List<string> DPRD_Jatim { get; set; }
        public List<string> DPRD_Surabaya { get; set; }

        private List<string> names = new List<string>
        {
            "Farah",
            "Yance",
            "Palastri",
            "Zelda",
            "Haryanti",
            "Ade",
            "Andriani",
            "Rahayu",
            "Kusmawati",
            "Zamira",
            "Zahra",
            "Wahyuni",
            "Kasiyah",
            "Ratna",
            "Winarsih",
            "Ifa",
            "Lalita",
            "Susanti",
            "Puspasari",
            "Kamaria",
            "Mardhiyah",
            "Melinda",
            "Padmasari",
            "Mutia",
            "Nurdiyanti",
            "Vicky",
            "Hariyah",
            "Kamaria ",
            "Novitasari",
            "Yunita ",
            "Mandasari",
            "Devi ",
            "Oktaviani",
            "Jelita ",
            "Lailasari ",
            "Diana ",
            "Nasyiah",
            "Zelda ",
            "Endah ",
            "Safitri",
            "Ana ",
            "Halimah",
            "Tina ",
            "Rahmawati",
            "Talia ",
            "Kezia ",
            "Sudiati",
            "Yuliarti",
            "Hasanah",
            "Handayani",
            "Yolanda",
            "Nasyidah",
            "Padmasari",
            "Anggraini",
            "Nasyiah",
            "Oktaviani",
            "Cornelia",
            "Najwa",
            "Usada",
            "Melani"
        };

        public void reset()
        {
            moveAllowed = false;
            selectAllowed = true;
            machineSelects = new List<int> { -1, -1, -1, -1, -1};
            playerSelects = new List<int> { -1, -1, -1, -1, -1 };

            DPR = setRandomName(36);
            DPRD_Jatim = setRandomName(36);
            DPRD_Surabaya = setRandomName(36);

            kotakId = -1;
        }

        public void GenerateCalonSelection()
        {
            //presiden
            machineSelects[0] = Random.Range(0, 2);

            //DPD RI
            machineSelects[1] = Random.Range(0, 9);

            //DPR RI
            machineSelects[2] = Random.Range(0, DPR.Count-1);

            //DPRD JATIM
            machineSelects[3] = Random.Range(0, DPRD_Jatim.Count-1);

            //DPRD Surabaya
            machineSelects[4] = Random.Range(0, DPRD_Surabaya.Count -1);
        }

        private List<string> setRandomName(int num)
        {
            List<string> _names = new List<string>(names);
            List<string> baru = new List<string>();
            for(var i=0; i<num; i++)
            {
                int a = Random.Range(0, _names.Count-1);
                baru.Add(_names[a]);
                _names.RemoveAt(a);
            }

            return baru;
        }
    }
}
