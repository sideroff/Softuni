/**
 * Created by ivans on 02-Nov-16.
 */

function solve(arr, sortBy) {
    let array = []
    class Ticket {
        constructor(destination,price,status){
            this.destination = destination
            this.price = Number(price)
            this.status = status
        }
    }
    for(ticketWannaBe of arr){
        let parts = ticketWannaBe.split('|')
        let newTicket = new Ticket(parts[0],parts[1],parts[2])
        array.push(newTicket)
    }
    if(sortBy == 'price'){
        array.sort((a,b) => a[sortBy] - (b[sortBy]))
    }
    else{
        array.sort((a,b) => a[sortBy].localeCompare(b[sortBy]))
    }
    return array
}
console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
))

console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'price'
))