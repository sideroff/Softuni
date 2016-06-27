package com.company;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Siderov on 15.11.2015 ã..
 */
public class Rubix_Matrix {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\s");
        Integer rows = Integer.parseInt(input[0]);
        Integer cols = Integer.parseInt(input[1]);

        Integer[][] anArray= new Integer[rows][cols];

        Integer commands = Integer.parseInt(sc.nextLine());
        Integer counter = 1;
        for (int i = 0; i <rows; i++) {
            for (int j = 0; j < cols; j++) {
                anArray[i][j]=counter++;
            }
        }

        for (int i = 0; i < commands; i++) {
            String[] command = sc.nextLine().split("\\s");
            Integer rc = Integer.parseInt(command[0]);
            String cmd = command[1];
            Integer noffset = Integer.parseInt(command[2]);
            switch (cmd) {
                case "left":
                    noffset %=anArray[0].length;
                    for (int j = 0; j < noffset; j++) {
                        Integer temp = anArray[rc][0];
                        for (int index = 1; index < anArray[rc].length; index++) {
                            anArray[rc][index-1] = anArray[rc][index];
                        }
                        anArray[rc][anArray[rc].length - 1] = temp;
                    }
                    break;
                case "right":
                    noffset%=anArray[rc].length;
                    for (int j = 0; j < noffset; j++) {
                        Integer temp = anArray[rc][anArray[rc].length-1];
                        for (int k = anArray[rc].length-1; k >0; k--) {
                            anArray[rc][k] = anArray[rc][k-1];
                        }
                        anArray[rc][0] = temp;
                    }
                    break;
                case "up":
                    noffset%=anArray.length;
                    for (int j = 0; j < noffset; j++) {
                        Integer temp = anArray[0][rc];
                        for (int k = 0; k < anArray.length-1; k++) {
                            anArray[k][rc] = anArray[k+1][rc];
                        }
                        anArray[anArray.length-1][rc] = temp;

                    }

                    break;
                case "down":
                    noffset%=anArray.length;
                    for (int j = 0; j < noffset; j++) {
                        Integer temp = anArray[anArray.length-1][rc];
                        for (int k = anArray.length-1; k >0; k--) {
                            anArray[k][rc]=anArray[k-1][rc];

                        }
                        anArray[0][rc] = temp;

                    }
                    break;

            }
        }/*
        for (int i = 0; i < anArray.length; i++) {
            for (int j = 0; j < anArray[0].length; j++) {
                System.out.print(anArray[i][j] + ",");
            }
            System.out.println();

        }*/

        counter = 1;
        String sb = "";
        for (int i = 0; i < anArray.length; i++) {
            for (int j = 0; j < anArray[0].length; j++) {
                if(anArray[i][j]!=counter){
                    for (int k = 0; k < anArray.length; k++) {
                        for (int l = 0; l < anArray[0].length; l++) {
                            if(anArray[k][l]==counter){
                                Integer temp = anArray[i][j];
                                anArray[i][j] = anArray[k][l];
                                anArray[k][l] = temp;
                                sb+= String.format("Swap (%d, %d) with (%d, %d)\n", i, j, k, l);
                            }
                        }
                    }
                }
                else sb+=String.format("No swap required\n");
                counter++;
            }
        }
        System.out.print(sb);
    }
}
