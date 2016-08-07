import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Created by ivans on 5.8.2016 г..
 */
public class _12_Matrix_Of_Palindromes {
    public static void main(String[] args) {
        int rows;
        int cols;
        try{
            Scanner sc = new Scanner(System.in);
            List<Integer> tempList =Arrays.stream(sc.nextLine().split(" ")).map(x->Integer.parseInt(x)).collect(Collectors.toList());
            rows = tempList.get(0);
            cols = tempList.get(1);
        }
        catch (Exception ex){
            System.out.println("Suply two integers please.");
            return;
        }

        String[][] array = new String[rows][cols];
        for (int i = 0; i < array.length; i++) {
            for (int j = 0; j < array[i].length; j++) {
                array[i][j] = "";
                array[i][j] += (char)(97+i);
                array[i][j] += (char)(97+i+j);
                array[i][j] += (char)(97+i);
            }
        }
        for (int i = 0; i < array.length; i++) {
            for (int j = 0; j < array[i].length; j++) {
                System.out.print(array[i][j]+" ");
            }
            System.out.println();
        }

    }
}
