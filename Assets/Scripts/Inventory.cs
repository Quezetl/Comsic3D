using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public GameObject promptmsg;
    public GameObject MasterKey;
    public GameObject Tool;
    public GameObject[] MemosButtons;
    public GameObject[] CapLogButtons;
    public GameObject[] aLogButtons;
    public GameObject[] JournalButtons;
    public GameObject[] HiddenButtons;
    public GameObject InvenMenu;
    public GameObject textLogBody;
    public GameObject CapEntries;
    public GameObject AudioEntries;
    public GameObject MemoEntries;
    public GameObject JournalEntries;



    string[] capLogContent;
    string[] aLogContent;
    string[] memoContent;
    string[] journalContent;

    public bool[] CapLogBool = new bool[7] { false, false, false, false, false, false, false };
    public bool[] aLogsBool = new bool[4] { false, false, false, false };
    public bool[] memoBool = new bool[4] { false, false, false, false };
    public bool journalprevBool = false;

    int num;
    RaycastHit mousePos;

    // Start is called before the first frame update
    void Start()
    {
        capLogContent = new string[7];
        aLogContent = new string[4];
        memoContent = new string[4];
        journalContent = new string[4];
        LogContentInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Time.timeScale == 1)
            {
                inventoryMenu();
            }
            else if (Time.timeScale == 0)
            {
                exitInventoryMenu();
            }
        }




        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mousePos);
        if (!hit)
            return;
        if(mousePos.collider.tag == "audioLogs" || mousePos.collider.tag == "capLogs" || mousePos.collider.tag == "memoLogs" || mousePos.collider.tag == "journalLogs")
        {
            ItemPickup();
        }
        else
            promptmsg.SetActive(false);

    }

    void exitInventoryMenu()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        InvenMenu.SetActive(false);
    }

    void inventoryMenu()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        InvenMenu.SetActive(true);
        CapEntries.SetActive(false);
        AudioEntries.SetActive(false);
        MemoEntries.SetActive(false);
        JournalEntries.SetActive(false);
        for (int i = 0; i < 7; i++)
        {
            HiddenButtons[i].SetActive(false);
        }
    }


    public void DisplayCapLogOptions()
    {
        textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = "";

        CapEntries.SetActive(true);
        AudioEntries.SetActive(false);
        MemoEntries.SetActive(false);
        JournalEntries.SetActive(false);


        for (int i = 0; i < 7; i++)
        {
            if (CapLogBool[i] == true)
            {
                CapLogButtons[i].SetActive(true);
                HiddenButtons[i].SetActive(false);
            }
            else
            {
                CapLogButtons[i].SetActive(false);
                HiddenButtons[i].SetActive(true);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            JournalButtons[i].SetActive(false);
            MemosButtons[i].SetActive(false);
            aLogButtons[i].SetActive(false);
        }

        Debug.Log("Caption Log Tab button pressed.");
    }


    public void DisplayAudioLogOptions()
    {
        textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = "";

        CapEntries.SetActive(false);
        AudioEntries.SetActive(true);
        MemoEntries.SetActive(false);
        JournalEntries.SetActive(false);


        for (int i = 0; i < 7; i++)
        {
            if (i < 4)
            {
                MemosButtons[i].SetActive(false);
            }
            CapLogButtons[i].SetActive(false);
        }

        for (int i = 0; i < 4; i++)
        {
            if (aLogsBool[i] == true)
            {
                aLogButtons[i].SetActive(true);
                HiddenButtons[i].SetActive(false);
            }
            else
            {
                HiddenButtons[i].SetActive(true);
                aLogButtons[i].SetActive(false);
            }
        }
        Debug.Log("audio Log Tab button pressed.");
    }


    public void DisplayMemoLogOptions()
    {
        textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = "";

        CapEntries.SetActive(false);
        AudioEntries.SetActive(false);
        MemoEntries.SetActive(true);
        JournalEntries.SetActive(false);


        for (int i = 0; i < 7; i++)
        {
            if (i < 4)
            {
                aLogButtons[i].SetActive(false);
            }
            CapLogButtons[i].SetActive(false);
        }

        for (int i = 0; i < 4; i++)
        {
            if (memoBool[i] == true)
            {
                MemosButtons[i].SetActive(true);
                HiddenButtons[i].SetActive(false);
            }
            else
            {
                HiddenButtons[i].SetActive(true);
                MemosButtons[i].SetActive(false);
            }
        }
        Debug.Log("memo Log Tab button pressed.");
    }


    public void DisplayJournalLogOptions()
    {
        textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = "";

        CapEntries.SetActive(false);
        AudioEntries.SetActive(false);
        MemoEntries.SetActive(false);
        JournalEntries.SetActive(true);


        for (int i = 0; i < 7; i++)
        {
            if (i < 4)
            {
                aLogButtons[i].SetActive(false);
                MemosButtons[i].SetActive(false);
            }
            CapLogButtons[i].SetActive(false);
        }

        for (int i = 0; i < 4; i++)
        {
            if (journalprevBool == true)
            {

                JournalButtons[i].SetActive(true);
                HiddenButtons[i].SetActive(false);
            }
            else
            {
                JournalButtons[i].SetActive(false);
                HiddenButtons[i].SetActive(true);
            }
        }
        Debug.Log("journal Log Tab button pressed.");
    }

    public void TextCapbody(int num)
    {
        if (CapLogBool[num] == false)
        {
            textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = "???";
            Debug.Log("Cap journal button isn't available");
            return;
        }

        textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = capLogContent[num];

        Debug.Log($"Caption journal entry button number {num} has been pressed.");
    }

    public void TextaLogbody(int num)
    {
        if (aLogsBool[num] == false)
        {
            textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = "???";
            Debug.Log("Audio journal button isn't available");
            return;
        }

        textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = aLogContent[num];

        Debug.Log($"Audio journal entry button number {num} has been pressed.");
    }
    public void TextMemobody(int num)
    {
        if (memoBool[num] == false)
        {
            textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = "???";
            Debug.Log("Memo journal button isn't available");
            return;
        }

        textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = memoContent[num];

        Debug.Log($"Memo journal entry button number {num} has been pressed.");
    }
    public void TextJournalbody(int num)
    {
        if (journalprevBool == false)
        {
            textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = "???";
            Debug.Log("Journal journal button isn't available");
            return;
        }

        textLogBody.GetComponentInChildren<TMPro.TextMeshProUGUI>(textLogBody).text = journalContent[num];

        Debug.Log($"Journal journal entry button number {num} has been pressed.");
    }


    void ItemPickup()
    {
        promptmsg.SetActive(true);
        if (mousePos.collider.tag == "capLogs")
        {
            num = int.Parse(mousePos.collider.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                CapLogBool[num] = true;
                mousePos.transform.gameObject.SetActive(false);
                Destroy(mousePos.transform.gameObject);
            }
        }
        else if (mousePos.collider.tag == "audioLogs")
        {
            num = int.Parse(mousePos.collider.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                aLogsBool[num] = true;
                mousePos.transform.gameObject.SetActive(false);
            }
        }
        else if (mousePos.collider.tag == "memoLogs")
        {
            num = int.Parse(mousePos.collider.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                memoBool[num] = true;
                mousePos.transform.gameObject.SetActive(false);
            }
        }
        else if (mousePos.collider.tag == "journalLogs")
        {
            if (Input.GetKey(KeyCode.E))
            {
                journalprevBool = true;
                mousePos.transform.gameObject.SetActive(false);
            }
        }
    }




    void LogContentInit()
    {
        capLogContent[0] = "Date: X00047938\r\nLocation: NX-3942b-45\r\nMission Status: Delayed\r\n\tDue to a landing mishap the ship is currently damaged. The cause of this is currently under investigation. We will be commencing repairs when the sun rises. \r\n";
        capLogContent[1] = "Date: X00047940\r\nLocation: NX-3942b-45\r\nMission Status: Delayed\r\n\tThe crew has been repairing the ship, but the completion date will be further than predicted. The terrain is limiting our ability to maneuver and is consuming much of our time. The ground is too soft to support the weight of the ship, so we must move it intermittently to prevent it from sinking too deep.\r\n\tThis is strange. The records on NX-3942b-45 state that its terrain should be hard-packed and undisturbed, but this almost seems like freshly placed soil. We currently suspect that NX-3942b-45 being several hundred kilometers off of its usual orbit may be the cause.\r\n\tWith the whole planet misplaced, our coordinates for the federal checkpoint on this planet are null. Once repairs are done we will return to base and plan our next steps from there.\r\n";
        capLogContent[2] = "Date: X00047944\r\nLocation: NX-3942b-45\r\nMission Status: Delayed\r\n\tRepairs have been further delayed. 1021 is ill, which is common for being on a new planet for the first time, but I am more concerned for their mental state. They seem to blame themself for the damage the ship took while landing. They would not listen when I assured them that they were not at fault and this was a unique case, so I excused them from repair work to rest.\r\n\tThe rest of the crew seemed to agree with my decision. We must prioritize each other’s health and safety above blame. I just hope that 1021 will come to understand that this is how we feel.\r\n\tAs for repairs, we lack a few of the necessary supplies so we are currently gathering raw materials to process into metal to build them. The iron and carbon content in the soil is consistent to what our records say, however there is almost no moisture left. The atmosphere is intact but the soil and rocks seem like they have been freeze-dried in space. Our only lead is NX-3942b-45’s sudden change in orbit, but I am not sure if that will be able to explain everything.\r\n\tI have also been monitoring all the signal emissions in the area in case any other Federal ships pass by, but there were none scheduled to come this way anytime soon so I am not relying on it. I did notice that the frequencies were even regardless of position. It’s as if there is a weak signal surrounding us. This does take lowest priority, as it does not interfere with our ability to send and receive signals, so we will leave the matter for now.\r\nIt will take a few days until we have processed enough soil and rocks to extract enough iron to build replacement parts. I hope we can reach that stage with no further complications.\r\n";
        capLogContent[3] = "Date: X00047943\r\nLocation: NX-3942b-45\r\nRepairs are taking forever. I guess we could’ve been a bit more thorough when restocking the ship before leaving, but it’s not like anyone could’ve expected this to happen on a simple checkup mission.\r\n\tI’m actually kinda worried about 1021. They’ve been acting weird lately and no one’s seemed to notice. When I tried talking to them they snapped at me and left. They’ve always been a bit jumpy but I’ve never seen them get angry so quickly. I tried talking to them a few more times but I think it’s pretty clear that they want to be alone.\r\n\tI guess I’ll leave it for now. Hopefully we can leave soon and 1021 will feel better once we’re back at base.\r\n ";
        capLogContent[4] = "Date: X00047947\r\nLocation: NX-3942b-45\r\nCaptain isn’t listening to me. 1021 has been acting suspicious as hell but she won’t take me seriously. I saw them lurking around the supply storage and now the parts we spent so long making are missing.\r\nShe says I shouldn’t cast doubt on a crewmate. It’s not like I want to, it’s not like this is fun for me. It’s more than just our mission at stake here. It could easily escalate our lives.\r\nI need to reason with the others. Maybe then the captain will listen. If we can abandon the ship and leave on the escape pods we’ll be shamed but at least we’ll be alive.\r\n";
        capLogContent[5] = "Date: X00047950\r\nLocation: NX-3942b-45\r\nThat fucking bastard disabled the escape pods and changed the code to restart them. I almost stole the code but they clocked me with a fire extinguisher and ran off with it. \r\n\tThe crew doesn’t want me to go after them cause I’m injured, but they’re going to try to reason with 1021 and it won’t work. \r\n\tThey still have the code, I need to get it. No matter what.\r\n";
        capLogContent[6] = "Date: X00047952\r\nLocation: NX-3942b-45\r\nMission Status: Canceled\r\n\tNX was gone before we even arrived.\r\n\r\n\r\n\r\n\tWatch the frequencies.\r\n\r\nDon’t move.\r\n";
        aLogContent[0] = "Today is… Um. Oh, it’s day 4 on this planet. The day-night cycles are a lot longer here so it’s easy to lose track. Anyway, I’m recording this just to have somewhere to put my thoughts. It’s, uh, kinda nerve wracking here to say the least. There’s something weird with this whole situation. Even the captain seems uneasy- not that she’d ever admit it. I just hope we can finish repairs soon and get the hell out of here. I want to go home and stay there for a while. Maybe I’ll even use my vacation time once we’re back.";
        aLogContent[1] = "“Today is….. day 7 here. I think. I’ve been avoiding all the computers cause listening to its voice updating us every 10 seconds while processing dirt was driving me insane. Why do we need so many updates anyway? Just tell me when you start and when you finish. Anyway, 1021 is so lucky. Maybe if I pretend to be sick the captain will go easy on me too. Not that she’d buy it, I suck at acting.”";
        aLogContent[2] = "Day whatever whatever. 1021 had us in a bit of a panic today. They disappeared without saying a word and it was getting dark out. Luckily 1017 noticed them sneaking around that cave entrance a bit away. There were a bunch of these gross bug things in there that 1003 seemed interested in for some reason. We found 1021 sleeping in there like a baby. Wish I could be that carefree. We were pretty quiet in there, but when we were dragging them out I got? well I got kinda winded. Sue me. Those bug things did NOT appreciate my panting. We managed to get out of there before they got too feisty. I really don’t want to go back there.";
        aLogContent[3] = "Bad news, we had to go back there. Can confirm that the bugs do not like noise. I think I’ll have nightmares for at least a week, if we make it that long.";
        memoContent[0] = "MEMO 1003 [<-- this part is text while the rest is handwritten]\r\nrepair supplies:\r\n•\tsun bolts (50-60)\r\n•\tleft fin- only one left\r\n•\tlanding pivot axle\r\n";
        memoContent[1] = "MEMO 1003\r\nfood- maybe 15 more day/night cycles\r\nO2- 31 tanks left\r\n       not sure how to ration between the 5 of us\r\nfjds\r\n";
        memoContent[2] = "MEMO 1003\r\nparasite-like fauna\r\n•\tpale, lives underground in the tunnel\r\n•\tred eyes\r\n•\theavy sleepers\r\n•\taggravated by touch- tunnel shakes when they start digging (eating away structural integrity?)";
        memoContent[3] = "MEMO 1003\r\ndon’t touch the parasites\r\n";
        journalContent[0] = "\tI’ve been feeling really sick lately. The whole crew has been looking at me with pity. I can tell they wish I never joined their team.\r\n\tCaptain told me to take it easy and that my health is everyone’s top priority. She just wants to get me out of the way. I didn’t want to be on the ship anymore so I walked around outside until it got dark.\r\n\tThere’s a cave entrance a few hundred meters away from the ship. I think there’s something living inside it but it hasn’t bothered us so I left it alone. The mountains were too steep for me to cross, so I couldn’t go very far. I wish I found something useful.\r\n";
        journalContent[1] = "\tI can hear something. It sounds like a heartbeat. I know it’s not mine. I’ve asked the others and they looked at me like I’m crazy. I’m not crazy.\r\n\tI think it’s coming from the cave. I felt it when I first checked it out. It’s so slow. I want the sound to stop but I also want to find whatever is making it. Just to find something that’s alive on this planet, something that wants to live just as much as we do.\r\n\tI’ll look for it tomorrow.\r\n";
        journalContent[2] = "\tThe cave goes so deep, I felt like I walked for hours. I think I fell asleep there. When I woke up I was back at the ship. Captain says that the others had to drag me back. I think they should’ve minded their damn business. \r\n\tI could feel it in the walls. The deeper I went the more it pulsed like it was alive. It’s watching us. It knows we’re here and it’s going to wake up soon.\r\n";
        journalContent[3] = "\tWe don’t need to escape. There’s no point anyway. We can’t escape. If we die now it will be much less painful. Maybe I can be useful at last.";

    }


}
