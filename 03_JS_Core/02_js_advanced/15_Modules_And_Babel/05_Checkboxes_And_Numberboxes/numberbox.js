class Numberbox {
    constructor(label,selector,minValue,maxValue){
        this._label = label
        this.selector = selector
        this.minValue = minValue
        this.maxValue = maxValue
        this._value = minValue
        let that = this
        $(selector).change(function () {
            that.value = $(selector).val()
        })
    }
    get elements(){
        return $(this.selector)
    }

    get value(){
        return this._value
    }
    set value(val){
        if(val<this.minValue || val> this.maxValue){
            throw new Error(`Value must be in range [${this.minValue} and ${this.maxValue}]`)
        }
        this._value = val
        $(this.elements).val(this._value)
    }
}
module.exports = Numberbox