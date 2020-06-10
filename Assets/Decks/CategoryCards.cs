﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryCards : MonoBehaviour {

    [SerializeField] GameController gameController;

    public void AddCardsToDeck() {
        
        gameController.AddCardToDeck(CardsManager.categoryCards, "Action", 1, "Categories!", "Choose a category. Anything. Now go around the room naming things that fit into that category.  First person who can’t drinks.");
    }

}