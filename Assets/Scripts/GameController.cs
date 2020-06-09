using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [Header("Settings")]
    [SerializeField] int maxTurnsPerGame = 50;
    [SerializeField] int maxReshuffle = 210;
    [SerializeField] int dateCardsPerGame = 2;
    [SerializeField] int categoryCardsPerGame = 3;
    [SerializeField] int specialCardsPerGame = 3;
    [SerializeField] int inconvenienceCardsPerGame = 6;
    [SerializeField] int minInconvenienceLength = 5;
    [SerializeField] int maxInconvenienceLength = 10;

    [Header("Debug")]
    [SerializeField] int currentTurn;
    [SerializeField] int inconvenienceCounter = 0;
    [SerializeField] string currentPlayer;
    [SerializeField] int cardsInDeck = 0;
    [SerializeField] int cardsInUsedDeck = 0;
    
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
    [SerializeField] GameObject nameButton;
    [SerializeField] GameObject quitButton;
    
    bool hasHiddenText = false;
    
    [Header("Decks Slots")]
    [SerializeField] List<int> uniqueCardUsedSlots = new List<int>();
    [SerializeField] List<int> dateCardTurn = new List<int>();
    [SerializeField] List<int> categoryCardTurn = new List<int>();
    [SerializeField] List<int> specialCardTurn = new List<int>();
    [SerializeField] List<int> inconvenienceCardTurn = new List<int>();
    [SerializeField] List<int> inconvenienceFreedomTurn = new List<int>();
    [SerializeField] List<string> inconvenienceFreedomString = new List<string>();
        
    // Player Stuff
    public static int numberOfPlayers = 0;
    public static List<string> players = new List<string>();
    bool noNames = false;
    bool skipThisTurn = false;
    Card dealCard;

    [Header("Categories")]
    [SerializeField] Color inconvenienceColor;
    [SerializeField] Color actionColor;
    [SerializeField] Color headToHeadColor;
    [SerializeField] Color triviaColor;
    [SerializeField] Color specialColor;
    [SerializeField] Color dateColor;
    Color backgroundColor;
    public Camera cam;

    [Header("Sounds")]
    [SerializeField] AudioClip curseReversalSound;
    [SerializeField] AudioClip inconvenienceSound;
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip specialEffectSound;
    AudioSource audioSource;
    AudioSource sound;
    
    void Start() {
        AddDecks();
        InitializeGame();
        DisplayItem();
    }

    void AddDecks() {

        // Setup Deck.  If not first game and we've used more than max shuffle cards in discard, add the oldest 50 back in.
        if (CardsManager.usedCards.Count == 0) {
            this.GetComponent<BaseCards>().AddCardsToDeck();
        } else if (CardsManager.usedCards.Count >= maxReshuffle) {
            for (int i = 0; i < 50; i++) {
                CardsManager.deckOfCards.Add(CardsManager.usedCards[0]);
                CardsManager.usedCards.RemoveAt(0);
            }
        }

        // Add in the special assignment cards.
        this.GetComponent<CategoryCards>().AddCardsToDeck();
        this.GetComponent<DateCards>().AddCardsToDeck();
        this.GetComponent<SpecialCards>().AddCardsToDeck();
        this.GetComponent<InconvenienceCards>().AddCardsToDeck();
    }

    // Sets up the actual cards and adds them to the deck
    void InitializeGame() {

        sound = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        currentTurn = 0;

        // Turn Music Off
        if (GameObject.FindGameObjectWithTag("Sound Manager")) { StartCoroutine("FadeMusic"); }

        SetupUniqueCards(dateCardsPerGame, dateCardTurn);
        SetupUniqueCards(categoryCardsPerGame, categoryCardTurn);
        SetupUniqueCards(specialCardsPerGame, specialCardTurn);
        SetupUniqueCards(inconvenienceCardsPerGame, inconvenienceCardTurn);
        
        ResetInconveniences();
        ShowPlayerNames();                
    }

    // Updates the display (The main Game Loop)
    public void DisplayItem() {

        // If we are in the middle of a multi-tap card, do whatever we need to.  Otherwise serve up a new card.
        if (hasHiddenText) {
            RevealAnswer();
        } else {
            if (answerPanelActive) {
                answerPanel.GetComponent<Animation>().Play("AnswerPanelSlideOutFromPopup");
                answerPanelActive = false;
                Invoke("StandardTurn", 0.8f);
            } else {
                StandardTurn();
            }
        }
    }

    void StandardTurn() {

        if (!skipThisTurn) {
            currentTurn++;
        }

        cardsInDeck = CardsManager.deckOfCards.Count;
        cardsInUsedDeck = CardsManager.usedCards.Count;

        skipThisTurn = false;
        noNames = false;
        
        if (currentTurn >= maxTurnsPerGame) {
            SceneManager.LoadScene("GameOver");
        } else {

            //CheckForInconvenienceDue();

            if (inconvenienceFreedomTurn.Contains(currentTurn)) {
                CheckForInconvenienceDue();
            } else if (dateCardTurn.Contains(currentTurn)) {
                dealCard = SelectRandomUniqueCard(CardsManager.dateCards, dateCardTurn, false, false);
            } else if (categoryCardTurn.Contains(currentTurn)) {
                dealCard = SelectRandomUniqueCard(CardsManager.categoryCards, categoryCardTurn, false, false);
            } else if (specialCardTurn.Contains(currentTurn)) {
                dealCard = SelectRandomUniqueCard(CardsManager.specialCards, specialCardTurn, true, true);
            } else if (inconvenienceCardTurn.Contains(currentTurn)) {
                dealCard = SelectRandomUniqueCard(CardsManager.inconvenienceCards, inconvenienceCardTurn, false, false);
                SetupInconvenienceFreedom();
            } else {
                dealCard = SelectRandomCard();
            }
            
            PlayCard();
        }        
    }
    
    void PlayCard() {
        
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
        
        // Animate the title
        canvas.GetComponent<Animation>().Play("NewSlide");
        
        // Play the appropriate Sound
        PlaySound();
        DisplayPlayerName();
        UpdatePlayer();
    }

    void DisplayPlayerName() {
        if (dealCard.cardCategory == "Convenience" || noNames == true) {
            playerName.text = "";
        }
        else {
            playerName.text = GameController.players[playerIndex];
        }
    }
    
    void UpdatePlayer() { 
        if (!skipThisTurn) {
            if (playerIndex >= (GameController.players.Count - 1)) {
                playerIndex = 0;
            } else {
                playerIndex++;
            }
            currentPlayer = GameController.players[playerIndex];
        }

        foreach (Transform child in nameListHolder) {
            if (child.gameObject.name == playerName.text) {
                child.gameObject.GetComponent<Text>().color = Color.white;
            } else {
                child.gameObject.GetComponent<Text>().color = Color.black;
            }
        }
    }

    void ShowPlayerNames() {
        for (int i = 0; i < numberOfPlayers; i++) {
            GameObject thisPlayer = Instantiate(nameListEntry, nameListHolder.position, Quaternion.identity, nameListHolder);
            thisPlayer.GetComponent<Text>().text = players[i];
            thisPlayer.name = players[i];
        }
    }
    
    void ResetInconveniences() {
        inconvenienceFreedomString.Clear();
        inconvenienceFreedomTurn.Clear();
    }

    void SetupInconvenienceFreedom() {
        int cancelAfter = Random.Range(minInconvenienceLength, maxInconvenienceLength);
        int cancelHere = currentTurn + cancelAfter;

        // Check for existing inconvenience for this player.  If there is one, just replace the turn slot instead of adding a new one.
        int incCounter = 0;
        for (int x = 0; x < inconvenienceFreedomString.Count; x++) {
            if (inconvenienceFreedomString[x] == currentPlayer) {
                incCounter++;
                inconvenienceFreedomTurn[x] = cancelHere;
            }
        }

        if (incCounter == 0) {
            inconvenienceFreedomTurn.Add(cancelHere);
            inconvenienceFreedomString.Add(currentPlayer);
        }
    }

    void CheckForInconvenienceDue() {
        for (int i = 0; i < inconvenienceFreedomTurn.Count; i++) {
            if (currentTurn == inconvenienceFreedomTurn[i]) {
                dealCard = SelectInconvenienceFreedomCard(inconvenienceFreedomString[i]);
                inconvenienceFreedomTurn.RemoveAt(i);
                inconvenienceFreedomString.RemoveAt(i);
            }
        }
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

    void SetupUniqueCards(int cardsPerGame, List<int> turnList) {
        for (int i = 0; i < cardsPerGame; i++) {
            int proposedSlot = Random.Range(5, 40);
            if (uniqueCardUsedSlots.Contains(proposedSlot)) {
                i--;
            }
            else {
                turnList.Add(proposedSlot);
                uniqueCardUsedSlots.Add(proposedSlot);
            }
        }
    }    

    Card SelectRandomCard() {
        int randomCard = Random.Range(0, CardsManager.deckOfCards.Count);
        Card thisCard = CardsManager.deckOfCards[randomCard];
        CardsManager.usedCards.Add(thisCard);
        CardsManager.deckOfCards.RemoveAt(randomCard);
        return thisCard;
    }

    Card SelectRandomUniqueCard(List<Card> deckToUse, List<int> thisDeckTurn, bool names, bool skipTurn) {
        int randomCard = Random.Range(0, deckToUse.Count);
        Card thisCard = deckToUse[randomCard];
        noNames = names;
        skipThisTurn = skipTurn;
        thisDeckTurn.Remove(currentTurn);
        return thisCard;
    }
    
    Card SelectInconvenienceFreedomCard(string thisPlayerName) {
        Card thisCard = CardsManager.deckOfCards[0];
        thisCard.cardCategory = "Convenience";
        string cardTextout = thisPlayerName.ToString()+ " is relieved of all inconveniences.  For now.";
        thisCard.cardText = cardTextout;
        thisCard.cardTitle = "No Longer Inconvenienced";
        thisCard.stages = 1;
        skipThisTurn = true;
        return thisCard;
    }    

    public void AddCardToDeck(List<Card> thisDeck, string cat, int stages, string title, string cText, string cText2 = "") {
        Card tempCard = new Card();
        tempCard.cardCategory = cat;
        tempCard.cardTitle = title;
        tempCard.cardText = cText;
        tempCard.stages = stages;
        tempCard.cardAnswer = cText2;
        thisDeck.Add(tempCard);
    }

    /************************ UI Stuff ***********************/

    void SetBackgroundColor(string category) {
        switch (dealCard.cardCategory) {
            case "Inconvenience"    : SetColors(inconvenienceColor); break;
            case "Convenience"      : SetColors(inconvenienceColor); break;
            case "Action"           : SetColors(actionColor); break;
            case "Head to Head"     : SetColors(headToHeadColor); break;
            case "Trivia"           : SetColors(triviaColor); break;
            case "Special"          : SetColors(specialColor); break;
            case "Date"             : SetColors(dateColor); break;   
        }
    }  
    
    void SetColors(Color colorToUse) {
        backgroundColor = colorToUse; ;
        cardCategory.GetComponent<Text>().color = colorToUse;
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

    void RevealAnswer() {
        answerPanel.GetComponent<Animation>().Play("AnswerPanelPopup");
        answerPanelActive = true;
        cardText.text = "";
        answerPanelTextField.text = cardAnswerText;
        hasHiddenText = false;
        clickToContinue.SetActive(false);
    }
}