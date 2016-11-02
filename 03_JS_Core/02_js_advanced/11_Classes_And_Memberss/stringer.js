/**
 * Created by ivans on 03-Nov-16.
 */
class Stringer {
    constructor(initialString, length){
        this._innerString = initialString
        this._innerLength = length
    }
    increase(length){
        this.innerLength += length
    }
    decrease(length){
        this.innerLength -= length
    }
    get innerLength() {
        return this._innerLength
    }
    set innerLength(value){
        if(value<3) this._innerLength = 0
        else{
            this._innerLength = value
        }
    }
    get innerString() {return this._innerString}

    toString(){
        let output = this._innerString.substr(0,this.innerLength)
        if(this._innerString.length>this._innerLength){
            output += '...'
        }
        return output
    }
}