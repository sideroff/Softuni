/**
 * Created by ivans on 4.8.2016 г..
 */
public class _01_Calculate_Expression {
    public static void main(String[] args) {
        //[(30 + 21) * 1/2 * (35 - 12 - 1/2)]2
        double result = (30 + 21) * 0.5 * (35 - 12 - 0.5);
        result *= result;
        System.out.println(result);
    }
}
