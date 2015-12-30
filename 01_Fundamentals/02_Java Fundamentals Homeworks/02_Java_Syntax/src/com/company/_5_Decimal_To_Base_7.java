package com.company;

import java.util.Scanner;
//From base-10 to base-7
public class _5_Decimal_To_Base_7 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int a = sc.nextInt();
        System.out.println(Integer.toString(a,7));
    }
}
