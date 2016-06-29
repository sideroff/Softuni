/**
 * Created by ivans on 29.6.2016 г..
 */

$(document).ready(function () {

    fixRowLinks()
    
    $('#addCountry').click(function (e) {
        
        e.preventDefault()
        
        let countryName = $('#countryName').val()
        let capitalName = $('#capitalName').val()
        let row = $('<tr>')
        
        let firstCol = $('<td>').html(countryName)
        let secondCol = $('<td>').html(capitalName)
        let thirdCol = $('<td>')
        
        let firstLink = $('<a>',{
            text: "[Up]",
            title: "Move row up",
            href: "#",
            class: "moveUp"
        })

        let secondLink = $('<a>',{
            text: "[Down]",
            title: "Move row down",
            href: "#",
            class: "moveDown"
        })

        let thirdLink = $('<a>',{
            text: "[Remove]",
            title: "Remove row",
            href: "#",
            class: "remove"
        })
        
        thirdCol
            .append(firstLink)            
            .append(" ")
            .append(secondLink)
            .append(" ")
            .append(thirdLink)
        
        row
            .append(firstCol)
            .append(secondCol)
            .append(thirdCol)
        
        
        $('#countriesTable').append(row)

        fixRowLinks()
    })

    $(document).on('click', '.remove', function (e) {
        e.preventDefault()
        $(this).parent().parent().remove();
        fixRowLinks()
    });

    $(document).on('click', '.moveUp', function (e) {
        let row = $(this).parent().parent()
        row.insertBefore(row.prev())
        fixRowLinks()
    })

    $(document).on('click', '.moveDown', function (e) {
        let row = $(this).parent().parent()
        row.insertAfter(row.next())
        fixRowLinks()
    })

    function fixRowLinks() {
        $('#countriesTable a').show();

        let tableRows = $('#countriesTable tr')
        $(tableRows[1]).find("a:contains('Up')").hide()

        $(tableRows[tableRows.length-1]).find("a:contains('Down')").hide();

    }
})

