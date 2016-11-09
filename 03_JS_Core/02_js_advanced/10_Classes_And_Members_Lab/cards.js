/**
 * Created by ivans on 02-Nov-16.
 */
let obj = (function () {

    let allowedCards = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"]
    let allowedSuits = ['♠', '♥', '♦', '♣']
    class Card {
        constructor(face, suit) {
            isValidFace(face)
            isValidSuit(suit)
            this.face = face
            this.suit = suit
        }

        get suit() {
            return this._suit
        }

        set suit(value) {
            isValidSuit(value)
            this._suit = value
        }

        get face() {
            return this._face
        }

        set face(value) {
            isValidFace(value)
            this._face = value
        }
        toString () {
            return `${this.face}${this.suit}`
        }

    }
    function isValidSuit(suit) {
        if (allowedSuits.indexOf(suit) < 0) {
            throw new Error()
        }
    }

    function isValidFace(face) {
        if (allowedCards.indexOf(face) < 0) {
            throw new Error()
        }
    }

    let Suits = {
        SPADES: '♠',
        HEARTS: '♥',
        DIAMONDS: '♦',
        CLUBS: '♣'
    }
    return { Suits, Card }
}())

console.dir(obj)
let cardClass = obj.Card
let suits = obj.Suits
let card = new cardClass('2', suits.DIAMONDS)
console.log(card.toString())
console.log(card.face)
console.log(card.suit)
card.face = '3'
// card.face = '1'  //throws
console.log(card.face)