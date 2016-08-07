import java.util.Scanner;


/**
 * Created by ivans on 4.8.2016 г..
 */
public class _04_Vowel_Digit_Or_Other {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        char input = sc.nextLine().charAt(0);
        if("aeiou".indexOf(input)>=0){
            System.out.println("vowel");
        }
        else if(Character.isDigit(input)){
            System.out.println("digit");
        }
        else{
            System.out.println("other");
        }
    }
}
