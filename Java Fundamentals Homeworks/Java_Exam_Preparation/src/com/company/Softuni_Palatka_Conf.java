package com.company;

import java.util.Scanner;

/**
 * Created by Siderov on 15.11.2015 ã..
 */
public class Softuni_Palatka_Conf {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Integer people = Integer.parseInt(sc.nextLine());
        Integer lines = Integer.parseInt(sc.nextLine());
        Integer meals = 0;
        Integer beds = 0;
        for (int i = 0; i < lines; i++) {
            String input = sc.nextLine();
            String[] arg = input.split("\\s");
            Integer newBeds = Integer.parseInt(arg[1]);

            switch (arg[0]) {
                case "tents":
                    switch (arg[2]) {
                        case "normal":
                            beds+=newBeds*2;
                            break;
                        case "firstClass":
                            beds+=newBeds*3;
                            break;
                    }
                    break;
                case "rooms":
                    switch (arg[2]){
                        case "single":
                            beds+=newBeds*1;
                            break;
                        case "double":
                            beds+=newBeds*2;
                            break;
                        case "triple":
                            beds+=newBeds*3;
                            break;
                    }
                    break;
                case "food":
                    switch (arg[2]){
                        case "musaka":
                            meals+=newBeds*2;
                            break;
                        case "zakuska":
                            meals+=newBeds*0;
                            break;
                    }
                    break;
            }
        }
        if(beds-people>=0) System.out.printf("Everyone is happy and sleeping well. Beds left: %d\n", beds - people);
        else System.out.printf("Some people are freezing cold. Beds needed: %d\n",people-beds);

        if(meals-people>=0) System.out.printf("Nobody left hungry. Meals left: %d\n",meals-people);
        else System.out.printf("People are starving. Meals needed: %d\n",people-meals);

    }
}
