/**
 * Created by ivans on 10-Nov-16.
 */

class Checkbox {
    constructor(label, selector){
        this._label = label
        this.selector = selector
        this._value = $(selector).is(':checked')

        let that = this
        $(selector).change(function () {
            that.value = $(selector).is(':checked');
        })
    }
    get label() {
        return this._label
    }
    get elements() {
        return $(this.selector)
    }

    get value(){
        return this._value
    }
    set value(val){
        if(typeof(val) != 'boolean'){
            throw new Error('Type of value must be boolean')
        }
        this._value = val
        $(this.elements).prop('checked', this._value);
    }

}

module.exports = Checkbox