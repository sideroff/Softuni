/**
 * Created by ivans on 01-Nov-16.
 */



let expect = require('chai').expect
let jsdom = require('jsdom-global')()
let $ = require('jquery');

document.body.innerHTML = `<div id="wrapper">
        <input type="text" id="name">
        <input type="text" id="income">
    </div>`;


let isOddOrEven = require('../js.js').isOddOrEven
let lookupChar = require('../js.js').lookupChar
let mathEnforcer = require('../js.js').mathEnforcer
let sharedObject = require('../js.js').sharedObject
let nuke = require('../js.js').nuke

describe('isOddOrEven(string)', function () {
    describe('cases for normal input', function () {
        it('should be even for ""', function () {
            expect(isOddOrEven('')).to.be.equal('even')
        })
        it('should be odd for "a"', function () {
            expect(isOddOrEven('a')).to.be.equal('odd')
        })
        it('should be even for "aa"', function () {
            expect(isOddOrEven('aa')).to.be.equal('even')
        })
        it('should be even for "11"', function () {
            expect(isOddOrEven('11')).to.be.equal('even')
        })
    })
    describe('cases for abnormal input', function () {
        it('should be undefined for undefined', function () {
            expect(isOddOrEven(undefined)).to.be.equal(undefined)
        })
        it('should be undefined for [1]', function () {
            expect(isOddOrEven([1])).to.be.equal(undefined)
        })
        it('should be undefined for -2', function () {
            expect(isOddOrEven(-2)).to.be.equal(undefined)
        })
        it('should be undefined for {a:1}', function () {
            expect(isOddOrEven({a: 1})).to.be.equal(undefined)
        })
    })
})

describe('lookupChar(string,index)', function () {
    describe('cases for normal input', function () {
        it('should be a for "a",0', function () {
            expect(lookupChar('a', 0)).to.be.equal('a'.charAt(0))
        })
        it('should be b for "aba",1', function () {
            expect(lookupChar('aba', 1)).to.be.equal('aba'.charAt(1))
        })
    })
    describe('cases for abnormal input', function () {
        it('should be undefined for "a",1', function () {
            expect(lookupChar('a', 1)).to.be.equal("Incorrect index")
        })
        it('should be undefined for "aba",-1', function () {
            expect(lookupChar('aba', -1)).to.be.equal("Incorrect index")
        })
        it('should be undefined for "a",1', function () {
            expect(lookupChar('a', 0.2)).to.be.equal(undefined)
        })
        it('should be undefined for [1,2],1', function () {
            expect(lookupChar([1, 2], 1)).to.be.equal(undefined)
        })
        it('should be undefined for {1:a},1', function () {
            expect(lookupChar({1: 'a'}, 1)).to.be.equal(undefined)
        })
        it('should be undefined for "aba","a"', function () {
            expect(lookupChar('aba', 'a')).to.be.equal(undefined)
        })
        it('should be undefined for "aba",[1]', function () {
            expect(lookupChar('aba', [1])).to.be.equal(undefined)
        })
    })
})

describe('mathEnforcer', function () {
    describe('addFive', function () {
        it('should be 5 for addFive(0)', function () {
            expect(mathEnforcer.addFive(0)).to.be.equal(5)
        })
        it('should be 4 for addFive(-1)', function () {
            expect(mathEnforcer.addFive(-1)).to.be.equal(4)
        })
        it('should be NaN for addFive(NaN)', function () {
            expect(mathEnforcer.addFive(NaN)).to.be.NaN
        })
        it('should be 5.5 for addFive(0.5)', function () {
            expect(mathEnforcer.addFive(0.5)).to.be.equal(0.5 + 5)
        })
        it('should be undefined for addFive()', function () {
            expect(mathEnforcer.addFive()).to.be.equal(undefined)
        })
        it('should be undefined for addFive("1")', function () {
            expect(mathEnforcer.addFive("1")).to.be.equal(undefined)
        })
        it('should be undefined for addFive({1:1})', function () {
            expect(mathEnforcer.addFive({1: 1})).to.be.equal(undefined)
        })
        it('should be undefined for addFive([1])', function () {
            expect(mathEnforcer.addFive([1])).to.be.equal(undefined)
        })
    })
    describe('subtractTen', function () {
        it('should be 0 for subtractTen(10)', function () {
            expect(mathEnforcer.subtractTen(10)).to.be.equal(0)
        })
        it('should be -1 for subtractTen(-9)', function () {
            expect(mathEnforcer.subtractTen(9)).to.be.equal(-19)
        })
        it('should be NaN for subtractTen(NaN)', function () {
            expect(mathEnforcer.subtractTen(NaN)).to.be.NaN
        })
        it('should be 0.5 for subtractTen(10.5)', function () {
            expect(mathEnforcer.subtractTen(10.5)).to.be.equal(10.5 - 10)
        })
        it('should be undefined for subtractTen()', function () {
            expect(mathEnforcer.subtractTen()).to.be.equal(undefined)
        })
        it('should be undefined for subtractTen("1")', function () {
            expect(mathEnforcer.subtractTen("1")).to.be.equal(undefined)
        })
        it('should be undefined for subtractTen({1:1})', function () {
            expect(mathEnforcer.subtractTen({1: 1})).to.be.equal(undefined)
        })
        it('should be undefined for subtractTen([1])', function () {
            expect(mathEnforcer.subtractTen([1])).to.be.equal(undefined)
        })
    })
    describe('sum', function () {
        it('should be 0 for sum(0,0)', function () {
            expect(mathEnforcer.sum(0, 0)).to.be.equal(0)
        })
        it('should be 1 for sum(1,0)', function () {
            expect(mathEnforcer.sum(1, 0)).to.be.equal(1)
        })
        it('should be 2 for sum(0,2)', function () {
            expect(mathEnforcer.sum(0, 2)).to.be.equal(2)
        })
        it('should be NaN for sum(NaN,2)', function () {
            expect(mathEnforcer.sum(NaN, 2)).to.be.NaN
        })
        it('should be -10 for sum(0,-10)', function () {
            expect(mathEnforcer.sum(0, -10)).to.be.equal(-10)
        })
        it('should be 5.5 for sum(5,0.5)', function () {
            expect(mathEnforcer.sum(5, 0.5)).to.be.equal(0.5 + 5)
        })
        it('should be undefined for sum()', function () {
            expect(mathEnforcer.sum()).to.be.equal(undefined)
        })
        it('should be undefined for sum(1)', function () {
            expect(mathEnforcer.sum(1)).to.be.equal(undefined)
        })
        it('should be undefined for sum(1,"1")', function () {
            expect(mathEnforcer.sum(1, "1")).to.be.equal(undefined)
        })
        it('should be undefined for sum([1],2)', function () {
            expect(mathEnforcer.sum([1], 2)).to.be.equal(undefined)
        })
        it('should be undefined for sum(undefined,2)', function () {
            expect(mathEnforcer.sum(undefined, 2)).to.be.equal(undefined)
        })

    })
})

describe('sharedObject', function () {
    let obj
    beforeEach('init object',function () {
        obj = Object.create(sharedObject)
        document.body.innerHtml =
            '<div id="wrapper">'+
            '<input type="text" id="name">'+
            '<input type="text" id="income">'+
            '</div>'
    })
    describe('initial values',function () {

    })
});

describe('test cases for nuke function', function () {
    let testObject;
    beforeEach('init the object', function () {
        document.body.innerHTML =
            `<div id="target">
                <div class="nested target">
                    <p>This is some text</p>
                </div>
                <div class="target">
                    <p>Empty div</p>
                </div>
                <div class="inside">
                    <span class="nested">Some more text</span>
                    <span class="target">Some more text</span>
                </div>
            </div>`;
    });

    it('should do nothing on invalid selectors', () => {
        let selector = $('#target');
        let prev = selector.html();
        nuke(2, "#target");
        expect(selector.html()).to.equal(prev);
    });

    it('should do nothing on nuke(2, "#target")', () => {
        let selector = $('#target');
        let prev = selector.html();
        nuke('.nested', '.inside');
        expect(selector.html()).to.equal(prev);
    });

    it('should do noting if 1 parameters isn\'t valid selector', ()=> {
        let selector1 = '#target';
        let selector2 = 'nested';
        let len = $(selector1).length;
        nuke(selector1, selector2);
        expect($(selector1).length).to.be.equal(len);
    });

    it('should do noting if parameters are equals', () => {
        let selector = '#target';
        let before = document.body.innerHTML;
        nuke(selector, selector);
        let after = document.body.innerHTML;
        expect(before).to.be.equal(after);
    });

    it('should remove nodes whit correct selectors', () => {
        let selector1 = '.target';
        let selector2 = '.nested';
        nuke(selector1, selector2);
        let after = $(selector1 + selector2);
        expect(after.length).to.be.equal(0);
    });
});


