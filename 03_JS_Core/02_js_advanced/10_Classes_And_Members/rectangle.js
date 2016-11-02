/**
 * Created by ivans on 02-Nov-16.
 */

class Rectangle {
    constructor(width, height, color) {
        this.width = width
        this.height = height
        this.color = color
    }

    calcArea() {
        return this.width * this.height
    }
}