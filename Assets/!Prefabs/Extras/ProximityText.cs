using UnityEngine;
using TMPro;

public class ProximityText : MonoBehaviour
{
    [Header("Message")]
    public string message;
    
    
    [Header("TextOptions")]
    public bool isOpen;
    public bool isAevesdropping; 
    private bool readyToSkip;
    public int maxCharacterLength;
    public float letterDelay;
    private float delayTimer;
    private float delayParagraphTimer;
    public float distanceToActivate=3;
    private int letter;
    private int stanza;
    

    [Header("GameObjects")]
    //These are already called by themselves, no need to edit
    public GameObject player;
    public GameObject self;
    public GameObject textBox;
    

    void Start()
    {
        player=GameObject.Find("Player");
        delayParagraphTimer=5*letterDelay;
    }
    
    void Update()
    {
        if(Vector3.Distance (player.transform.position, self.transform.position)<distanceToActivate)
        {
            isAevesdropping=true;
            self.GetComponent<Animator>().SetBool("Eavesdropping",true);
        }
        else
        {
            isAevesdropping=false;
            self.GetComponent<Animator>().SetBool("Eavesdropping",false);
        }
        
        
    }

    void FixedUpdate()
    {
        if(isOpen)
        {
            textBox.SetActive(true);
            if(delayTimer<=0)
            {
                //checks if message substring wont cause an error
                if(letter+stanza*maxCharacterLength<message.Length)
                { 
                    //checks if message is within the max character length
                    if(letter+1<=maxCharacterLength)
                    {
                        letter++;  
                        self.GetComponentInChildren<TMPro.TextMeshProUGUI>().text=message.Substring(0+stanza*maxCharacterLength,letter);
                    }
                    
                    //if it doesn't fit it starts a countdown to the next paragraph or "stanza"
                    else
                    {
                        if(readyToSkip)
                        {
                            readyToSkip=false;
                            delayParagraphTimer=5*letterDelay;
                            stanza++;
                            letter=0;  
                        }
                        else
                        {
                            delayParagraphTimer-=Time.deltaTime;
                            if(delayParagraphTimer<=0)
                            {
                                readyToSkip=true;
                            }
                        }
                    }
                }
                

                
                
                delayTimer=letterDelay;
            }
            delayTimer-=Time.deltaTime;

            
        }
        else
        {
            textBox.SetActive(false);
            stanza=0;
            letter=0;
        }

        
    }

    //in future expand to ignore spaces and keep words whole. 

    public void ResetText()
    {

    }
}
