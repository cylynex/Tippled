using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    // The list of Cards
    [Header("Cards")]
    public List<Card> categoryDeck = new List<Card>(); // Categories Cards
    public List<Card> dateDeck = new List<Card>(); // Date Cards
    Card dealCard;

    [Header("UI Stuff")]
    public Text cardCategory;
    public Text cardTitle;
    public Text cardText;
    public Text cardAnswer;
    public GameObject clickToContinue;
    public Image cardBackground;
    string cardAnswerText;
    [SerializeField] GameObject answerPanel;
    [SerializeField] Text answerPanelTextField;
    bool answerPanelActive = false;
    [SerializeField] Canvas canvas;
    [SerializeField] Text playerName;
    [SerializeField] int playerIndex = 0;
    [SerializeField] float musicFadeTime = 3f;
    [SerializeField] Transform nameListHolder;
    [SerializeField] GameObject nameListEntry;
    
    bool hasHiddenText = false;

    [Header("Informational Game Stuff")]
    [SerializeField] int currentTurn;
    [SerializeField] int inconvenienceCounter = 0;
    [SerializeField] int categoryCounter = 0;
    [SerializeField] int dateCardTurn = 0;
    [SerializeField] string currentPlayer;
    [SerializeField] int cardsInDeck = 0;
    [SerializeField] int cardsInUsedDeck = 0;

    [Header("Inconvenience Tracking")]
    List<int> cancelInconvenienceTurnSlot = new List<int>();
    List<string> cancelInconvenienceString = new List<string>();
    [SerializeField] int minTurnsForInconvenience = 5;
    [SerializeField] int maxTurnsForInconvenience = 10;
    [SerializeField] int nextInconvenienceFreedom = 0;

    [Header("Game Settings")]
    [SerializeField] int maxTurns = 50;
    [SerializeField] int chanceOfCategory = 10;

    [Header("Player Stuff")]
    public static int numberOfPlayers = 0;
    public static List<string> players = new List<string>();

    // Colors
    Color backgroundColor;
    [Header("Categories")]
    [SerializeField] Color inconvenienceColor;
    [SerializeField] Color actionColor;
    [SerializeField] Color headToHeadColor;
    [SerializeField] Color triviaColor;
    [SerializeField] Color specialColor;
    [SerializeField] Color dateColor;
    [SerializeField] Color pioneerColor;
    public Camera cam;

    [Header("Sounds")]
    AudioSource sound;
    [SerializeField] AudioClip curseReversalSound;
    [SerializeField] AudioClip inconvenienceSound;
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip specialEffectSound;
    AudioSource audioSource;

    [Header("Log")]
    [SerializeField] public static int gameNumber = 0;
    public static int inconvenienceNumber = 0;
    public static int actionNumber = 0;
    public static int specialNumber = 0;
    public static int headtoheadNumber = 0;
    public static int triviaNumber = 0;
    public static int convenienceNumber = 0;


    void Start() {
        AddDecks();
        InitializeStuff();
        DisplayItem();
    }

    void AddDecks() {
        if (CardsManager.usedCards.Count == 0) {
            // New Deck, add all available cards
            this.GetComponent<BaseCards>().AddBaseCardsToDeck();
        } else if (CardsManager.usedCards.Count > 142) {
            // Shuffle the oldest 50 back in
            for (int i = 0; i < 50; i++) {
                CardsManager.deckOfCards.Add(CardsManager.usedCards[0]);
                CardsManager.usedCards.RemoveAt(0);
            }
        }

        this.GetComponent<CategoryCards>().AddCategoriesCardsToDeck();
        this.GetComponent<DateCards>().AddDateCardsToDeck();
    }

    // Sets up the actual cards and adds them to the deck
    void InitializeStuff() {

        sound = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<AudioSource>();

        // Set turn to 1
        currentTurn = 0;
        
        // Setup Audio
        audioSource = GetComponent<AudioSource>();

        // Turn Music Off
        if (GameObject.FindGameObjectWithTag("Sound Manager")) {
            StartCoroutine("FadeMusic");
        }

        // Date Card Turn Setup
        dateCardTurn = Random.Range(5, 35);

        // Reset Inconvenience Counters
        ResetInconveniences();

        // Display the player names
        for(int i = 0; i < numberOfPlayers; i++) {
            GameObject thisPlayer = Instantiate(nameListEntry, nameListHolder.position, Quaternion.identity, nameListHolder);
            thisPlayer.GetComponent<Text>().text = players[i];
            thisPlayer.name = players[i];
        }
        
    }

    // Updates the display (The main Game Loop)
    public void DisplayItem() {

        // If we are in the middle of a multi-tap card, do whatever we need to.  Otherwise serve up a new card.
        if (hasHiddenText) {
            RevealAnswer();
        }
        else {
            if (answerPanelActive) {
                answerPanel.GetComponent<Animation>().Play("AnswerPanelSlideOutFromPopup");
                answerPanelActive = false;
                Invoke("StandardTurn", .8f);
            }
            else {
                StandardTurn();
            }
        }
    }

    void StandardTurn() {

        cardsInDeck = CardsManager.deckOfCards.Count;
        cardsInUsedDeck = CardsManager.usedCards.Count;

        bool skipThisTurn = false;

        // Check for inconvenience Freedom.  If one is due, do it instead of taking a turn.
        skipThisTurn = CheckForInconvenienceDue();

        if (!skipThisTurn) {
            currentTurn++;
            if (currentTurn > 50) {
                SceneManager.LoadScene("GameOver");
            } else {
                int whatToDo = Random.Range(1, 100);
                int categoryMin = 0;
                int categoryMax = chanceOfCategory;

                if (currentTurn == dateCardTurn) {
                    dealCard = SelectDateCard();
                }
                else {
                    if (whatToDo >= categoryMin && whatToDo <= categoryMax) {
                        dealCard = SelectRandomCategoryCard();
                        categoryCounter++;
                    } else {
                        dealCard = SelectRandomCard();
                    }
                }

                PlayCard(skipThisTurn);
            }
        }
    }

    void RevealAnswer() {
        answerPanel.GetComponent<Animation>().Play("AnswerPanelPopup");
        answerPanelActive = true;

        cardText.text = "";
        answerPanelTextField.text = cardAnswerText;
        hasHiddenText = false;
        clickToContinue.SetActive(false);
    }

    void PlayCard(bool skipThisTurn) {

        // Set UI Text
        SetUIText(dealCard);

        // Set the BG color based on category
        SetBackgroundColor(dealCard.cardCategory);

        // Alternative displays
        if (dealCard.stages == 1) {
            StandardCardSetup();
        } else if (dealCard.stages == 2) {
            // unused
        } else if (dealCard.stages == 3) {
            TriviaCardSetup();
        }

        // Put in the Player Name
        UpdatePlayer(skipThisTurn);

        // Animate the title
        canvas.GetComponent<Animation>().Play("NewSlide");

        // Play the appropriate Sound
        PlaySound();

        // Log inconvenience
        if (dealCard.cardCategory == "Inconvenience") {
            int cancelAfter = Random.Range(minTurnsForInconvenience, maxTurnsForInconvenience);
            int cancelHere = currentTurn + cancelAfter;

            // Check for existing inconvenience for this player.  If there is one, just replace the turn slot instead of adding a new one.
            int incCounter = 0;
            for (int x = 0; x < cancelInconvenienceString.Count; x++) {
                if (cancelInconvenienceString[x] == currentPlayer) {
                    print("found an existing IC with their name, updating counter.");
                    incCounter++;
                    print("Prior Release: " + cancelInconvenienceTurnSlot[x]);
                    cancelInconvenienceTurnSlot[x] = cancelHere;
                    print("New Release: " + cancelInconvenienceTurnSlot[x]);
                } 
            }

            if (incCounter == 0) {
                print("No IC present, just add from scratch.");
                cancelInconvenienceTurnSlot.Add(cancelHere);
                cancelInconvenienceString.Add(currentPlayer);
            } else {
                print("They already have an existing IC, just update.");
            }
            
            // If this is the first one, or there are no others in the queue, make this one the first.
            if (nextInconvenienceFreedom == 0) {
                nextInconvenienceFreedom = cancelHere;
            }
        }

        // Debug stuff
        switch(dealCard.cardCategory) {
            case "Inconvenience": inconvenienceNumber++; break;
            case "Action": actionNumber++; break;
            case "Special": specialNumber++; break;
            case "Head to Head": headtoheadNumber++; break;
            case "Trivia": triviaNumber++; break;
            case "Convenience": inconvenienceNumber++; break;
        }
    }

    void ResetInconveniences() {
        cancelInconvenienceString.Clear();
        cancelInconvenienceTurnSlot.Clear();
        nextInconvenienceFreedom = 0;
    }

    void UpdatePlayer(bool skipThisTurn) {
        if (GameController.players.Count > 0) {
            if (dealCard.cardCategory == "Convenience") {
                playerName.text = "";
            } else {
                playerName.text = GameController.players[playerIndex];
            }

            currentPlayer = GameController.players[playerIndex];
            if (!skipThisTurn) {
                if (playerIndex >= (GameController.players.Count - 1)) {
                    playerIndex = 0;
                } else {
                    playerIndex++;
                }
            }



            foreach(Transform child in nameListHolder) {
                if (child.gameObject.name == playerName.text) {
                    child.gameObject.GetComponent<Text>().color = Color.white;
                } else {
                    child.gameObject.GetComponent<Text>().color = Color.black;
                }
            }

        }
    }

    bool CheckForInconvenienceDue() {
        bool skipThisTurn = false;
        for (int i = 0; i < cancelInconvenienceTurnSlot.Count; i++) {
            if (currentTurn == cancelInconvenienceTurnSlot[i]) {
                dealCard = SetupClearInconvenienceCard(cancelInconvenienceString[i]);
                skipThisTurn = true;
                cancelInconvenienceTurnSlot.RemoveAt(i);
                cancelInconvenienceString.RemoveAt(i);
                PlayCard(skipThisTurn);
            }
        }

        return skipThisTurn;
    }
       
    /************** Card Handling Methods *******************/

    void StandardCardSetup() {
        cardAnswer.text = "";
        hasHiddenText = false;
    }

    void TriviaCardSetup() {
        cardAnswerText = dealCard.cardAnswer;
        hasHiddenText = true;
        clickToContinue.SetActive(true);
    }

    Card SelectRandomCard() {
        int randomCard = Random.Range(0, CardsManager.deckOfCards.Count);
        Card thisCard = CardsManager.deckOfCards[randomCard];
        CardsManager.usedCards.Add(thisCard);
        CardsManager.deckOfCards.RemoveAt(randomCard);
        return thisCard;
    }

    Card SelectDateCard() {
        int randomCard = 0;
        Card thisCard = dateDeck[randomCard];
        return thisCard;
    }

    Card SelectRandomCategoryCard() {
        int randomCard = Random.Range(0, categoryDeck.Count);
        Card thisCard = categoryDeck[randomCard];
        return thisCard;
    }

    Card SetupClearInconvenienceCard(string thisPlayerName) {
        Card thisCard = CardsManager.deckOfCards[0];
        thisCard.cardCategory = "Convenience";
        string cardTextout = thisPlayerName.ToString()+ " is relieved of all inconveniences.  For now.";
        thisCard.cardText = cardTextout;
        thisCard.cardTitle = "No Longer Inconvenienced";
        thisCard.stages = 1;
        return thisCard;
    }    

    public void AddCard(string cat, int stages, string title, string cText, string cText2 = "") {
        Card tempCard = new Card();
        tempCard.cardCategory = cat;
        tempCard.cardTitle = title;
        tempCard.cardText = cText;
        tempCard.stages = stages;
        tempCard.cardAnswer = cText2;
        CardsManager.deckOfCards.Add(tempCard);
    }

    public void AddCategoryCard(string cat, int stages, string title, string cText, string cText2 = "") {
        Card tempCard = new Card();
        tempCard.cardCategory = cat;
        tempCard.cardTitle = title;
        tempCard.cardText = cText;
        tempCard.stages = stages;
        tempCard.cardAnswer = cText2;
        categoryDeck.Add(tempCard);
    }

    public void AddDateCard(string cat, int stages, string title, string cText, string cText2 = "") {
        Card tempCard = new Card();
        tempCard.cardCategory = cat;
        tempCard.cardTitle = title;
        tempCard.cardText = cText;
        tempCard.stages = stages;
        tempCard.cardAnswer = cText2;
        dateDeck.Add(tempCard);
    }

    /************************ UI Stuff ***********************/

    void SetBackgroundColor(string category) {
        // Change background color
        switch (dealCard.cardCategory) {
            case "Inconvenience": 
                backgroundColor = inconvenienceColor;
                cardCategory.GetComponent<Text>().color = inconvenienceColor;
                break;
            case "Convenience":
                backgroundColor = inconvenienceColor;
                cardCategory.GetComponent<Text>().color = inconvenienceColor;
                break;
            case "Action": 
                backgroundColor = actionColor;
                cardCategory.GetComponent<Text>().color = actionColor;
                break;
            case "Head to Head": 
                backgroundColor = headToHeadColor;
                cardCategory.GetComponent<Text>().color = headToHeadColor;
                break;
            case "Trivia": 
                backgroundColor = triviaColor;
                cardCategory.GetComponent<Text>().color = triviaColor;
                break;
            case "Special": 
                backgroundColor = specialColor;
                cardCategory.GetComponent<Text>().color = specialColor;
                break;
            case "Date":
                backgroundColor = dateColor;
                cardCategory.GetComponent<Text>().color = dateColor;
                break;
            case "Pioneer": backgroundColor = pioneerColor; break;
        }
        
        cardBackground.GetComponent<Image>().color = backgroundColor;
    }   

    IEnumerator FadeMusic() {
        float t = musicFadeTime;
        while (t > 0) {
            yield return null;
            t -= Time.deltaTime;
            sound.volume = t / musicFadeTime;
        }
        yield break; 
    }

    void PlaySound() {
        AudioClip soundToPlay;
        switch (dealCard.cardCategory) {
            case "Inconvenience": soundToPlay = inconvenienceSound; break;
            default: soundToPlay = null; break;
        }

        if (soundToPlay) {
            audioSource.PlayOneShot(soundToPlay);
        }
    }

    void SetUIText(Card cardData) {
        cardCategory.text = cardData.cardCategory;
        cardTitle.text = cardData.cardTitle;
        cardText.text = cardData.cardText;
        cardAnswer.text = " ";
    }
}