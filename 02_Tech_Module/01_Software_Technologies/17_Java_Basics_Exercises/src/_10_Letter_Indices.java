import java.util.Scanner;

/**
 * Created by ivans on 5.8.2016 г..
 */
public class _10_Letter_Indices {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String str = sc.nextLine();
        char[] ch  = str.toCharArray();
        for(char c : ch)
        {
            int temp = (int)c;
            if(temp<=122 & temp>=97)
                System.out.println(c + " -> " + (temp-97));
        }
    }
}
