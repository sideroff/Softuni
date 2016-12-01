/**
 * Created by ivans on 10-Nov-16.
 */

class Branch {
    constructor(id,branchName,companyName){
        this._id = id
        this._branchName = branchName
        this._companyName = companyName
        this._employees = []
    }
    get employees(){
        return this._employees
    }

    hire(employee){
        this._employees.push(employee)
    }
    toString(){
        let output = `@ ${this._companyName}, ${this._branchName}, ${this._id}\n`
        output += 'Employed:\n'
        if(this._employees.length>0){
            for(let em of this._employees){
                output += `** ${em.toString()}\n`
            }
        }
        else{
            output +='None...'
        }
        return output.trim()
    }
}

module.exports = Branch