/**
 * Created by ivans on 20-Oct-16.
 */

function extractText(){
    let text = Array.from($('#items1 li').map((index,li)=> $(li).text())).join(', ')
    $('#result1').text(text)
}

function search() {
    let searchedWord = $('#searchText').val()
    $('#towns li').each((index,li)=>colorise(index,li,searchedWord))
    $('#result').text($('#towns li:contains('+searchedWord+')').length + ' matches found')
    function colorise(i, li,searchedWord) {
        console.log(searchedWord)
        if(li.textContent.indexOf(searchedWord)!=-1){
            $(li).css('font-weight','bold')
        }
        else{
            $(li).css('font-weight','')
        }
    }
}
window.onload =
function initializeTable() {
    appendToTable('Bulgaria','Sofia')
    appendToTable('Germany','Berlin')
    appendToTable('Russia','Moscow')
    fixLinks()
    function appendToTable(country, capital) {
        $('#countriesTable').append(
            $('<tr>')
                .append(
                    $('<td>').text(country))
                .append(
                    $('<td>').text(capital))
                .append(
                    $('<td>')
                        .append('<a href="#" class="moveUp">[Up]</a>')
                        .append('<a href="#" class="moveDown">[Down]</a>')
                        .append('<a href="#" class="delete">[Delete]</a>'))
        )
    }

    $('#createLink').click(function () {
        let country = $('#newCountryText').val()
        let capital = $('#newCapitalText').val()
        appendToTable(country,capital)
        fixLinks()
    })

    $('#countriesTable').on('click', 'a.delete' ,function(){
        console.log('del')
        $(this).parent().parent().remove()
        fixLinks()
    })
    $('#countriesTable').on('click', 'a.moveUp' ,function(){
        console.log('up')
        let row = $(this).parent().parent()
        row.insertBefore(row.prev())
        fixLinks()
    })
    $('#countriesTable').on('click', 'a.moveDown' ,function(){
        console.log('down')
        let row = $(this).parent().parent()
        row.insertAfter(row.next())
        fixLinks()
    })

    function fixLinks() {
        $('#countriesTable tr a').css('display','inline')
        let arr = $('#countriesTable tr').toArray()
        let first = arr[2]
        let last = arr[arr.length-1]
        $(first).find('a.moveUp').css('display','none')
        $(last).find('a.moveDown').css('display','none')

    }
}
window.onload =
function attachEvents() {
    $('body').on('click','a.button, a.selected', function () {
        $('a.selected').removeClass('selected')
        $(this).addClass('selected')
    })
}

window.onload =
function attachEvents() {
    console.log('here')
    $('#items').on('click','li', function () {
        console.log('event')
        if($(this).attr('data-selected')){
            $(this).removeAttr('data-selected')
            $(this).css('background','')
        }
        else{
            $(this).attr('data-selected','true')
            $(this).css('background','#DDD')
        }
    })
    $('body').on('click','#showTownsButton', function () {
        let text = $('#items li[data-selected]').toArray().map(li=>$(li).text()).join(', ')
        $('#selectedTowns').text('Selected towns: ' + text)
    })

}