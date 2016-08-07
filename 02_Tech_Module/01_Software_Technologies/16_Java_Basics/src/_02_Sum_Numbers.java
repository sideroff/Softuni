import java.util.Scanner;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _02_Sum_Numbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double num1 = scanner.nextDouble();
        double num2 = scanner.nextDouble();
        System.out.printf("Sum = %.2f", num1 + num2);
    }
}
