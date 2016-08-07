import java.util.Scanner;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _05_Symetric_Numbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        for (int i = 1; i <= n; i++) {
            String num = i +"";
            boolean isSymetric = true;
            for (int j = 0; j < num.length(); j++) {
                if(num.charAt(j) != num.charAt(num.length()-1-j)){
                    isSymetric=false;
                }
            }
            if(isSymetric){
                System.out.println(num +" ");
            }
        }
    }
}
