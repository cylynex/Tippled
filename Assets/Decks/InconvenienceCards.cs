using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InconvenienceCards : MonoBehaviour {

    [SerializeField] GameController gameController;

    public void AddCardsToDeck() {
        
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "AFK", "You cannot speak.  But you can Drink.  So do so.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "You shall not Drink", "You are not allowed to drink until otherwise specified.  If you do take a sip and someone sees it, your sip just turned into a slam.  That's right, you'll have to finish your drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Bob Dole Doesn't Do That", "Begin referring to yourself only in the 3rd person.  If you get caught slipping, take a drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Hollow Man", "Nobody can hear you.  Talk and drink all you want, you are invisible to the room");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Look Away", "Nobody can look at you until the inconvenience is lifted or they have to drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Oink Oink", "Speak in pig latin.  Failure means a drink");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Tweet Tweet ", "Speak in Tweety Bird.  Failure means a drink");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Babel", "Speak only in a language you make up as you go.  Anything recognizable means a drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Put him in the bathroom", "You must face away from the group and stay that way.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Duh", "Finish everything you say with 'duh'.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "I got you bro", "Put a hand on the person to your left's shoulder.  There it will stay. every time it comes off, both have a drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Do you even lift bro", "Go around the room naming exercise equipment.   The fatso who messes up has a drink and henceforth will be referred to as Fatty by everyone.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "The Ole Switcharoo", "Swap names with another player of your choice.  Both drink to your new names.  Anyone calling you the wrong name drinks");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "No Moos is Good Moos", "Call someone a cow.  They can only moo from now on.  When you get home it might be a different story though so choose wisely.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Outrage-ous Accentius", "Speak in your favorite accent until this inconvenience is removed.  Mess up, it'll cost ya a drink.  ");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Silence of the Hams", "Crowd picks an accent for you to speak in.  Drink when you mess it up.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Little green man", "There is now a little green man sitting on the rim of your drink.  You must remove him before you drink and put him back when you are finished.  If you get caught messing up, take a drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "You don't know me cuz!", "You're not allowed to call anybody by their name.  Drink when you mess up.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Rated G", "Nobody in the room is allowed to cuss.  Drink when you mess it up.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Beer B*tch", "You're responsible for everybody's refills.  Everybody take a drink to celebrate!");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Thumb Sucker", "Keep sucking your thumb, thumb sucker!  Drink if your thumb leaves your mouth");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Question Mastah", "Thou are now the Question Master - Anyone who answers your questions shall drink.  Remind them of this every time you trick them into answering a question.  Any question.  Like, are you an idiot??");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Thumbs Down", "At any time, when you put your thumb up, the last person to comply has to drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "The Jackass", "Answer everything with a question.  Only ask questions, no statements from you.  Drink every time you forget.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Respect gov'nah", "Speak in a cockney accent until further notice.  Drink when you forget.  Everyone should help remind you.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Creepin'", "Until further notice you are a minecraft creeper.  Behave as such.  Anyone you 'get' has to drink.  If you don't know what that is, finish your drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Oona Dooa Solo?", "Say it in Star Wars.  Everything you say must be a Star Wars reference or line.  Or acknowledgement of your failure as you drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Ewwww", "The person to your right has cooties.  Every time they talk you must get more alcohol in your system to kill the bacteria.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Confusing for 200 Alex?", "State everything in the form of a question.  Did you mess up?  Did you have a drink?");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "I'll Be Back", "Anyone at any point can point at you and 'remind' you that you need to do something.  At which point you must say \"I'll be back!\" and leave the room for 10 seconds.  Have a drink for the road.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "I Vant to Suck Your -", "Maximum Inconvenience time.  You will now speak as if you were Dracula.  Yes that's right really sound out those vowels baby.  U forget, U drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Curling Time", "You will now curl into the fetal position and stay there until this inconvenience is vacated, and enjoy having your friends laugh at you while you still play from the ground.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "I Can't Get left", "Oh, you two are so dreamy!  Interlock hands with the person to your left until otherwise specified.  I hope your date goes well.  Refuse and you finish your drink.  Then you have to do it anyway, so...");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Tourettes Time", "What's wrong with that guy? Every now and then you have to shout something random.  Get creative with your spontaneity.  If somebody notices you've gone 3 turns without doing this, you drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Opposite Handed", "Ouch, you can only drink / hold your beer in your opposite hand. If you fail to do so feel free to tip that drink back");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "This is Sparta", "The only words that you can speak are \"This is Sparta!\".  You also have to scream it.  If you don't there will be a punishment of spears (if somebody catches you slipping, you're downing that drink)");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Do the Flamingo", "Stand on 1 leg.  Any time that other foot touches ground, you drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Squirrel!!!!", "Make a squirrel face, you know, stick your top teeth out.  Anytime you forget, you drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Boing-Boing", "Jumping Jacks.  Go.  Casual Pace, but whenever you stop, you have to drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Keep It Going", "Start Walking around the room.  Never stop moving.  Anytime you do, have a drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Pffffffft", "You can only speak in fart noises.  Anything you say that isnt a squeaker, a trumpet, or a silent but deadly means a drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Is Jimmy Hoffa There?", "You are now a 60s-era mobster from Jersey, both in the way you talk AND the content you are talking about.  Stay in character or drink.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Born to Runner Up", "Jog in place.  If your feet stop moving, your hands better lift that drink up and take a swallow.");
        gameController.AddCardToDeck(CardsManager.inconvenienceCards, "Inconvenience", 1, "Neeeeeeeeeeeiii", "The crowd chooses a word that you cannot hear.  Everytime someone says it, you must drink.");
    }
}