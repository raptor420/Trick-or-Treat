using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour {


    // public List<Recipes> ProblemItems;

     
    public Items[] items;
    [SerializeField]
    Items selectedItem;
    [SerializeField]
    CouldronInventory couldroninv;
    [SerializeField]
    int score=0;
    [SerializeField]
    float TimeLimit;
    [SerializeField]
    float penalizeTime;
    [SerializeField]
    bool ReadyToPlay = false;
    [SerializeField]

    bool GameOver = false;
    [SerializeField]
    UIMANAGER ui;
    float TempTimelimit = 0;
    void Start()
    {
        score = 0;
        TempTimelimit = TimeLimit;
        ui.UpdateScoreText(score);
        ReadyToPlay = false;
        GameOver = false;
        couldroninv.gameObject.SetActive(false);
        Debug.Log("pressZ");



    }

    
   public  int  GetRandomItemTypeIndex()
    {

        int i = Random.Range(0,items.Length);
       
        return i;


    }
    [ContextMenu("Go")]
    public Items SetSelectedItem()
    {
        selectedItem = items[GetRandomItemTypeIndex()];
        ui.showItem(selectedItem.type.ToString());
        return selectedItem;
    }

    public bool GetPoint()
    {
        if(couldroninv.Result.type ==selectedItem.type)
        {
            return true;
        }
        return false;
    }
    public void StartGame()
    {
        ui.UpdateScoreText(score);
        ui.UpdateTimeText(TimeLimit);
        couldroninv.gameObject.SetActive(true);
        score = 0;
        ReadyToPlay = true;
        SetSelectedItem();
      //  StartCoroutine(Countdown());

    }
    IEnumerator Countdown()
    {
        float x = TimeLimit;
        while (ReadyToPlay)
        {
            TimeLimit -= Time.deltaTime;
            ui.UpdateTimeText(TimeLimit);
            yield return new WaitForSeconds(TimeLimit);
            GameisOver();
            ui.UpdateTimeText(TimeLimit);
            ReadyToPlay = false;
            // ui.UpdateTimeText(TimeLimit);

        }


    }
    void Update()
    {
        PromptStart();
      

        if(ReadyToPlay && !GameOver)
        {
            
            TimeLimit -= Time.fixedDeltaTime;
            ui.UpdateTimeText(TimeLimit);
            if(TimeLimit <= 0.1) {
                GameisOver();
                    }
        }
        if (GameOver)
            PromptStart();
           
        {
          //  restart//PromptStart();

        }
        //if (GameOver)
        //{

        //    Debug.Log("over");
        //}

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    void PromptStart()
    {
       // Debug.Log("press Z to start");
        if (!ReadyToPlay && Input.GetKeyDown(KeyCode.Z) )
        {
            StartGame();
            
            //  float x = TimeLimit;

        }
        else if(GameOver && Input.GetKeyDown(KeyCode.Z))
        {
            Restart();
        }
    }
    


    public void Penalize(int i)
    {
        TimeLimit = TimeLimit + (penalizeTime*i);

    }

    public void Score()
    {
        Debug.Log("wescored" + couldroninv.Result);
        if (selectedItem != null)
        {
            if (couldroninv.Result.type == selectedItem.type)
            {
                score += 1;
                ui.UpdateScoreText(score);
                Penalize(1);


            }
            else
            {
                score += 1;
                ui.UpdateScoreText(score);

                Penalize(-1);
               
            }

            couldroninv.EmptyResult();
            SetSelectedItem();

        }
        else
        {
            Debug.Log("selection failed");
        }
    } 
    public void GameisOver()
    {

        GameOver = true;
        ReadyToPlay = false;
        couldroninv.gameObject.SetActive(false);
        ui.UpdateTimeText(00);
        TimeLimit = TempTimelimit;
        ReadyToPlay = false;
        //GameOver = false;
        Debug.Log("your score is " + score);
        Debug.Log("z to play again");
        ui.End(score);
        

    }
}
