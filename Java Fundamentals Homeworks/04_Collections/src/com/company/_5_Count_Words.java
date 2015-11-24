package com.company;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

//RUN USING CTRL+SHIFT+F10
//find largest substring
public class _5_Count_Words {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().trim().split("\\w+");
        System.out.println(input.length-1);
    }
}
