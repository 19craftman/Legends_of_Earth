using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Rewired;


public class ModSelect : MonoBehaviour
{

    private Text[] ButtonText;
    public Button[] TheButton;
    public GameObject[] ButtonObject;
    private string[] Mods = { "Flappy Jump", "Double Jump", "Icy Floors", "Jet Pack" };
    private string[] NamesMods = { "Flappy_Jump", "Double_Jump", "Icy_Floors", "Jet_Pack" };
    private int modNumber;
    private int rand;
    //private int count;
    private float timer;
    private int buttonClick;
    private bool isclicked;
    public GameObject timingsystem;
    public static List<int> AddedModifiers = new List<int>();
    private int selector;
    // private int randomadd;
    private int themodifier;
    public GameObject selected;
    [SerializeField] private Player player;

    //private int made;
    // Start is called before the first frame update
    private void Awake()
    {
        player = ReInput.players.GetPlayer(0);
        player.isPlaying = true;
    }
    void Start()
    {
        timer = 1;
        AddedModifiers.Clear();
        selected.SetActive(false);

        //count = 0;
        for (int i = 0; i < TheButton.Length; i++)
        {
            MakingButtons(i);
            //NumberOfButtons();
            // ButtonText[i].text = Mods[Random.Range(0, Mods.Length)];
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        if (timingsystem.GetComponent<timer>().time == 0 || AddedModifiers.Count == 2)
        {
            if (AddedModifiers.Count > 0)
            {
                //randomadd = Random.Range(0, 3);
                selector = Random.Range(0, AddedModifiers.Count);

                themodifier = AddedModifiers[selector];
                //Debug.Log(themodifier + " The Mod");
                PlayerPrefs.SetInt("ModInt", themodifier);


                SceneManager.LoadScene(PlayerPrefs.GetString("course"));
            }
            else
            {
                selector = Random.Range(0, 3);

                // = AddedModifiers[selector];
                //Debug.Log(selector + " The Mod");
                PlayerPrefs.SetInt("ModInt", selector);
                SceneManager.LoadScene(PlayerPrefs.GetString("course"));
            }

        }

        if (AddedModifiers != null && AddedModifiers.Count >= 0)
        {

            Debug.Log(AddedModifiers.Count);
        }
    }
    //public void NumberOfButtons() 
    //{
    //    if (count < TheButton.Length)
    //    {
    //        //MakingButtons();
    //        count++;
    //    }
    //}

    public void MakingButtons(int count)
    {
        rand = Random.Range(0, Mods.Length);
        if (Mods[rand] != null)
        {
            //ButtonObject = TheButton[count];
            TheButton[count].name = NamesMods[rand];
            TheButton[count].GetComponentInChildren<Text>().text = Mods[rand];
            Mods[rand] = null;
        }
        else
        {
            MakingButtons(count);
        }
    }

    public void OnClickedButton()
    {
        
        string name = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        if (timer <= 0)
        {
            Debug.Log("clicked");
            if (name == "Flappy Jump")
            {

                modNumber = 0;
                AddedModifiers.Add(modNumber);
                Debug.Log("Flappy Jump");
                for (int i = 0; i < TheButton.Length; i++)
                {
                    TheButton[i].enabled = false;
                }
                selected.SetActive(true);
            }
            else if (name == "Double Jump")
            {
                modNumber = 1;
                AddedModifiers.Add(modNumber);
                Debug.Log("Double Jump");
                for (int i = 0; i < TheButton.Length; i++)
                {
                    TheButton[i].enabled = false;
                }
                selected.SetActive(true);
            }
            else if (name == "Icy Floors")
            {
                modNumber = 2;
                AddedModifiers.Add(modNumber);
                Debug.Log("Icy Floors");
                for (int i = 0; i < TheButton.Length; i++)
                {
                    TheButton[i].enabled = false;
                }
                selected.SetActive(true);
            }
            else if (name == "Jet Pack")
            {
                modNumber = 3;
                AddedModifiers.Add(modNumber);
                Debug.Log("Jet Pack");
                for (int i = 0; i < TheButton.Length; i++)
                {
                    TheButton[i].enabled = false;
                }
                selected.SetActive(true);
            }
            else
            {
                AddedModifiers.Add(modNumber);
                Debug.Log("I like Toast");
                for (int i = 0; i < TheButton.Length; i++)
                {
                    TheButton[i].enabled = false;
                }
                selected.SetActive(true);
            }
        }

    }

}
