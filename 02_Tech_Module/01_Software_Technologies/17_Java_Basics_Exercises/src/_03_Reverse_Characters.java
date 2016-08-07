import java.util.Scanner;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _03_Reverse_Characters {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        char[] arr = new char[3];
        for (int i = 0; i < arr.length; i++) {
            arr[i] = sc.nextLine().charAt(0);
        }
        for (int i = arr.length - 1; i >= 0; i--) {
            System.out.print(arr[i]);
        }

    }

}
