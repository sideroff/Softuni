package com.company;

import java.util.Scanner;
// ПУСКАЙ С CTRL+SHIFT+F10
/**
 * Created by Siderov on 19.10.2015 �..
 */
public class _5_Print_Character_Triangle {
    public static void main(String[] args) {
        Scanner scn = new Scanner(System.in);
        byte n = scn.nextByte();

        for (int i = 1; i < n; i++) {
            for (int j = 0; j <i ; j++) {
                System.out.print(((char)(j+97))+" ");
            }
            System.out.println();
        }

        for (int i = n; i >0; i--) {
            for (int j = 0; j <i ; j++) {
                System.out.print(((char)(j+97))+" ");
            }
            System.out.println();
        }
    }
}
