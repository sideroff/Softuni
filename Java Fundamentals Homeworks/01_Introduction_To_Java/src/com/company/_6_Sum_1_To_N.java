package com.company;

import java.util.Scanner;
// œ”— ¿… — CTRL+SHIFT+F10
/**
 * Created by Siderov on 19.10.2015 „..
 */
//Sum of numbers from 1 to N;
public class _6_Sum_1_To_N {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int sum = 0;
        for (int i = 1; i <= n; i++) {
            sum+=i;
        }
        System.out.println(sum);
    }
}
