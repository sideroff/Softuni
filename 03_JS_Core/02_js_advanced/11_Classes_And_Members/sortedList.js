/**
 * Created by ivans on 03-Nov-16.
 */
class SortedList {
    constructor() {
        this.elements = []
        this.size = 0
    }

    add(element) {
        this.elements.push(element)
        this.reSort()
        this.size++
    }

    remove(index) {
        this.elements.splice(index, 1)
        this.reSort()
        this.size--
    }

    get(index) {
        this.checkIndexValidity(index)
        return this.elements[index]
    }

    checkIndexValidity(index) {
        if (!(index >= 0 && index < this.elements.length)) {
            throw new Error('Index ' + index + ' is out of bounds.')
        }
    }

    reSort() {
        this.elements = this.elements.sort((a, b) => a - b)
    }
}