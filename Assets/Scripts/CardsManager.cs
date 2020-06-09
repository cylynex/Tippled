using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour {

    public static List<Card> deckOfCards = new List<Card>();
    public static List<Card> usedCards = new List<Card>();

    public static List<Card> dateCards = new List<Card>();
    public static List<Card> categoryCards = new List<Card>();
    public static List<Card> specialCards = new List<Card>();
    public static List<Card> inconvenienceCards = new List<Card>();
}
