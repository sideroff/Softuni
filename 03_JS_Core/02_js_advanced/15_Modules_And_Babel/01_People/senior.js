/**
 * Created by ivans on 08-Nov-16.
 */

let Employee = require('./Employee');

class Senior extends Employee {
    constructor(name, age) {
        super(name, age);

        this.tasks.push('is working on a complicated task.');
        this.tasks.push('is taking time off work.');
        this.tasks.push('is supervising junior workers.');
    }
}

module.exports = Senior;