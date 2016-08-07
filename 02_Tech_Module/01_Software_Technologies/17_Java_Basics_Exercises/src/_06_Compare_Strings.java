import java.util.Arrays;
import java.util.Scanner;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _06_Compare_Strings {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String str1 = String.join("",sc.nextLine().split(" "));
        String str2 = String.join("",sc.nextLine().split(" "));

        if(str1.compareTo(str2)<0){
            System.out.println(str1);
            System.out.println(str2);
    }
        else if(str1.compareTo(str2)==0){
            System.out.println(str1);
            System.out.println(str1);
        }
        else{
            System.out.println(str2);
            System.out.println(str1);
        }
    }
}
