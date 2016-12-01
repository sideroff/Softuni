/**
 * Created by ivans on 13-Nov-16.
 */
let expect = require('chai').expect

function createList() {
    let data = [];
    return {
        add: function (item) {
            data.push(item)
        },
        shiftLeft: function () {
            if (data.length > 1) {
                let first = data.shift();
                data.push(first);
            }
        },
        shiftRight: function () {
            if (data.length > 1) {
                let last = data.pop();
                data.unshift(last);
            }
        },
        swap: function (index1, index2) {
            if (!Number.isInteger(index1) || index1 < 0 || index1 >= data.length ||
                !Number.isInteger(index2) || index2 < 0 || index2 >= data.length ||
                index1 === index2) {
                return false;
            }
            let temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
            return true;
        },
        toString: function () {
            return data.join(", ");
        }
    };
}



describe('Unit Tests for list', function () {
    let list
    beforeEach(function () {
        list = createList()
    })

    describe('add and tostring', function () {
        it('should be an object', function () {
            expect(typeof(list)).to.be.equal('object')
        })
        it('should have correct properties', function () {
            // POSSIBLE: TYPE OF PROPERTIES ( function, object or whatever )
            expect(list.hasOwnProperty('add')).to.be.equal(true)
            expect(list.hasOwnProperty('shiftLeft')).to.be.equal(true)
            expect(list.hasOwnProperty('shiftRight')).to.be.equal(true)
            expect(list.hasOwnProperty('swap')).to.be.equal(true)
            expect(list.hasOwnProperty('toString')).to.be.equal(true)


            expect(typeof(list.add)).to.be.equal('function')
            expect(typeof(list.shiftLeft)).to.be.equal('function')
            expect(typeof(list.shiftRight)).to.be.equal('function')
            expect(typeof(list.swap)).to.be.equal('function')
            expect(typeof(list.toString)).to.be.equal('function')
        })

        it('toString of empty list should return empty string', function () {
            expect(list.toString()).to.be.equal('')
        })

        it('toString of list with 1 element should return correct string', function () {
            list.add()
            list.add(undefined)
            list.add('')
            expect(list.toString()).to.be.equal(', , ')
        })
        it('toString of list with 1 element should return correct string', function () {
            list.add()
            expect(list.toString()).to.be.equal('')
        })
        it('toString of list with 1 element should return correct string', function () {
            list.add(15)
            expect(list.toString()).to.be.equal('15')
        })
        it('toString of list with more than 1 elements should return correct string', function () {
            list.add([1, 2])
            list.add('asd')
            list.add(-3.14)
            expect(list.toString()).to.be.equal('1,2, asd, -3.14')
        })
    })

    describe('shiftLeft and tostring', function () {
        it('shiftLeft to empty list should do nothing', function () {
            list.shiftLeft()
            expect(list.toString()).to.be.equal('')
        })
        it('shiftLeft to 1 el list should do nothing', function () {
            list.add(15)
            list.shiftLeft()
            expect(list.toString()).to.be.equal('15')
        })
        it('shiftLeft to 2 el list should flip list', function () {
            list.add(15)
            list.add('asd')
            list.shiftLeft()
            expect(list.toString()).to.be.equal('asd, 15')
        })
        it('shiftLeft to 3 or more el list should be correct', function () {
            list.add(-15.13)
            list.add(5)
            list.add({})

            list.shiftLeft()
            expect(list.toString()).to.be.equal('5, [object Object], -15.13')
        })
        it('shiftLeft, shiftRight to 3 or more el list should be correct', function () {
            list.add(-15.13)
            list.add(5)
            list.add({})

            list.shiftLeft()
            list.shiftRight()
            expect(list.toString()).to.be.equal('-15.13, 5, [object Object]')
        })
    })

    describe('shiftRight and tostring', function () {
        it('shiftRight to empty list should do nothing', function () {
            list.shiftRight()
            expect(list.toString()).to.be.equal('')
        })
        it('shiftRight to 1 el list should do nothing', function () {
            list.add(15)
            list.shiftRight()
            expect(list.toString()).to.be.equal('15')
        })
        it('shiftRight to 2 el list should flip list', function () {
            list.add(15)
            list.add('asd')
            list.shiftRight()
            expect(list.toString()).to.be.equal('asd, 15')
        })
        it('shiftRight to 3 or more el list should be correct', function () {
            list.add(-15.13)
            list.add(5)
            list.add({})

            list.shiftRight()
            expect(list.toString()).to.be.equal('[object Object], -15.13, 5')
        })
        it('shiftRight, shiftLeft to 3 or more el list should be correct', function () {
            list.add(-15.13)
            list.add('asd')
            list.add({})

            list.shiftRight()
            list.shiftLeft()
            expect(list.toString()).to.be.equal('-15.13, asd, [object Object]')
        })
    })

    describe('swap and tostring', function () {
        it('swap to empty list should return false', function () {
            expect(list.swap(0,0)).to.be.equal(false)
        })
        it('swap to 1 el list should return false', function () {
            list.add(15)
            list.swap(0,0)
            expect(list.swap(0,0)).to.be.equal(false)
        })
        it('swap to 2 el list should return false', function () {
            list.add(15)
            list.add(5)
            expect(list.swap(0,0)).to.be.equal(false)
        })
        it('swap to 2 el list should return false', function () {
            list.add(15)
            list.add(5)
            list.swap(0,0)
            expect(list.toString()).to.be.equal('15, 5')
        })
        it('swap to 2 el list should return true', function () {
            list.add(15)
            list.add(5)
            expect(list.swap(0,1)).to.be.equal(true)
        })
        it('tostring swap to 2 el list should return flipped list', function () {
            list.add(15)
            list.add(5)
            list.swap(0,1)
            expect(list.toString()).to.be.equal('5, 15')
        })

        it('swap to list with incorrect arguments should return false', function () {
            list.add(15)
            list.add(5)
            expect(list.swap()).to.be.equal(false)
        })

        it('swap to list with incorrect arguments should return false', function () {
            list.add(15)
            list.add(5)
            expect(list.swap(0)).to.be.equal(false)
        })


        it('swap to list with incorrect arguments should return false', function () {
            list.add(15)
            list.add(5)
            list.swap('ebisa',undefined)
            expect(list.toString()).to.be.equal('15, 5')
        })
        it('swap to list with incorrect arguments should return false', function () {
            list.add(15)
            list.add(5)
            expect(list.swap('1',0)).to.be.equal(false)
        })
        it('swap to list with incorrect arguments should return false', function () {
            list.add(15)
            list.add(5)
            list.add(2)
            expect(list.swap(0,1.14)).to.be.equal(false)
        })
        it('swap to list with incorrect arguments should not change list', function () {
            list.add(15)
            list.add(5)
            list.add(2)
            list.swap(0,1.14)
            expect(list.toString()).to.be.equal('15, 5, 2')
        })
        it('swap to 2 el list should return true', function () {
            list.add(15)
            list.add(5)
            expect(list.swap(0,1)).to.be.equal(true)
        })
        it('swap to 2 el list should flip list', function () {
            list.add(15)
            list.add('qj')
            list.add('hoq')

            list.swap(2,1)
            expect(list.toString()).to.be.equal('15, hoq, qj')
        })

        it('swap to 3 or more el list should be correct', function () {
            list.add(-15.13)
            list.add(5)
            list.add({})

            list.swap(1,2)
            expect(list.toString()).to.be.equal('-15.13, [object Object], 5')
        })
        it('swap to 3 or more el list with incorrect data should return false', function () {
            list.add(-15.13)
            list.add(5)
            list.add(1)
            expect(list.swap(-1,15)).to.be.equal(false)
        })
        it('swap to 3 or more el list with incorrect data should return false', function () {
            list.add(-15.13)
            list.add(5)
            list.add(1)
            expect(list.swap(0,-1)).to.be.equal(false)
        })
    })
})






















