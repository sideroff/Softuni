/**
 * Created by ivans on 08-Nov-16.
 */

function solve() {
    class Post{
        constructor(title, content){
            this.title = title
            this.content = content
        }
        toString(){
            let output = ''
            output+=`Post: ${this.title}\n`
            output+=`Content: ${this.content}`
            return output
        }
    }
    class SocialMediaPost extends Post{
        constructor(title, content, likes, dislikes){
            super(title,content)
            this.likes=likes
            this.dislikes=dislikes
            this.comments = []
        }
        addComment(comment){
            this.comments.push(comment)
        }
        toString(){
            let output = super.toString() +'\n'
            output += `Rating: ${this.likes - this.dislikes}`
            if(this.comments.length>0){
                output +='\n'
                output +='Comments:\n'
                for(let comment of this.comments){
                    output += ' * ' + comment + '\n'
                }
            }
            return output.trim()
        }
    }
    class BlogPost extends Post {
        constructor(title,content,views){
            super(title,content)
            this.views = views
        }
        view(){
            this.views++
            return this
        }
        toString(){
            let output = super.toString() +'\n'
            output += `Views: ${this.views}`

            return output
        }
    }
    return {Post,SocialMediaPost,BlogPost}
}
solve()