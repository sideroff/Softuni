package com.company;
import java.util.Arrays;
import java.util.Scanner;

public class FebGandalf {

    public static void main(String[] args) {
	    Scanner sc = new Scanner(System.in);
        Integer mood = Integer.parseInt(sc.nextLine());
        String[] foods = sc.nextLine().trim().split("[^a-zA-Z0-9]+");
        for (String food : foods) {
            switch (food.toLowerCase()){
                case "cram":
                    mood+=2;
                    break;
                case "lembas":
                    mood+=3;
                    break;
                case"apple":
                    mood+=1;
                    break;
                case"melon":
                    mood+=1;
                    break;
                case "honeycake":
                    mood+=5;
                    break;
                case "mushrooms":
                    mood+=-10;
                    break;
                default:
                    mood+=-1;
                    break;
            }
        }
        System.out.println(mood);
        if(mood<-5) System.out.println("Angry");
        if(mood>=-5&&mood<0) System.out.println("Sad");
        if(mood>=0&&mood<15) System.out.println("Happy");
        if(mood>=15) System.out.println("Special JavaScript mood");
    }
}
