/**
 * Created by ivans on 22-Oct-16.
 */


window.onload =
function subtract() {
    $('#result').text(
        Number($('#firstNumber').val()) -
        Number($('#secondNumber').val()))
}

function increment(selector) {
    let container = $(selector)
    let textArea = $('<textarea></textarea>')
    let incrementBtn = $('<button>Increment</button>')
    let addBtn = $('<button>Add</button>')
    let list = $('<ul>')

    textArea.val(0)
    textArea.addClass('counter')
    textArea.attr('disabled',true)
    incrementBtn.addClass('btn')
    incrementBtn.attr('id','incrementBtn')
    addBtn.addClass('btn')
    addBtn.attr('id','addBtn')
    list.addClass('results')

    incrementBtn.on('click',function (event) {
        let value = parseInt(textArea.val())
        textArea.val(++value)
    })
    addBtn.on('click',function (event) {
        let value = parseInt(textArea.val())
        let li = $('<li>')
        li.text(value)
        list.append(li)
    })
}

window.onload =
function timer() {
    let hours = $('#hours')
    let minutes = $('#minutes')
    let seconds = $('#seconds')

    let timer
    let steps
    let start = $('#start-timer')
    let stop = $('#stop-timer')
    let isRunning = false
    start.on('click',function () {
        if(!isRunning){
            start.attr('disabled','disabled')
            stop.removeAttr('disabled')
            steps=0
            timer = setInterval(step,1000)
            isRunning=true
        }

    })
    stop.on('click',function () {
        if(isRunning){
            stop.attr('disabled','disabled')
            start.removeAttr('disabled')
            clearInterval(timer)
            isRunning=false
        }
    })

    function step() {
        steps++
        seconds.text(('0' + steps%60).slice(-2))
        minutes.text(('0' + Math.floor(steps/60)%60).slice(-2))
        hours.text(('0'+Math.floor(steps/60/60)%60).slice(-2))
    }
}

window.onload =
function () {
    createBook("#wrapper", "Alice in Wonderland", "Lewis Carroll", 1111);
    createBook("#wrapper", "Alice in Wonderland", "Lewis Carroll", 1111);
    createBook("#wrapper", "Alice in Wonderland", "Lewis Carroll", 1111);
}
let createBook =
(function bookGenerator() {
    let id = 1
    return function (selector, titleName, authorName, isbn) {

        $(selector).append($('<div>').attr('id',"book" + id++)
            .append( $('<p>').addClass('title').text(titleName))
            .append($('<p>').addClass('author').text(authorName))
            .append($('<p>').addClass('isbn').text(isbn))
            .append(
                $('<button>Select</button>')
                    .click(function () {
                        $(this).parent().css('border','2px solid blue')
            }))
            .append(
                $('<button>Deselect</button>')
                    .click(function () {
                        $(this).parent().css('border','none')
            })))
    }
})()

function domSearch(selector, caseType) {
    let addControls = $('<div>')
        .addClass('add-controls')
        .append($('<label>').text('Enter text:').append($('<input>')))
        .append($('<a>')
            .addClass('button')
            .css('display', 'inline-block')
            .text('Add')
            .click(function () {
                let elementText = $('label input');
                let newElement = $('<li>')
                    .addClass('list-item')
                    .append($('<a>').addClass('button').text('X').click(function () {
                        $(this).parent().remove();
                    }))
                    .append($('<strong>').text(elementText.val().trim()));

                $('ul.items-list').append(newElement);
                elementText.val('');
            }));

    let searchControls = $('<div>')
        .addClass('search-controls')
        .append($('<label>').text('Search:').append($('<input>')
            .on('input', function () {
                let needle = $(this).val();
                let items = $('.list-item strong').toArray();
                for (let item of items) {
                    let current = $(item);

                    if (caseType) {
                        if (current.text().indexOf(needle) < 0) {
                            current.parent().css('display', 'none')
                        } else {
                            current.parent().css('display', '')
                        }
                    } else {
                        if (current.text().toLowerCase().indexOf(needle.toLowerCase()) < 0) {
                            current.parent().css('display', 'none')
                        } else {
                            current.parent().css('display', '')
                        }
                    }

                }
            })));

    let resultControls = $('<div>').addClass('result-controls')
        .append($('<ul>').addClass('items-list'));

    $(selector)
        .append(addControls)
        .append(searchControls)
        .append(resultControls);
}

function calendar([day, month, year]) {
    let date = new Date(year, month , 0);
    let monthNames = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];

    let tBody = $('<tbody>')
        .append($('<tr>')
            .append($('<th>').text('Mon'))
            .append($('<th>').text('Tue'))
            .append($('<th>').text('Wed'))
            .append($('<th>').text('Thu'))
            .append($('<th>').text('Fri'))
            .append($('<th>').text('Sat'))
            .append($('<th>').text('Sun')));

    let calendar = $('<table>')
        .append($('<caption>').text(monthNames[date.getMonth()] + ' ' + date.getFullYear()))
        .append(tBody);

    let firstDay = (new Date(year, month - 1, 1).getDay() - 1);
    firstDay = firstDay < 0 ? 6 : firstDay;

    let firstWeek = $('<tr>');
    let dayOfMonth = 1;
    for (let d = 0; d < 7; d++) {
        if (d < firstDay) {
            firstWeek.append($('<td>'));
        } else {
            if (dayOfMonth == day) {
                firstWeek.append($('<td>').addClass('today').text(dayOfMonth++));
            }else {
                firstWeek.append($('<td>').text(dayOfMonth++));
            }
        }
    }

    tBody.append(firstWeek);

    let lastDay = new Date(year, month, 0).getDate();
    let numOfRemainingRows = (lastDay + 1 - dayOfMonth) / 7;
    for (let i = 0; i < numOfRemainingRows; i++) {
        let currentWeek = $('<tr>');
        for (let d = 0; d < 7; d++) {
            if (dayOfMonth > lastDay) {
                currentWeek.append($('<td>'));
            } else {
                if (dayOfMonth == day) {
                    currentWeek.append($('<td>').addClass('today').text(dayOfMonth++));
                }else {
                    currentWeek.append($('<td>').text(dayOfMonth++));
                }
            }
        }

        tBody.append(currentWeek);
    }

    $('#content').append(calendar)
}

function wikiParser(selector) {
    let text = $(selector).text();
    let formatted = text
        .replace(/===([^='\[]+?)===/g, (m, g) => `<h3>${g}</h3>`)
        .replace(/==([^='\[]+?)==/g, (m, g) => `<h2>${g}</h2>`)
        .replace(/=([^='\[]+?)=/g, (m, g) => `<h1>${g}</h1>`)
        .replace(/'''([^'=\[]+?)'''/g, (m, g) => `<b>${g}</b>`)
        .replace(/''([^'=\[]+?)''/g, (m, g) => `<i>${g}</i>`)
        .replace(/\[\[([^'=\[\]]+?)\|([^'=\[\]]+?)]]/g, (m, g1, g2) => `<a href="/wiki/${g1}">${g2}</a>`)
        .replace(/\[\[([^'=\[\]]+?)]]/g, (m, g) => `<a href="/wiki/${g}">${g}</a>`);

    $(selector).html(formatted);
}