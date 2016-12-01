/**
 * Created by ivans on 10-Nov-16.
 */



(function () {
    let Person = require('./person.js')
    let Post = require('./post.js')

    let aleks = new Person('Aleks',30)
    let post = new Post('Neshto si','Text','Aleks')
    aleks.addToSelector('.person')
    post.addToSelector('.posts.' + aleks.name)

    let aleksPosts = $('.post.Aleks');
    console.log(aleksPosts)
})();

// result.Person = require('./person')
// result.Post = require('./post')




