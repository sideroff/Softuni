package com.company;
import java.util.Arrays;
import java.util.Scanner;

//RUN USING CTRL+SHIFT+F10
//Sort array of ints (use int[]);

public class _1_Sort_Array {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int numberOfDigits = Integer.parseInt(sc.nextLine());
        int[] array = new int[numberOfDigits];
        for (int i = 0; i < numberOfDigits; i++) {
            array[i] = sc.nextInt();
        }
        Arrays.sort(array);
        for (int i : array) {
            System.out.print(i);
        }



    }
}
