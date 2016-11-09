/**
 * Created by ivans on 09-Nov-16.
 */
class Entity{
    constructor(name){
        if(new.target === Entity){
            throw new Error('Cannot declare abstract class Entity.')
        }
        this.name = name
    }
}

module.exports = Entity