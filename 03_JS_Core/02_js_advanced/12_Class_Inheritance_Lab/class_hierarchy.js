/**
 * Created by ivans on 06-Nov-16.
 */

function solve() {
    class Figure {
        constructor() {
            if (new.target === Figure) {
                throw new Error('Cannot get an instance of abstract class.')
            }
        }

        get area() {
            throw new Error('area() not implemented.')
        }

    }
    class Circle extends Figure {
        constructor(radius) {
            super()
            this.radius = radius
        }

        get area() {
            return Math.PI * this.radius * this.radius
        }

        toString() {
            return `${this.constructor.name} - radius: ${this.radius}`
        }
    }
    class Rectangle extends Figure {
        constructor(width, height) {
            super() // it is
            this.width = width
            this.height = height
        }

        get area () {
            return  this.width * this.height
        }

        toString() {
            return `${this.constructor.name} - width: ${this.width}, height: ${this.height}`
        }
    }
    return{Figure,Circle,Rectangle}
}
solve()