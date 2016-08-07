import java.util.Scanner;
import java.util.StringJoiner;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _03_Three_Integer_Sum {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        int num1 = scanner.nextInt();
        int num2 = scanner.nextInt();
        int num3 = scanner.nextInt();

        if(!checkSums(num1,num2,num3) &&
                !checkSums(num2,num3,num1) &&
                !checkSums(num1,num3,num2)){
            System.out.println("No");
        }


    }

    public static boolean checkSums(int num1, int num2, int num3) {
        if(num1+num2!=num3){
            return false;
        }
        String output = "";
        if(num1<=num2){
            output=String.format("%d + %d = %d\n", num1, num2, num3);
        }
        else{
            output= String.format("%d + %d = %d\n", num2, num1, num3);
        }
        System.out.println(output);
        return true;
    }
}
