import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Created by ivans on 4.8.2016 г..
 */
public class _07_Max_Sequence_of_Equal_Elements {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        if(input !=null && !input.isEmpty()) {
            List<Character> arr =Arrays.stream(input.split(" ")).map(s->s.charAt(0)).collect(Collectors.toList());
            int start = 0;
            int end = 1;
            int lenght = 1;

            for (int i = 0; i < arr.size(); i++) {
                int curLenght = 1;
                int j = i+1;
                while(j<arr.size() && arr.get(i)== arr.get(j) ){
                    curLenght++;
                    j++;
                }
                if(curLenght>lenght){
                    start=i;
                    end=j;
                    lenght=curLenght;
                }
            }

            for (int i = start; i < end; i++) {
                System.out.print(arr.get(i) + " ");
            }
        }
        else{
            System.out.println();
        }

    }
}
