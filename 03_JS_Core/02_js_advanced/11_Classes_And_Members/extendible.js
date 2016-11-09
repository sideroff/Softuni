/**
 * Created by ivans on 03-Nov-16.
 */
let obj = (function () {
    let staticId = 0
    class Extendible {
        constructor() {
            this.id = staticId++
        }

        extend(other) {
            for (let key of [...Object.keys(other)]) {
                if (typeof (other[key]) == 'function') {
                    this.__proto__[key] = other[key]
                }
                else {
                    this[key] = other[key]
                }
            }
        }
    }
    return Extendible
} )()

console.dir(obj.extend)