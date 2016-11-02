/**
 * Created by ivans on 02-Nov-16.
 */
class Rat {
    constructor(name){
        this.name = name
        this.unitedWith = []
    }
    getRats(){
        return this.unitedWith
    }
    toString(){
        let others = this.unitedWith.map(r=>'\n##' + r).join('')
        return `${this.name}${others}`
    }
    unite(other){
        if(!(other instanceof Rat)){
            return
        }
        this.unitedWith.push(other)
    }
}

let rat = new Rat('gosho')
let rat2 = new Rat('pesho')
let rat3 = new Rat('stamat')
let rat4 = new Rat('primat')
rat.unite(rat2)
rat.unite(rat3)
rat.unite(rat4)
console.log('' + rat)