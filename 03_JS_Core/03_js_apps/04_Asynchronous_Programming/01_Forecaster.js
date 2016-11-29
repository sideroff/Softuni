/**
 * Created by ivans on 25-Nov-16.
 */

function attachEvents() {
    let baseUrl = 'https://judgetests.firebaseio.com'
    let cityName

    let weatherSymbols = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degrees': '&#176',
    }

    $('#submit').on('click',function () {
        $('#forecast').show()
        cityName = $('#location').val()
        $.ajax({
            method: 'GET',
            url: baseUrl +'/locations.json',
        })
            .then(getCityData)
            .catch(displayError)

        function getCityData(data) {
            let wanted = data.find(d => d['name'] == cityName)
            if(!wanted){
                displayError('Error')
                return
            }
            let currentForecast = $.ajax({
                method: 'GET',
                url: baseUrl + `/forecast/today/${wanted['code']}.json`
            })

            let threeDayForecast = $.ajax({
                method: 'GET',
                url: baseUrl + `/forecast/upcoming/${wanted['code']}.json`
            })

            Promise.all([currentForecast, threeDayForecast])
                .then(displayCurrentAndNextThreeDayForecast)
                .catch(displayError)

        }

        function displayCurrentAndNextThreeDayForecast([current,threeDay]){
            let conditionSymbolSpan = $('<span>').addClass('condition symbol').html(weatherSymbols[current['forecast']['condition']])
            let conditionSpan = $('<span>').addClass('condition')
            let locationSpan = $('<span>').addClass('forecast-data').html(current['name'])
            let lowTemStr = current['forecast']['low'] + weatherSymbols['Degrees']
            let highTemStr = current['forecast']['high'] + weatherSymbols['Degrees']
            let tempSpan = $('<span>').addClass('forecast-data').html(`${lowTemStr}/${highTemStr}`)
            let conSpan = $('<span>').addClass('forecast-data').html(current['forecast']['condition'])

            conditionSpan.append(locationSpan)
            conditionSpan.append(tempSpan)
            conditionSpan.append(conSpan)

            $('#current').append(conditionSymbolSpan)
            $('#current').append(conditionSpan)

            //3day

            for(let fc of threeDay['forecast']){
                let symbolSpan = $('<span>').addClass('symbol').html(weatherSymbols[fc['condition']])
                let tempString = fc['low'] + weatherSymbols['Degrees'] +'/' + fc['high'] + weatherSymbols['Degrees']
                let dataSpan = $('<span>').addClass('forecast-data').html(tempString)
                let condSpan = $('<span>').addClass('forecast-data').text(fc['condition'])
                let wrapper = $('<span>').addClass('upcoming')
                wrapper.append(symbolSpan);
                wrapper.append(dataSpan);
                wrapper.append(condSpan);
                $('#upcoming').append(wrapper)
            }
        }

        function displayError(error) {
            console.dir(error)
        }
    })
}