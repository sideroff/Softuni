import java.util.Scanner;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _02_Parse_Boolean {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        boolean variable = sc.nextBoolean();
        System.out.println(variable ? "Yes": "No");
    }
}
