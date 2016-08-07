import java.util.Scanner;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _01_Hex_To_Dec {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        long number = Integer.parseInt(scanner.nextLine(),16);
        System.out.println(number);
    }
}
