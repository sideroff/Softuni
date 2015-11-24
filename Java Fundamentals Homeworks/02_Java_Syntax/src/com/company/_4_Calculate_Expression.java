package com.company;

import java.util.Scanner;

//Run Using CTRL+Shift+F10
//I asure you dis works
public class _4_Calculate_Expression {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        float a = sc.nextFloat();
        float b = sc.nextFloat();
        float c = sc.nextFloat();
        double F1 = Math.pow((a*a+b*b)/(a*a-b*b),(a+b+c)/Math.sqrt(c));
        double F2 = Math.pow(a*a+b*b-c*c*c,a-b);
        double diff = Math.abs(F1-F2);
        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f",F1,F2,diff);

    }
}
