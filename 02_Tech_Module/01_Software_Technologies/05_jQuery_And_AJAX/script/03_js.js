/**
 * Created by ivans on 28.6.2016 г..
 */


$(document).ready(function(){
    $('li').click(function () {
        let li = $(this)
        if(li.attr('data-selected')){
            li.css('background','')
            li.removeAttr('data-selected')
        }
        else {
            li.attr('data-selected',true)
            li.css('background','#DDD')
        }
    })
});


function displayCities() {
    let selectedLi = $('li[data-selected=true]')
    let towns = selectedLi.map((i, x) => x.innerText)
        .get().join(', ')
    $('body').append(towns)
}