package com.company;

import java.util.Scanner;

/**
 * Created by Siderov on 20.10.2015 ã..
 */
public class _9_Hit_The_Target {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        for (int i = 1; i <= 20; i++) {
            for (int j = 1; j <=20; j++) {
                if(i+j==n) System.out.printf("%d + %d = %d\r\n",i,j,n);
                else if(Math.abs(i-j)==n){
                    if(i>j) System.out.printf("%d - %d = %d\r\n",i,j,n);
                    else System.out.printf("%d - %d = %d\r\n",j,i,n);
                }

            }

        }
    }
}
