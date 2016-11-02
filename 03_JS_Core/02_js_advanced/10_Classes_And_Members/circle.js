/**
 * Created by ivans on 02-Nov-16.
 */
class Circle {
    constructor(radius){
        this.radius = radius
    }
    get diameter() {
        return this.radius*2
    }
    set diameter(value){
        this.radius = value/2
    }
    get area(){
        return Math.PI * this.radius * this.radius
    }
}