/**
 * Created by ivans on 13-Nov-16.
 */
    class MailBox{
        constructor(){
            this._messages = []
        }
        addMessage(subject,text){
            this._messages.push({subject: subject, text: text})
            return this
        }
        get messageCount() {
            return this._messages.length
        }
        deleteAllMessages(){
            this._messages = []
        }
        findBySubject(subject){
            let matching = []
            for(let msg of this._messages){
                if(msg.subject.indexOf(subject)>=0){
                    matching.push(msg)
                }
            }
            return matching
        }
        toString(){
            let output = ''
            for(let msg of this._messages){
                output += ` * ${msg.subject} ${msg.text}\n`
            }
            if(output ==''){
                output = ' * (empty mailbox)'
            }
            return output
        }
    }