package com.company;
//Run using CTRL+Shift+F10
//Task - get 3 numbers(int,float,float) and print what im printing;

import java.util.Scanner;

public class _3_Formatting_Numbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int a=-1;
        while(a<0||a>500){
            a = sc.nextInt();
        }
        float b = sc.nextFloat();
        float c = sc.nextFloat();

        System.out.printf("|%-10X|%s|%10.2f|%-10.3f|", a, Integer.toBinaryString(a), b, c);
    }
}
