package com.company;
import java.util.Arrays;
import java.util.Scanner;

//RUN USING CTRL+SHIFT+F10
//find all sequences of equal strings and print them on a single line;
public class _2_Sequence_Of_Equal_Strings {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split(" ");
        for (int i = 0; i < input.length -1; i++) {
            if(input[i].equals(input[i+1])) System.out.print(input[i]+" ");
            else System.out.println(input[i]);

        }
        System.out.println(input[input.length-1]);
    }
}
