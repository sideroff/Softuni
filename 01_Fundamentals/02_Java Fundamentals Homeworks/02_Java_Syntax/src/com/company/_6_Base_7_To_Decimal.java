package com.company;

import java.util.Scanner;

/**
 * Created by Siderov on 20.10.2015 ã..
 */
public class _6_Base_7_To_Decimal {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String base7Num = sc.next();
        System.out.println(Integer.toString(Integer.parseInt(base7Num, 7), 10));
    }
}
