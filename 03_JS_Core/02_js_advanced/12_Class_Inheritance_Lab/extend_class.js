/**
 * Created by ivans on 06-Nov-16.
 */

function extend(classObject) {
    classObject.prototype.species = 'Human'
    classObject.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`
    }
}