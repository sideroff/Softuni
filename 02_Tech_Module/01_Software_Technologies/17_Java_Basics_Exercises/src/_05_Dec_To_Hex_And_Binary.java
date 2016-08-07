import java.util.Scanner;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _05_Dec_To_Hex_And_Binary {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        long num = sc.nextLong();
        System.out.println(Long.toHexString(num).toUpperCase());
        System.out.println(Long.toBinaryString(num));
    }
}
