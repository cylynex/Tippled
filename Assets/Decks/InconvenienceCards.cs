﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InconvenienceCards : MonoBehaviour {

    [SerializeField] GameController gameController;

    public void AddCardsToDeck() {

        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Bob Dole Doesn't Do That", "Begin referring to yourself only in the 3rd person.  If you get caught slipping, take a drink.","can stop refering to themselves in the 3rd person.  Arrogant b*tch.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Look Away", "Nobody can look at you until the inconvenience is lifted or they have to drink.","can be looked at again.  Unfortunately.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Put him in the bathroom", "You must face away from the group and stay that way.","may now face the group again, to everyone's dismay.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Duh", "Finish everything you say with 'duh'."," can speak normally again.  Duh.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "I got you bro", "Put a hand on the person to your left's shoulder.  There it will stay. every time it comes off, both have a drink."," can have their hand back.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "The Ole Switcharoo", "Swap names with another player of your choice.  Both drink to your new names.  Anyone calling you the wrong name drinks"," and the person who they swapped names with can revert to normal.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "No Moos is Good Moos", "Call someone a cow.  They can only moo from now on.  When you get home it might be a different story though, so choose wisely.","can stop pretending to be a cow.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Outrage-ous Accentius", "Speak in your favorite accent until this inconvenience is removed.  Mess up, it'll cost ya a drink.  "," beith able to speak normally again, sire.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Little green man", "There is now a little green man sitting on the rim of your drink.  You must remove him before you drink and put him back when you are finished.  If you get caught messing up, take a drink.","must have drank their little green man, cause it's gone.  Finish the drink and expunge the inconvenience.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "You don't know me cuz!", "You're not allowed to call anybody by their name.  Drink when you mess up."," suddenly remembers everyone's real names.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Rated G", "Nobody in the room is allowed to cuss.  Drink when you slip up."," and the rest of the room are allowed to cuss penalty f'ing free again.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Beer B*tch", "You're responsible for everybody's refills.  Everybody take a drink to celebrate!","should make sure nobody needs a fresh round before letting this inconvenience go.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Question Master", "You are now the Question Master - Anyone who answers your questions will drink.  Remind them of this every time you trick them into answering a question.","no longer has to answer with questions?  Or do they??");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Thumbs Up", "At any time, when you put your thumb up, the last person to comply has to drink.","can stop being a d*ck and putting their thumb up.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "The Jackass", "Answer everything with a question.  Only ask questions, no statements from you.  Drink every time you forget.","can stop answering EVERYTHING with a question.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "I'll Be Back", "Anyone at any point can point at you and 'remind' you that you need to do something.  At which point you must say \"I'll be back!\" and leave the room for 10 seconds.  Have a drink for the road."," can no longer be forced to leave the room.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Curling Time", "You will now curl into the fetal position and stay there until this inconvenience is vacated, and enjoy having your friends laugh at you while you still play from the ground."," can get up from the fetal curl on the floor now.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Tourettes Time", "What's wrong with that guy? Every now and then you have to shout something random.  Get creative with your spontaneity.  If somebody notices you've gone 3 turns without doing this, you drink."," suddenly remembers they don't really have tourettes.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "This is Sparta", "The only words that you can speak are \"This is Sparta!\".  You also have to scream it.  If you don't there will be a punishment of spears (if somebody catches you slipping, you're downing that drink)"," doesn't have to scream about Sparta anymore.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Do the Flamingo", "Stand on 1 leg.  Any time that other foot touches ground, you drink."," can use both legs again.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Squirrel!!!!", "Make a squirrel face, you know, stick your top teeth out.  Anytime you forget, you drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Keep It Going", "Start Walking around the room.  Never stop moving.  Anytime you do, have a drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Pffffffft", "You can only speak in fart noises.  Anything you say that isn't a squeaker, a trumpet, or a silent but deadly means a drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Born to Runner Up", "Jog in place.  If your feet stop moving, your hands better lift that drink up and take a swallow.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Unhearable", "The crowd chooses a word that you cannot hear.  Everytime someone says it, you must drink.");
    }
}