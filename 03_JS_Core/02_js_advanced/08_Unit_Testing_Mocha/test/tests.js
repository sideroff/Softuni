//Created by ivans on 31-Oct-16.

let expect = require("chai").expect;

let sum = require('../js.js').sum
let isSymmetric = require('../js.js').isSymmetric
let rgbToHexColor = require('../js.js').rgbToHexColor
let createCalculator = require('../js.js').createCalculator

describe("sum(arr)", function() {
    it("should return 3 for [1, 2]", function() {
        expect(sum([1, 2])).to.be.equal(3);
    });
    it('should return 1 for [1]', function () {
        expect(sum([1])).to.be.equal(1)
    })
    it('should return 0 for []', function () {
        expect(sum([])).to.be.equal(0)
    })
    it('should return 3 for [1.5,1.5,-1,0,1]', function () {
        expect(sum([1.5,1.5,-1,0,1])).to.be.equal(3)
    })
    it('should return NaN for ["gosho"]', function () {
        expect(sum(["gosho"])).to.be.NaN
    })
});

describe("isSymmetric(arr)",function () {
    describe('true cases for valid input', function () {
        it('should return true for []',function () {
            expect(isSymmetric([])).to.be.equal(true)
        })
        it('should return true for [1]',function () {
            expect(isSymmetric([1])).to.be.equal(true)
        })
        it('should return true for [1,2,1]',function () {
            expect(isSymmetric([1,2,1])).to.be.equal(true)
        })
        it('should return true for [1,2,2,1]',function () {
            expect(isSymmetric([1,2,2,1])).to.be.equal(true)
        })
        it('should return true for ["gosho","pesho","gosho"]',function () {
            expect(isSymmetric(["gosho","pesho","gosho"])).to.be.equal(true)
        })
        it('should return true for [{a:5},2,new Date(),2,{a:5}]',function () {
            expect(isSymmetric([{a:5},2,new Date(),2,{a:5}])).to.be.equal(true)
        })
    })
    describe('false cases for valid input', function () {
        it('should return false for [1,2]',function () {
            expect(isSymmetric([1,2])).to.be.equal(false)
        })
        it('should return false for ["gosho","Gosho"]',function () {
            expect(isSymmetric(['gosho','Gosho'])).to.be.equal(false)
        })
        it('should return false for [-1,1,1]',function () {
            expect(isSymmetric([-1,1,1])).to.be.equal(false)
        })
        it('should return true for [{x:5},2,2,{a:5}]',function () {
            expect(isSymmetric([{x:5},2,new Date(),2,{a:5}])).to.be.equal(false)
        })
        it('should return true for 1,2,1',function () {
            expect(isSymmetric(1,2,1)).to.be.equal(false)
        })
    })
})

describe('rgbToHexColor(int,int,int)', function () {
    describe('true cases for valid input', function () {
        it('should return true for 100,100,100',function () {
            expect(rgbToHexColor(100,100,100)).to.be.equal('#646464')
        })
        it('should return true for 0,0,0',function () {
            expect(rgbToHexColor(0,0,0)).to.be.equal('#000000')
        })
        it('should return true for 255,255,255',function () {
            expect(rgbToHexColor(255,255,255)).to.be.equal('#FFFFFF')
        })
    })
    describe('false cases for valid input', function () {
        it('should return true for -1,100,100',function () {
            expect(rgbToHexColor(-1,100,100)).to.be.equal(undefined)
        })
        it('should return true for 100,-1,100',function () {
            expect(rgbToHexColor(100,-1,100)).to.be.equal(undefined)
        })
        it('should return true for 100,100,-1',function () {
            expect(rgbToHexColor(100,100,-1)).to.be.equal(undefined)
        })
        it('should return true for 256,100,100',function () {
            expect(rgbToHexColor(256,100,100)).to.be.equal(undefined)
        })
        it('should return true for 100,256,100',function () {
            expect(rgbToHexColor(100,256,100)).to.be.equal(undefined)
        })
        it('should return true for 100,100,256',function () {
            expect(rgbToHexColor(100,100,-256)).to.be.equal(undefined)
        })
    })
    describe('false cases for invalid input', function () {
        it('should return true for ()',function () {
            expect(rgbToHexColor()).to.be.equal(undefined)
        })
        it('should return true for "gosho",{a:5},new Date()',function () {
            expect(rgbToHexColor("gosho",{a:5},new Date())).to.be.equal(undefined)
        })
    })
})

describe('createCalculator',function () {
    let calc
    beforeEach('create calc',function () {
        calc = createCalculator()
    })
    describe('createCalculator returns correct obj', function(){
        it('should return obj',function () {
            expect(typeof(calc)).to.be.equal('object')
        })
        it('should return obj with add function',function () {
            expect(typeof (calc.add)).to.be.equal('function')
        })
        it('should return obj with subtract function',function () {
            expect(typeof (calc.subtract)).to.be.equal('function')
        })
        it('should return obj with get function',function () {
            expect(typeof (calc.get)).to.be.equal('function')
        })
    })
    describe('createCalculator adds correctly', function(){
        it('should return 0 for get()',function () {
            expect(calc.get()).to.be.equal(0)
        })
        it('should return 0 for add(0)',function () {
            calc.add(0)
            expect(calc.get()).to.be.equal(0)
        })
        it('should return 5 for add(5)',function () {
            calc.add(5)
            expect(calc.get()).to.be.equal(5)
        })
        it('should return 6 for add(5).add(1)',function () {
            calc.add(5)
            calc.add(1)
            expect(calc.get()).to.be.equal(6)
        })
        it('should return 4 for add(5).add(-1)',function () {
            calc.add(5)
            calc.add(-1)
            expect(calc.get()).to.be.equal(4)
        })
        it('should return 2 after {add(10); subtract(\'7\'),add(\'-2\'), subtract(-1) }', function() {
            calc.add(10)
            calc.subtract('7')
            calc.add('-2')
            calc.subtract(-1)
            let value = calc.get()
            expect(value).to.be.equal(2)
        })
        it('should return 4 for add(5).subtract(1)',function () {
            calc.add(5)
            calc.subtract(1)
            expect(calc.get()).to.be.equal(4)
        })
        it('should return 4.1 for add(4).subtract(0.1)',function () {
            calc.add(4)
            calc.add(0.1)
            expect(calc.get()).to.be.equal(4.1)
        })
        it('should return 4 for add(4.1).subtract(0.1)',function () {
            calc.add(4.1)
            calc.subtract(0.1)
            expect(calc.get()).to.be.equal(4.1-0.1)
        })
    })
    describe('createCalculator subtracts correctly', function(){
        it('should return 0 for subtract(0)',function () {
            calc.subtract(0)
            expect(calc.get()).to.be.equal(0)
        })
        it('should return -5 for subtract(5)',function () {
            calc.subtract(5)
            expect(calc.get()).to.be.equal(-5)
        })
        it('should return -6 for subtract(5).subtract(1)',function () {
            calc.subtract(5)
            calc.subtract(1)
            expect(calc.get()).to.be.equal(-6)
        })
        it('should return -4 for subtract(5).subtract(-1) wat',function () {
            calc.subtract(5)
            calc.subtract(-1)
            console.log(calc.get())
            expect(calc.get()).to.be.equal(-4)
        })
    })
    describe('createCalculator breaks correctly', function(){
        it('should return NaN for subtract()',function () {
            calc.subtract()
            expect(calc.get()).to.be.NaN
        })
        it('should return NaN for subtract("gosho")',function () {
            calc.subtract("gosho")
            expect(calc.get()).to.be.NaN
        })
        it('should return NaN for subtract({a:1})',function () {
            calc.subtract({a:1})
            expect(calc.get()).to.be.NaN
        })
        it('should return NaN for add("gosho")',function () {
            calc.add("gosho")
            expect(calc.get()).to.be.NaN
        })
    })
})